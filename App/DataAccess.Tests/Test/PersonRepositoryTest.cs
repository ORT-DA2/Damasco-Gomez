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
        public void TestAdd()
        {
            Person person = new Person(){Id = 123, Email="name new"};
            mockDbContext.Setup(d => d.Set<Person>()).Returns(mockSet.GetMockDbSet(personsToReturn).Object);
            int persons = personsToReturn.Count();
            mockDbContext.Setup(d => d.SaveChanges()).Returns(person.Id);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new PersonRepository(repositoryMaster);

            repository.Add(person);

            Assert.AreEqual(persons+1, personsToReturn.Count());
        }
        [TestMethod]
        public void TestAddFailValidate()
        {
            Person person = new Person(){Id = 123, Email="name new"};
            int personLenght = personsToReturn.Count() ;
            mockDbContext.Setup(d => d.Set<Person>()).Returns(mockSet.GetMockDbSet(personsToReturn).Object);
            mockDbContext.Setup(d => d.SaveChanges()).Returns(person.Id);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new PersonRepository(repositoryMaster);

            repository.Add(person);

            //Assert.AreEqual(personLenght,repositoryMaster.Persons.Count() + 1);
        }
        [TestMethod]
        public void TestAddFailExist()
        {
            Person person = personsToReturn.First();
            ArgumentException exception = new ArgumentException();
            var _mockSet = mockSet.GetMockDbSet(personsToReturn);
            _mockSet.Setup(d => d.Find(It.IsAny<Person>())).Throws(exception);
            mockDbContext.Setup(d => d.Set<Person>()).Returns(_mockSet.Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new PersonRepository(repositoryMaster);

            //repository.Add(person);

            //Assert.AreEqual();
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
        public void TestExistElement()
        {
            Person person = personsToReturn.First();
            mockDbContext.Setup(d => d.Set<Person>()).Returns(mockSet.GetMockDbSet(personsToReturn).Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new PersonRepository(repositoryMaster);

            bool result = repository.ExistElement(person);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestExistElementFail()
        {
            Person person = personsToReturn.First();
            mockDbContext.Setup(d => d.Set<Person>()).Returns(mockSet.GetMockDbSet(emptyPerson).Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new PersonRepository(repositoryMaster);

            bool result = repository.ExistElement(person);

            Assert.IsFalse(result);
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
        [TestMethod]
        public void TestExistById()
        {
            Person person = personsToReturn.First();
            var _mockSet = mockSet.GetMockDbSet(personsToReturn);
            _mockSet.Setup(d => d.Find(It.IsAny<object[]>())).Returns(person);
            mockDbContext.Setup(d => d.Set<Person>()).Returns(_mockSet.Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new PersonRepository(repositoryMaster);

            bool result = repository.ExistElement(person.Id);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestExistByIdFail()
        {
            Person person = new Person(){Id=123423};
            mockDbContext.Setup(d => d.Set<Person>()).Returns(mockSet.GetMockDbSet(personsToReturn).Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new PersonRepository(repositoryMaster);

            bool result = repository.ExistElement(person.Id);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestFind()
        {
            Person person = personsToReturn.First();
            var _mockSet = mockSet.GetMockDbSet(personsToReturn);
            _mockSet.Setup(d => d.Find(It.IsAny<object[]>())).Returns(person);
            mockDbContext.Setup(d => d.Set<Person>()).Returns(_mockSet.Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new PersonRepository(repositoryMaster);

            Person result = repository.Find(person.Id);

            Assert.AreEqual(result,person);
        }

        [TestMethod]
        public void TestFindFail()
        {
            Person person = new Person(){Id=232323};
            Person personNull = null;
            var _mockSet = mockSet.GetMockDbSet(personsToReturn);
            ArgumentException exception = new ArgumentException();
            _mockSet.Setup(d => d.Find(It.IsAny<object[]>())).Returns(personNull);
            mockDbContext.Setup(d => d.Set<Person>()).Returns(_mockSet.Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new PersonRepository(repositoryMaster);

            Person result = repository.Find(person.Id);

            Assert.IsNull(result);
        }
        [TestMethod]
        public void TestUpdate()
        {
            Person person = personsToReturn.First();
            person.Email = "New name of person";
            string newEmail = person.Email;
            mockDbContext.Setup(d => d.Set<Person>()).Returns(mockSet.GetMockDbSet(personsToReturn).Object);
            mockDbContext.Setup(d => d.SaveChanges()).Returns(person.Id);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new PersonRepository(repositoryMaster);

            repository.Update(person);

            Assert.AreEqual(person.Email,newEmail);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestUpdateFail()
        {
            Person person = new Person(){Id = 13000};
            string newEmail = person.Email;
            // Exception exception = new ArgumentException();
            mockDbContext.Setup(d => d.Set<Person>()).Returns(mockSet.GetMockDbSet(personsToReturn).Object);
            mockDbContext.Setup(d => d.SaveChanges()).Returns(personsToReturn.First().Id);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new PersonRepository(repositoryMaster);

            repository.Update(person);

            // Assert.IsInstanceOfType(result, typeof(Exception));
        }
        [TestMethod]
        public void TestDelete()
        {
            Person person = personsToReturn.First();
            int lengthPersons = personsToReturn.Count();
            mockDbContext.Setup(d => d.Set<Person>()).Returns(mockSet.GetMockDbSet(personsToReturn).Object);
            mockDbContext.Setup(d => d.SaveChanges()).Returns(person.Id);
            mockDbContext.Setup(d => d.Remove(person));
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new PersonRepository(repositoryMaster);

            repository.Delete(person);

            //Assert.AreEqual(personsToReturn.Count, lengthPersons - 1 );
        }
        [TestMethod]
        public void TestDeleteFailExist()
        {
            Person person = personsToReturn.First();
            int lengthPersons = personsToReturn.Count();
            mockDbContext.Setup(d => d.Set<Person>()).Returns(mockSet.GetMockDbSet(personsToReturn).Object);
            mockDbContext.Setup(d => d.SaveChanges()).Returns(person.Id);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new PersonRepository(repositoryMaster);

            repository.Delete(person);

            //Assert.AreEqual(personsToReturn.Count, lengthPersons - 1 );
        }
        [TestMethod]
        public void TestDeleteById()
        {
            Person person = personsToReturn.First();
            int lengthPersons = personsToReturn.Count();
            var _mockSet = mockSet.GetMockDbSet(personsToReturn);
            _mockSet.Setup(d => d.Find(It.IsAny<object[]>())).Returns(person);
            mockDbContext.Setup(d => d.Set<Person>()).Returns(_mockSet.Object);
            mockDbContext.Setup(d => d.SaveChanges()).Returns(person.Id);
            //mockDbContext.Setup(d => d.Remove(person.Id));
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new PersonRepository(repositoryMaster);

            repository.Delete(person.Id);

            //Assert.AreEqual(personsToReturn.Count, lengthPersons - 1 );
        }
        [TestMethod]
        public void TestDeleteByIdFailExist()
        {
            Person person = personsToReturn.First();
            Person personNull = null;
            int lengthPersons = personsToReturn.Count();
            var _mockSet = mockSet.GetMockDbSet(personsToReturn);
            _mockSet.Setup(d => d.Find(It.IsAny<object[]>())).Returns(personNull);
            mockDbContext.Setup(d => d.Set<Person>()).Returns(_mockSet.Object);
            mockDbContext.Setup(d => d.SaveChanges()).Returns(person.Id);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new PersonRepository(repositoryMaster);

            //repository.Delete(person.Id);

            //Assert.AreEqual(personsToReturn.Count, lengthPersons - 1 );
        }
    }
}