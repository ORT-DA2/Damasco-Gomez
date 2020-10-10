using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessInterface.Repositories;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BusinessLogic.Tests.Test
{
    [TestClass]
    public class PersonLogicTest
    {
        private List<Person> personsToReturn;
        private PersonLogic personLogic;
        private Mock<IPersonRepository> mock;
        private List<Person> emptyPersons;

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
            emptyPersons = new List<Person>();
            mock = new Mock<IPersonRepository>(MockBehavior.Strict);
            personLogic = new PersonLogic(mock.Object);
        }
        [TestMethod]
        public void TestDeleteById()
        {
            int lengthTouristPoint = personsToReturn.Count;
            mock.Setup(m => m.Delete(personsToReturn.First().Id));

            personLogic.Delete(personsToReturn.First().Id);

            mock.VerifyAll();
        }

        [TestMethod]
        public void TestDelete()
        {
            int lengthRegions = personsToReturn.Count;
            mock.Setup(m => m.GetElements()).Returns(personsToReturn);
            foreach (Person t in personsToReturn)
            {
                mock.Setup(m => m.Delete(t.Id));
            }

            personLogic.Delete();

            mock.VerifyAll();
        }
        [TestMethod]
        public void TestDeleteEmpty()
        {
            List<Person> emptyListPersons = new List<Person>();
            mock.Setup(m => m.GetElements()).Returns(emptyListPersons);

            personLogic.Delete();

            mock.VerifyAll();
        }
        [TestMethod]
        public void GetAll()
        {
            mock.Setup(m => m.GetElements()).Returns(personsToReturn);

            var result = personLogic.GetAll();

            Assert.IsTrue(result.SequenceEqual(personsToReturn));
        }
        [TestMethod]
        public void GetByTestOk()
        {
            Person person = personsToReturn.First();
            mock.Setup(m => m.Find(person.Id)).Returns(person);

            var result = personLogic.GetBy(person.Id);

            Assert.AreEqual(result,person);
        }
        [TestMethod]
        public void TestGetByFail()
        {
            Person person = personsToReturn.First();
            Person empty = null;
            mock.Setup(m => m.Find(person.Id)).Returns(empty);

            var result = personLogic.GetBy(person.Id);

            mock.VerifyAll();
            Assert.IsNull(result);
        }
        [TestMethod]
        public void TestAddOk()
        {
            Person person = personsToReturn.First();
            mock.Setup(m => m.Add(person)).Returns(person);

            Person result= personLogic.Add(person);

            Assert.AreEqual(person, result );
        }
        [TestMethod]
        public void TestAddValidateError()
        {
            Person person = personsToReturn.First();
            mock.Setup(m => m.Add(person)).Returns(person);

            var result = personLogic.Add(person);

            Assert.AreEqual(person, result);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddExistError()
        {
            Person person = personsToReturn.First();
            ArgumentException exception = new ArgumentException();
            mock.Setup(m => m.Add(person)).Throws(exception);

            var reuslt = personLogic.Add(person);

            mock.VerifyAll();
        }
        [TestMethod]
        public void TestUpdateOk ()
        {
            Person person = personsToReturn.First();
            mock.Setup(m => m.Find(person.Id)).Returns(person);
            mock.Setup(m => m.Update(person.Id,person));

            Person newP = personLogic.Update(person.Id,person);

            Assert.AreEqual(person,newP);
        }
        [TestMethod]
        public void TestUpdateValidateError()
        {
            Person person = personsToReturn.First();
            mock.Setup(m => m.Find(person.Id)).Returns(person);
            mock.Setup(m => m.Update(person.Id,person));

            personLogic.Update(person.Id,person);

            mock.VerifyAll();
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestUpdateExistError()
        {
            Person person = personsToReturn.First();
            ArgumentException exception = new ArgumentException();
            mock.Setup(m => m.Find(person.Id)).Returns(person);
            mock.Setup(m => m.Update(person.Id,person)).Throws(exception);

            personLogic.Update(person.Id,person);

            mock.VerifyAll();
        }
        [TestMethod]
        public void TestExistOk()
        {
            Person person = personsToReturn.First();
            mock.Setup(m => m.ExistElement(person)).Returns(true);

            var result = personLogic.Exist(person);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestNotExistOk()
        {
            Person person = personsToReturn.First();
            mock.Setup(m => m.ExistElement(person)).Returns(false);
            var result = personLogic.Exist(person);

            mock.VerifyAll();

            Assert.IsFalse(result);
        }
    }
}