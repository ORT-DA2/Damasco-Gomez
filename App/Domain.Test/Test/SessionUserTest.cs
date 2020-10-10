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
            Guid token = Guid.NewGuid();
            sessionUser.Update(token);
            Assert.AreEqual(token, sessionUser.Token);
        }
    }
}