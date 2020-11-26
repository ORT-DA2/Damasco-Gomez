using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Context;
using DataAccess.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DataAccess.Tests.Test
{
    [TestClass]
    public class PersonRepositoryTest
    {
        private List<Person> personsToReturn;
        private RepositoryMaster repositoryMaster;
        private DbContext context;
        private DbContextOptions options;
        private PersonRepository repositoryPerson;
        [TestInitialize]
        public void Setup()
        {
            this.options = new DbContextOptionsBuilder<VidlyContext>().UseInMemoryDatabase(databaseName: "VidlyDBtest").Options;
            this.context = new VidlyContext(this.options);
            personsToReturn = new List<Person>()
            {
                new Person()
                {
                    Id = 1,
                    Email = "Person 1",
                },
                new Person()
                {
                    Id = 2,
                    Email = "Person 2",
                }
            };

            personsToReturn.ForEach(m => this.context.Add(m));
            this.context.SaveChanges();
            repositoryMaster = new RepositoryMaster(context);
            repositoryPerson = new PersonRepository(repositoryMaster);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.context.Database.EnsureDeleted();
        }
        [TestMethod]
        public void TestAdd()
        {
            Person person = new Person(){Id = 123, Email="name new"};
            PersonRepository repo = new PersonRepository(this.repositoryMaster);
            int cantRepo = this.repositoryPerson.GetElements().Count();

            repo.Add(person);

            Assert.AreEqual(repo.GetElements().Count(),cantRepo+1);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddFailValidate()
        {
            Person person = new Person(){Id = 1, Email="name new"};

            repositoryPerson.Add(person);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddFailExist()
        {
            Person person = personsToReturn.First();
            ArgumentException exception = new ArgumentException();

            repositoryPerson.Add(person);
        }
        [TestMethod]
        public void TestGetAllPersonsOk()
        {
            var result = repositoryPerson.GetElements();

            Assert.IsTrue(personsToReturn.SequenceEqual(result));
        }
        [TestMethod]
        public void TestExistElement()
        {
            Person person = personsToReturn.First();

            bool result = repositoryPerson.ExistElement(person);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestExistElementFail()
        {
            Person person = new Person(){Id = 223 , Email="name"};

            bool result = repositoryPerson.ExistElement(person);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestExistWithIdFail()
        {
            int personId = 234234234;

            bool result = repositoryPerson.ExistElement(personId);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestExistById()
        {
            Person person = personsToReturn.First();

            bool result = repositoryPerson.ExistElement(person.Id);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestExistByIdFail()
        {
            Person person = new Person(){Id=123423};

            bool result = repositoryPerson.ExistElement(person.Id);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestFind()
        {
            Person person = personsToReturn.First();

            Person result = repositoryPerson.Find(person.Id);

            Assert.AreEqual(result,person);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestFindFail()
        {
            Person person = new Person(){Id=232323};

            Person result = repositoryPerson.Find(person.Id);
        }
        [TestMethod]
        public void TestUpdate()
        {
            Person person = personsToReturn.First();
            person.Email = "New name of person";
            string newEmail = person.Email;

            repositoryPerson.Update(person.Id,person);

            Assert.AreEqual(person.Email,newEmail);
        }
        [TestMethod]
        public void TestDelete()
        {
            Person person = personsToReturn.First();
            int repoCount = this.repositoryPerson.GetElements().Count();

            repositoryPerson.Delete(person);

            Assert.AreEqual(repoCount - 1 , repositoryPerson.GetElements().Count());
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestDeleteFailExist()
        {
            Person person = new Person(){Id = 2342342};

            repositoryPerson.Delete(person);
        }
        [TestMethod]
        public void TestDeleteById()
        {
            Person person = personsToReturn.First();
            int repoCount = this.repositoryPerson.GetElements().Count();

            repositoryPerson.Delete(person.Id);

            Assert.AreEqual(repoCount - 1 , repositoryPerson.GetElements().Count());
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestDeleteByIdFailExist()
        {
            int id = 23123123;

            repositoryPerson.Delete(id);
        }
    }
}