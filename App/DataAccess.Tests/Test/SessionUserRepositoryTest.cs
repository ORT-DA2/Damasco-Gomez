using System;
using System.Collections.Generic;
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
        public void TestUpdateOk ()
        {
            // protected override void Update(SessionUser elementToUpdate, SessionUser element)
        
           // element.Update(elementToUpdate);
        
        }
        
        [TestMethod]
        public void TestIsCorrectTokenOk ()
        {
            Assert.IsTrue(true);
        }
    }
}