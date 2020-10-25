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
        public void TestFilterDatesInTheMiddleOk()
        {
            int idTP = 1;
            DateTime dateFrom = new DateTime(2020, 12, 03);
            DateTime dateOut = new DateTime(2020, 12, 20);
            DateTime checkIn = new DateTime(2020, 12, 01);
            DateTime checkOut = new DateTime(2020, 12, 31);
            var result = repository.FilterCantBookigsByHouse(dateFrom,dateOut, idTP);
            Assert.IsTrue(reportsToReturn.SequenceEqual(result));
        }
        public void TestFilterDatesLeftEdgeCaseDatesOk() 
        {
            int idTP = 1;
            DateTime dateFrom = new DateTime(2020, 11, 29);
            DateTime dateOut = new DateTime(2020, 12, 29);
            DateTime checkIn = new DateTime(2020, 12, 01);
            DateTime checkOut = new DateTime(2020, 12, 31);
            Assert.IsTrue(true);
        }
        public void TestFilterDatesRightEdgeCaseDatesOk() 
        {
            DateTime dateFrom = new DateTime(2020, 12, 15);
            DateTime dateOut = new DateTime(2021, 01, 02);
            DateTime checkIn = new DateTime(2020, 12, 01);
            DateTime checkOut = new DateTime(2020, 12, 31);
             Assert.IsTrue(true);
        }
        public void TestFilterDatesNotOk() 
        {
           /* DateTime dateFrom = new DateTime(2020, 12, 15);
            DateTime dateOut = new DateTime(2021, 01, 02);
            DateTime checkIn = new DateTime(2020, 12, 01);
            DateTime checkOut = new DateTime(2020, 12, 31);
             */
            Assert.IsTrue(true);
        }
        public void TestFilterSatateNotOk() 
        {
           /* DateTime dateFrom = new DateTime(2020, 12, 15);
            DateTime dateOut = new DateTime(2021, 01, 02);
            DateTime checkIn = new DateTime(2020, 12, 01);
            DateTime checkOut = new DateTime(2020, 12, 31);
             */
            Assert.IsTrue(true);
        }
         public void TestFilterSatateNotOk2() 
        {
           /* DateTime dateFrom = new DateTime(2020, 12, 15);
            DateTime dateOut = new DateTime(2021, 01, 02);
            DateTime checkIn = new DateTime(2020, 12, 01);
            DateTime checkOut = new DateTime(2020, 12, 31);
             */
            Assert.IsTrue(true);
        }
   
    
    }
    
}