using System;
using Contracts;
using Domain;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.In;
using Model.Out;
using Moq;
using WebApi.Controllers;

namespace WebApi.Tests.Test
{
    [TestClass]
    public class SessionControllerTest
    {
        private SessionUser sessionUser;
        private Mock<ISessionLogic> mock;
        private SessionController sessionController ;
        private PersonModel personModel;
        private Person person;
        private Guid newToken;

        [TestInitialize]
        public void initVariables()
        {
            PersonModel personModel = new PersonModel()
            {
                Email = "yuli@gmail.com",
                Password ="uruguaynomas",
            };
            mock = new Mock<ISessionLogic>(MockBehavior.Strict);
            sessionController = new SessionController(mock.Object);
        }
        [TestMethod]
        public void TestLoginOk()
        {
            PersonModel personModel = new PersonModel {Email = "email", Password="psw"};
            Person person = personModel.ToEntity();
            Guid newToken = Guid.NewGuid();
            mock.Setup(m => m.Login(person)).Returns(newToken);
            SessionBasicModel sessionModel = new SessionBasicModel(newToken);

            var result = sessionController.Post(personModel);

            mock.VerifyAll();
            var okResult = result as OkObjectResult;
            var session = okResult.Value as SessionBasicModel;
            Assert.IsNotNull(result);
            Assert.AreEqual(session, sessionModel);
        }

    }
}