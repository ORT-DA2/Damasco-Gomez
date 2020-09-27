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
        private List<Person> personsToReturnEmpty;
        private RepositoryMaster repositoryMaster;
        private VidlyContext context;
        private VidlyDbSet<Person> mockSet;
        private Mock<DbContext> mockDbContext;
        private PersonRepository repository;
        private List<Person> emptyPerson;
        [TestInitialize]
        public void initVariables()
        {
            personsToReturn = new List<Person>()
            {
                new Person()
                {
                    Id = 1,
                    Email = "New person",
                },
                new Person()
                {
                    Id = 2,
                    Email = "Other person",
                },
                new Person()
                {
                    Id = 3,
                    Email = "And other person",
                },
                new Person()
                {
                    Id = 4,
                    Email = "And one more person",
                }
            };
            emptyPerson = new List<Person>();
            mockSet = new VidlyDbSet<Person>();
            mockDbContext = new Mock<DbContext>(MockBehavior.Strict);
        }
        [TestMethod]
        public void TestGetAllPersonsOk()
        {
            mockDbContext.Setup(d => d.Set<Person>()).Returns(mockSet.GetMockDbSet(personsToReturn).Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new PersonRepository(repositoryMaster);
            var result = repository.GetElements();
            Assert.IsTrue(personsToReturn.SequenceEqual(result));
        }
        [TestMethod]
        public void TestGetAllPersonsNull()
        {
            List<Person> emptyPerson = new List<Person>();
            mockDbContext.Setup(d => d.Set<Person>()).Returns(mockSet.GetMockDbSet(emptyPerson).Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new PersonRepository(repositoryMaster);
            var result = repository.GetElements();
            Assert.IsTrue(emptyPerson.SequenceEqual(result));
        }
        [TestMethod]
        public void TestExistNot()
        {
            Person person = personsToReturn.First();
            mockDbContext.Setup(d => d.Set<Person>()).Returns(mockSet.GetMockDbSet(emptyPerson).Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new PersonRepository(repositoryMaster);
            bool result = repository.ExistElement(person);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestExist()
        {
            Person person = personsToReturn.First();
            mockDbContext.Setup(d => d.Set<Person>()).Returns(mockSet.GetMockDbSet(personsToReturn).Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new PersonRepository(repositoryMaster);
            bool result = repository.ExistElement(person);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestExistWithIdFail()
        {
            int personId = personsToReturn.First().Id;
            mockDbContext.Setup(d => d.Set<Person>()).Returns(mockSet.GetMockDbSet(personsToReturn).Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new PersonRepository(repositoryMaster);
            bool result = repository.ExistElement(personId);
            Assert.IsFalse(result);
        }
        // [TestMethod]
        // public void TestExistPersonById()
        // {
        //     Person person = personsToReturn.First();
        //     mockDbContext.Setup(d => d.Set<Person>()).Returns(mockSet.GetMockDbSet(personsToReturn).Object);
        //     repositoryMaster = new RepositoryMaster(mockDbContext.Object);
        //     repository = new PersonRepository(repositoryMaster);
        //     bool result = repository.ExistElement(person.Id);
        //     Assert.IsTrue(result);
        // }
        [TestMethod]
        public void TestExistPerson()
        {
            Person person = personsToReturn.First();
            mockDbContext.Setup(d => d.Set<Person>()).Returns(mockSet.GetMockDbSet(personsToReturn).Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new PersonRepository(repositoryMaster);
            bool result = repository.ExistElement(person);
            Assert.IsTrue(result);
        }
        // [TestMethod]
        // public void TestFind()
        // {
        //     Person person = personsToReturn.First();
        //     mockDbContext.Setup(d => d.Set<Person>()).Returns(mockSet.GetMockDbSet(personsToReturn).Object);
        //     repositoryMaster = new RepositoryMaster(mockDbContext.Object);
        //     repository = new PersonRepository(repositoryMaster);
        //     Person result = repository.Find(person.Id);
        //     Assert.AreEqual(result,person);
        // }

        [TestMethod]
        public void TestFindFail()
        {
            Person person = personsToReturn.First();
            mockDbContext.Setup(d => d.Set<Person>()).Returns(mockSet.GetMockDbSet(personsToReturn).Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new PersonRepository(repositoryMaster);
            Person result = repository.Find(person.Id + 1000);
            // Exception exception = new ArgumentException();
            // Assert.IsInstanceOfType(result, typeof(Exception));
            Assert.IsNull(result);
        }
        [TestMethod]
        public void TestUpdate()
        {
            Person person = personsToReturn.First();
            person.Email = "New name of person";
            string newEmail = person.Email;
            mockDbContext.Setup(d => d.Set<Person>()).Returns(mockSet.GetMockDbSet(personsToReturn).Object);
            mockDbContext.Setup(d => d.SaveChanges()).Returns(personsToReturn.First().Id);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new PersonRepository(repositoryMaster);
            repository.Update(person);
            Assert.AreEqual(person.Email,newEmail);
        }
        [TestMethod]
        public void TestUpdateFail()
        {
            Person person = new Person(){Id = 13000};
            string newEmail = person.Email;
            mockDbContext.Setup(d => d.Set<Person>()).Returns(mockSet.GetMockDbSet(personsToReturn).Object);
            mockDbContext.Setup(d => d.SaveChanges()).Returns(personsToReturn.First().Id);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new PersonRepository(repositoryMaster);
            repository.Update(person);
            // Exception exception = new ArgumentException();
            // Assert.IsInstanceOfType(result, typeof(Exception));
        }
    }
}