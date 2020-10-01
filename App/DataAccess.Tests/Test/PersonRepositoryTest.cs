using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Context;
using DataAccess.Repositories;
using DataAccess.Tests.Utils;
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
        private PersonRepository repository;
        private List<Person> emptyPerson;
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
            repository = new PersonRepository(repositoryMaster);
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
            int cantRepo = this.repository.GetElements().Count();

            repo.Add(person);

            Assert.AreEqual(repo.GetElements().Count(),cantRepo+1);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddFailValidate()
        {
            Person person = new Person(){Id = 1, Email="name new"};

            repository.Add(person);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddFailExist()
        {
            Person person = personsToReturn.First();
            ArgumentException exception = new ArgumentException();

            repository.Add(person);
        }
        [TestMethod]
        public void TestGetAllPersonsOk()
        {
            var result = repository.GetElements();

            Assert.IsTrue(personsToReturn.SequenceEqual(result));
        }
        [TestMethod]
        public void TestExistElement()
        {
            Person person = personsToReturn.First();

            bool result = repository.ExistElement(person);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestExistElementFail()
        {
            Person person = new Person(){Id = 223 , Email="name"};

            bool result = repository.ExistElement(person);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestExistWithIdFail()
        {
            int personId = 234234234;

            bool result = repository.ExistElement(personId);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestExistById()
        {
            Person person = personsToReturn.First();

            bool result = repository.ExistElement(person.Id);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestExistByIdFail()
        {
            Person person = new Person(){Id=123423};

            bool result = repository.ExistElement(person.Id);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestFind()
        {
            Person person = personsToReturn.First();

            Person result = repository.Find(person.Id);

            Assert.AreEqual(result,person);
        }

        [TestMethod]
        public void TestFindFail()
        {
            Person person = new Person(){Id=232323};

            Person result = repository.Find(person.Id);

            Assert.IsNull(result);
        }
        [TestMethod]
        public void TestUpdate()
        {
            // Person person = personsToReturn.First();
            // person.Email = "New name of person";
            // string newEmail = person.Email;

            // repository.Update(person);

            // Assert.AreEqual(person.Email,newEmail);
        }
        [TestMethod]
        //[ExpectedException(typeof(ArgumentException))]
        public void TestUpdateFail()
        {
            // Person person = new Person(){Id = 13000};
            // string newEmail = person.Email;

            //repository.Update(person);
        }
        [TestMethod]
        public void TestDelete()
        {
            Person person = personsToReturn.First();
            int repoCount = this.repository.GetElements().Count();

            repository.Delete(person);

            Assert.AreEqual(repoCount - 1 , repository.GetElements().Count());
        }
        [TestMethod]
        public void TestDeleteFailExist()
        {
            Person person = personsToReturn.First();
            int lengthPersons = personsToReturn.Count();

            repository.Delete(person);
        }
        [TestMethod]
        public void TestDeleteById()
        {
            Person person = personsToReturn.First();
            int repoCount = this.repository.GetElements().Count();

            repository.Delete(person.Id);

            Assert.AreEqual(repoCount - 1 , repository.GetElements().Count());
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestDeleteByIdFailExist()
        {
            int id = 23123123;

            repository.Delete(id);
        }
    }
}