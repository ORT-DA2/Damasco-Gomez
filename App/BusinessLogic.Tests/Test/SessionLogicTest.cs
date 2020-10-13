using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic.Logics;
using DataAccessInterface.Repositories;
using Domain;
using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BusinessLogic.Tests.Test
{
    [TestClass]
    public class SessionLogicTest
    {
        private SessionLogic sessionUserLogic;
        private Mock<ISessionUserRepository> mock;
        private Mock<IPersonRepository> mock2;
        private Mock<SessionUser> mock3;
        private List<SessionUser> sessions;
         private List<SessionUser> session2;
        private List<SessionUser> sessionUserEmpty;
        private List <Person> personResult;
        [TestInitialize]
        public void Initialize ()
        {
               sessions = new List<SessionUser>()
            {
                new SessionUser()
                {
                    Id = 1,
                    Token = Guid.NewGuid(),
                    PersonId   = 1,
                },
                new SessionUser()
                {
                    Id = 2,
                    Token = Guid.NewGuid(),
                    PersonId   = 2,
                },
            };
            mock = new Mock<ISessionUserRepository>(MockBehavior.Strict);
            mock2 = new Mock<IPersonRepository>(MockBehavior.Strict);
            mock3 = new Mock<SessionUser>(MockBehavior.Strict);
            sessionUserLogic = new SessionLogic(mock.Object, mock2.Object);
            sessionUserEmpty = new List<SessionUser>();
        }
        [TestMethod]
        public void TestIsCorrectionToken()
        {
            Guid correctToken = sessions.First().Token;
            mock.Setup(m => m.IsCorrectToken(correctToken)).Returns(true);
            bool result = sessionUserLogic.IsCorrectToken(correctToken);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestNotValidToken()
        {
           Guid notExistToken = Guid.NewGuid();
           mock.Setup(m => m.IsCorrectToken(notExistToken)).Returns(false);
           bool result = sessionUserLogic.IsCorrectToken(notExistToken);
           Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestLoginNotExistSessionPreviously ()
        {
            List<Person> personResult = new List<Person> () 
            {   new Person()
                {
                    Id = 3,
                    Email= "soyyuliana@gmail.com",
                    Password = "soyyo"
                }
            };
            SessionUser sessionToReturn = new SessionUser()
            {
                Token = Guid.NewGuid(),
            };
            mock2.Setup(m=>m.GetElements()).Returns(personResult);
            List <SessionUser> sessions = new List<SessionUser>();
            mock.Setup(mock=>mock.GetElements()).Returns(sessions);
            mock.Setup(mock=>mock.Add(It.IsAny<SessionUser>())).Returns(sessionToReturn);
            
            Guid guidToReturn = sessionUserLogic.Login(personResult.First()); 

            mock.VerifyAll();
       }
        [TestMethod]
        public void TestLoginExistPreviouslySession ()
        {
             List<Person> personResult = new List<Person> () 
            {   new Person()
                {
                    Id = 1,
                    Email= "soyyuliana@gmail.com",
                    Password = "soyyo"
                }
            };
            session2 = new List<SessionUser>()
            {
                new SessionUser()
                {
                    Id = 1,
                    Token = Guid.NewGuid(),
                    PersonId   = 1,
                },
            };
            Guid newGuid = Guid.NewGuid();
            mock2.Setup(m=>m.GetElements()).Returns(personResult);
            mock.Setup(mock=>mock.GetElements()).Returns(session2);
            mock3.Setup(mock=>mock.Update(newGuid));

            Guid tokenAdded = sessionUserLogic.Login(personResult.First()); 

            mock.VerifyAll();
        }
    }
}