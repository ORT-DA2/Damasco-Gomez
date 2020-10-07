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
        private Person personId1;
        private Mock<IPersonLogic> mock;
        private PersonController controller ;
        [TestInitialize]
        public void initVariables()
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
            personId1 = personsToReturn.First();
            mock = new Mock<IPersonLogic>(MockBehavior.Strict);
            controller = new PersonController(mock.Object);
        }
        [TestMethod]
        public void TestGetAllPersonsOk()
        {
            mock.Setup(m => m.GetAll()).Returns(personsToReturn);
            IEnumerable<PersonBasicModel> personBasicModels = personsToReturn.Select(m => new PersonBasicModel(m));

            var result = controller.Get();

            var okResult = result as OkObjectResult;
            var persons = okResult.Value as IEnumerable<PersonBasicModel>;
            mock.VerifyAll();
            Assert.IsTrue(personBasicModels.SequenceEqual(persons));
        }

        [TestMethod]
        public void TestGetAllPersonsVacia()
        {
            mock.Setup(m => m.GetAll()).Returns(personsToReturnEmpty);
            IEnumerable<PersonBasicModel> personBasicModels = personsToReturnEmpty.Select(m => new PersonBasicModel(m));

            var result = controller.Get();

            var okResult = result as OkObjectResult;
            var persons = okResult.Value as IEnumerable<PersonBasicModel>;
            Assert.IsTrue(personBasicModels.SequenceEqual(persons));
        }
        [TestMethod]
        public void TestGetByOk()
        {
            mock.Setup(m => m.GetBy(personId1.Id)).Returns(personId1);
            PersonBasicModel personBasicModel = new PersonBasicModel(personId1);

            var result = controller.GetBy(personId1.Id);

            var okResult = result as OkObjectResult;
            var persons = okResult.Value as PersonBasicModel;
            Assert.IsTrue(persons.Equals(personBasicModel));
        }
        [TestMethod]
        public void TestGetByNotFound()
        {
            int id = 4;
            ArgumentException exist = new ArgumentException();
            mock.Setup(m => m.GetBy(id)).Throws(exist);

            var result = controller.GetBy(id);

            mock.VerifyAll();
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        [TestMethod]
        public void TestPostOk()
        {
            PersonModel personModel = new PersonModel()
            {
                Email = "email",
                Password = "psswd"
            };
            personId1 = personModel.ToEntity();
            mock.Setup(m => m.Add(personId1)).Returns(personId1);

            var result = controller.Post(personModel);

            var okResult = result as CreatedAtRouteResult;
            mock.VerifyAll();
            Assert.IsNotNull(okResult);
            Assert.AreEqual("GetPerson", okResult.RouteName);
            Assert.AreEqual(okResult.Value, personId1);
        }
        [TestMethod]
        public void TestPostFailSamePerson()
        {
            PersonModel personModel = new PersonModel()
            {
                Email = "email",
                Password = "psswd"
            };
            personId1 = personModel.ToEntity();
            Exception exist = new AggregateException();
            mock.Setup(p => p.Add(personId1)).Throws(exist);

            var result = controller.Post(personModel);

            mock.VerifyAll();
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        [TestMethod]
        public void TestPostFailValidation()
        {
            PersonModel personModel = new PersonModel()
            {
                Email = "email",
                Password = "psswd"
            };
            personId1 = personModel.ToEntity();
            Exception exist = new ArgumentException();
            mock.Setup(p => p.Add(personId1)).Throws(exist);

            var result = controller.Post(personModel);

            mock.VerifyAll();
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        [TestMethod]
        public void TestPostFailServer()
        {
            PersonModel personModel = new PersonModel()
            {
                Email = "email",
                Password = "psswd"
            };
            personId1 = personModel.ToEntity();
            Exception exist = new Exception();
            mock.Setup(p => p.Add(personId1)).Throws(exist);

            var result = controller.Post(personModel);

            mock.VerifyAll();
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        [TestMethod]
        public void TestPutOk()
        {
            PersonModel personModel = new PersonModel()
            {
                Email = "email",
                Password = "psw"
            };
            personId1 = personModel.ToEntity();
            personId1.Email = "new email";
            mock.Setup(m => m.Update(personId1.Id,personId1));

            var result = controller.Put(personId1.Id, personModel);

            var okResult = result as CreatedAtRouteResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual("GetPerson", okResult.RouteName);
            Assert.AreEqual(okResult.Value, personId1);
        }
        [TestMethod]
        public void TestPutFailValidate()
        {
            PersonModel personModel = new PersonModel()
            {
                Email = "email",
                Password = "psw"
            };
            personId1 = personModel.ToEntity();
            Exception exist = new ArgumentException();
            mock.Setup(p => p.Update(personId1.Id,personId1)).Throws(exist);

            var result = controller.Put(personId1.Id, personModel);

            mock.VerifyAll();
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        [TestMethod]
        public void TestPutFailServer()
        {
            PersonModel personModel = new PersonModel()
            {
                Email = "email",
                Password = "psw"
            };
            personId1 = personModel.ToEntity();
            Exception exist = new Exception();
            mock.Setup(p => p.Update(personId1.Id,personId1)).Throws(exist);

            var result = controller.Put(personId1.Id, personModel);

            mock.VerifyAll();
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        [TestMethod]
        public void TestDeleteWithId()
        {
            Person person = personsToReturn.First();
            mock.Setup(m => m.GetBy(person.Id)).Returns(person);
            mock.Setup(mock=> mock.Delete(person.Id));

            var result = controller.Delete(person.Id);

            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestDeleteWithIdNotFound()
        {
            Person person = personsToReturn.First();
            Person personNull = null;
            mock.Setup(m => m.GetBy(person.Id)).Returns(personNull);
            mock.Setup(mock=> mock.Delete(person.Id));

            var result = controller.Delete(person.Id);

            Assert.IsInstanceOfType(result,typeof(NotFoundResult));
        }

        [TestMethod]
        public void TestDelete()
        {
            mock.Setup(mock=> mock.Delete());

            var result = controller.Delete();
            
            Assert.IsNotNull(result);
        }
    }
}