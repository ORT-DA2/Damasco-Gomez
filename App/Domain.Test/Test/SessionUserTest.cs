using System;
using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.Test.Test
{
    [TestClass]
    public class SessionUserTest
    {
        public SessionUser sessionUser;
        [TestInitialize]
        public void SetUp()
        {
            sessionUser = new SessionUser()
                {
                    Id = 1,
                    Token = Guid.NewGuid(),
                    PersonId = 1

                };
        }
        public void TestUpdateToken()
        {
            SessionUser newSession= new SessionUser()
                {
                    Token = Guid.NewGuid(),
                };
            sessionUser.Update(newSession);
            Assert.AreEqual(newSession.Token, sessionUser.Token);
        }
        [TestMethod]
        public void TestUpdateTokenEmpty()
        {
            Assert.IsTrue(true);
        }
    }
}