using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Context;
using DataAccess.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataAccess.Tests.Test
{
     [TestClass]
    public class SessionUserRepositoryTest
    {
        private List<SessionUser> sessions;
        private SessionUser elementToUpdate;
        private RepositoryMaster repositoryMaster;
        private DbContext context;
        private DbContextOptions options;
        private SessionUserRepository repository;
        [TestInitialize]
        public void Setup()
        {
            this.options = new DbContextOptionsBuilder<VidlyContext>().UseInMemoryDatabase(databaseName: "VidlyDBtest").Options;
            this.context = new VidlyContext(this.options);
            sessions = new List<SessionUser>()
            {
                new SessionUser()
                {
                    Id = 1,
                    Token = Guid.NewGuid(),
                },
                new SessionUser()
                {
                    Id = 2,
                    Token = Guid.NewGuid(),
                }
            };

            sessions.ForEach(m => this.context.Add(m));
            this.context.SaveChanges();
            repositoryMaster = new RepositoryMaster(context);
            repository = new SessionUserRepository(repositoryMaster);
        }
        [TestMethod]
        public void TestIsCorrectTokenOk ()
        {
            Guid correctToken = sessions.First().Token;
            bool result = repository.IsCorrectToken(correctToken);
            Assert.IsTrue(result);
        }
    }
}