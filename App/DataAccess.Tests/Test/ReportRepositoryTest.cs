using System.Collections.Generic;
using DataAccess.Context;
using DataAccess.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataAccess.Tests.Test
{
    [TestClass]
    public class ReportRepositoryTest
    {
        private List<Report> reportsToReturn;
        private DbContext context;
        private DbContextOptions options;
        private ReportRepository repository;
        
        [TestInitialize]
        public void Setup()
        {
            this.options = new DbContextOptionsBuilder<VidlyContext>().UseInMemoryDatabase(databaseName: "VidlyDBtest").Options;
            this.context = new VidlyContext(this.options);
            reportsToReturn = new List<Report>()
            {
                new Report()
                {
                    CantBookings = 10,
                    NameHouse = "Hotel L’Auberge",
                },
                new Report()
                {
                    CantBookings = 6,
                    NameHouse = "The Grand Hotel",
                },
                 new Report()
                {
                    CantBookings = 6,
                    NameHouse = "Solanas Punta Del Este Spa & Resort",
                },
                 new Report()
                {
                    CantBookings = 3,
                    NameHouse = "Hotel del Lago Golf & Art Resort",
                },
                 new Report()
                {
                    CantBookings = 0,
                    NameHouse = "Hotel Arenas",
                }
            };

            reportsToReturn.ForEach(m => this.context.Add(m));
            this.context.SaveChanges();
            repository = new ReportRepository(context);
        }
        [TestCleanup]
        public void TestCleanup()
        {
            this.context.Database.EnsureDeleted();
        }
        [TestMethod]
        public void TestFilterCantBookigsByHouse ()
        {

            Assert.IsTrue(true);
        }
    }
}