using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogicInterface;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.In;
using Model.Out;
using Moq;
using WebApi.Controllers;

namespace WebApi.Tests
{
    [TestClass]
    public class PersonControllerTest
    {
        private List<Person> personsToReturn;
        private List<Person> personsToReturnEmpty;
        private Person personWithId1;
        private Mock<IPersonLogic> mockPersonLogic;
        private PersonController controllerPerson ;
        [TestInitialize]
        public void InitVariables()
        {
            personsToReturn = new List<Person>()
            {
                new Person()
                {
                    Id = 1,
                    Email = "mail1@mail.com",
                },
                new Person()
                {
                    Id = 2,
                    Email = "mail2@mail.com",
                },
                new Person()
                {
                    Id = 3,
                    Email = "mail3@mail.com",
                },
                new Person()
                {
                    Id = 4,
                    Email = "mail4@mail.com",
                }
            };
            personsToReturnEmpty = new List<Person>();
            personWithId1 = personsToReturn.First();
            mockPersonLogic = new Mock<IPersonLogic>(MockBehavior.Strict);
            controllerPerson = new PersonController(mockPersonLogic.Object);
        }
        [TestMethod]
        public void TestGetAllPersonsOk()
        {
            mockPersonLogic.Setup(m => m.GetAll()).Returns(personsToReturn);
            IEnumerable<PersonBasicModel> personBasicModels = personsToReturn.Select(m => new PersonBasicModel(m));

            var result = controllerPerson.Get();

            var okResult = result as OkObjectResult;
            var persons = okResult.Value as IEnumerable<PersonBasicModel>;
            mockPersonLogic.VerifyAll();
            Assert.IsTrue(personBasicModels.SequenceEqual(persons));
        }

        [TestMethod]
        public void TestGetAllPersonsVacia()
        {
            mockPersonLogic.Setup(m => m.GetAll()).Returns(personsToReturnEmpty);
            IEnumerable<PersonBasicModel> personBasicModels = personsToReturnEmpty.Select(m => new PersonBasicModel(m));

            var result = controllerPerson.Get();

            var okResult = result as OkObjectResult;
            var persons = okResult.Value as IEnumerable<PersonBasicModel>;
            Assert.IsTrue(personBasicModels.SequenceEqual(persons));
        }
        [TestMethod]
        public void TestGetByOk()
        {
            mockPersonLogic.Setup(m => m.GetBy(personWithId1.Id)).Returns(personWithId1);
            PersonBasicModel personBasicModel = new PersonBasicModel(personWithId1);

            var result = controllerPerson.GetBy(personWithId1.Id);

            var okResult = result as OkObjectResult;
            var persons = okResult.Value as PersonBasicModel;
            Assert.IsTrue(persons.Equals(personBasicModel));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGetByNotFound()
        {
            int id = 4;
            ArgumentException exist = new ArgumentException();
            mockPersonLogic.Setup(m => m.GetBy(id)).Throws(exist);

            var result = controllerPerson.GetBy(id);

            mockPersonLogic.VerifyAll();
        }
        [TestMethod]
        public void TestPostOk()
        {
            PersonModel personModel = new PersonModel()
            {
                Email = "email",
                Password = "psswd"
            };
            personWithId1 = personModel.ToEntity();
            mockPersonLogic.Setup(m => m.Add(personWithId1)).Returns(personWithId1);
            PersonBasicModel personBasicModel = new PersonBasicModel(personWithId1);

            var result = controllerPerson.Post(personModel);

            var okResult = result as CreatedAtRouteResult;
            mockPersonLogic.VerifyAll();
            Assert.IsNotNull(okResult);
            Assert.AreEqual("GetPerson", okResult.RouteName);
            Assert.AreEqual(okResult.Value, personBasicModel);
        }
        [TestMethod]
        [ExpectedException(typeof(AggregateException))]
        public void TestPostFailSamePerson()
        {
            PersonModel personModel = new PersonModel()
            {
                Email = "email",
                Password = "psswd"
            };
            personWithId1 = personModel.ToEntity();
            Exception exist = new AggregateException();
            mockPersonLogic.Setup(p => p.Add(personWithId1)).Throws(exist);

            var result = controllerPerson.Post(personModel);

            mockPersonLogic.VerifyAll();
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPostFailValidation()
        {
            PersonModel personModel = new PersonModel()
            {
                Email = "email",
                Password = "psswd"
            };
            personWithId1 = personModel.ToEntity();
            ArgumentException exist = new ArgumentException();
            mockPersonLogic.Setup(p => p.Add(personWithId1)).Throws(exist);

            var result = controllerPerson.Post(personModel);

            mockPersonLogic.VerifyAll();
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestPostFailServer()
        {
            PersonModel personModel = new PersonModel()
            {
                Email = "email",
                Password = "psswd"
            };
            personWithId1 = personModel.ToEntity();
            Exception exist = new Exception();
            mockPersonLogic.Setup(p => p.Add(personWithId1)).Throws(exist);

            var result = controllerPerson.Post(personModel);

            mockPersonLogic.VerifyAll();
        }
        [TestMethod]
        public void TestPutOk()
        {
            PersonModel personModel = new PersonModel()
            {
                Email = "email",
                Password = "psw"
            };
            personWithId1 = personModel.ToEntity();
            personWithId1.Email = "new email";
            mockPersonLogic.Setup(m => m.Update(personWithId1.Id,personWithId1)).Returns(personWithId1);
            PersonBasicModel personBasicModel = new PersonBasicModel(personWithId1);

            var result = controllerPerson.Put(personWithId1.Id, personModel);

            var okResult = result as CreatedAtRouteResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual("GetPerson", okResult.RouteName);
            Assert.AreEqual(okResult.Value, personBasicModel);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPutFailValidate()
        {
            PersonModel personModel = new PersonModel()
            {
                Email = "email",
                Password = "psw"
            };
            personWithId1 = personModel.ToEntity();
            Exception exist = new ArgumentException();
            mockPersonLogic.Setup(p => p.Update(personWithId1.Id,personWithId1)).Throws(exist);

            var result = controllerPerson.Put(personWithId1.Id, personModel);

            mockPersonLogic.VerifyAll();
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestPutFailServer()
        {
            PersonModel personModel = new PersonModel()
            {
                Email = "email",
                Password = "psw"
            };
            personWithId1 = personModel.ToEntity();
            Exception exist = new Exception();
            mockPersonLogic.Setup(p => p.Update(personWithId1.Id,personWithId1)).Throws(exist);

            var result = controllerPerson.Put(personWithId1.Id, personModel);

            mockPersonLogic.VerifyAll();
        }
        [TestMethod]
        public void TestDeleteWithId()
        {
            Person person = personsToReturn.First();
            mockPersonLogic.Setup(m => m.GetBy(person.Id)).Returns(person);
            mockPersonLogic.Setup(mockPersonLogic=> mockPersonLogic.Delete(person.Id));

            var result = controllerPerson.Delete(person.Id);

            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestDeleteWithIdNotFound()
        {
            Person person = personsToReturn.First();
            Person personNull = null;
            mockPersonLogic.Setup(m => m.GetBy(person.Id)).Returns(personNull);
            mockPersonLogic.Setup(mockPersonLogic=> mockPersonLogic.Delete(person.Id));

            var result = controllerPerson.Delete(person.Id);
        }

        [TestMethod]
        public void TestDelete()
        {
            mockPersonLogic.Setup(mockPersonLogic=> mockPersonLogic.Delete());

            var result = controllerPerson.Delete();
            
            Assert.IsNotNull(result);
        }
    }
}