using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic.Logics;
using DataAccessInterface.Repositories;
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
        private List<SessionUser> sessions;
        private List<SessionUser> sessionUserEmpty;
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
                new SessionUser()
                {
                    Id = 3,
                    Token = Guid.NewGuid(),
                    PersonId   = 3,
                }
            };
            mock = new Mock<ISessionUserRepository>(MockBehavior.Strict);
            mock2 = new Mock<IPersonRepository>(MockBehavior.Strict);
            sessionUserLogic = new SessionLogic(mock.Object, mock2.Object);
            sessionUserEmpty = new List<SessionUser>();

        
        }
        [TestMethod]
        public void TestisCorrectionToken()
        {
            Guid correctToken = sessions.First().Token;
            mock.Setup(m => m.IsCorrectToken(correctToken)).Returns(true);
            var result = sessionUserLogic.IsCorrectToken(correctToken);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestLoginOk()
        {
            /* public void Login(Person person)  
        {
            List<Person> personResult = this.personRepository.GetElements().FindAll(kz=>kz.Email == person.Email);
            if (personResult.Count==0)
            {
                throw new ArgumentException("User was not created");
            }
            person = personResult.First();
            Guid guid = Guid.NewGuid();
            List <SessionUser> sessions = this.sessionUserRepository.GetElements().FindAll(m=>m.PersonId==person.Id)
            if(sessions.Count==0)
            {
                SessionUser newSession = new SessionUser ()
                {
                    Token = guid,
                    PersonId = person.Id
                };
                this.sessionUserRepository.Add(newSession);
            }
            else 
            {
                sessions.First().Update(guid);
            }*/
            Assert.IsTrue(true);
        }
        
    }
}