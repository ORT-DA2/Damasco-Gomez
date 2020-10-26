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
    public class ReportLogicTest
    {
        private ReportLogic reportLogic; 
        private Mock<IReportRepository> mock;
        private List<Report> reportsToReturn;
        private List<Report> reportsEmpty;
        [TestInitialize]
            public void Initialize ()
            {
                reportsEmpty = new List<Report>();
                reportsToReturn = new List<Report>()
                {
                    new Report()
                    {
                        CantBookings = 1,
                        NameHouse = "Hotel L’Auberge",
                    },
                    new Report()
                    {
                        CantBookings = 2,
                        NameHouse = "Hotel del Lago Golf & Art Resort",
                    },
                    new Report()
                    {
                        CantBookings = 3,
                        NameHouse = "The Grand Hotel",
                    },
                    new Report()
                    {
                        CantBookings = 4,
                        NameHouse = "Solanas Punta Del Este Spa & Resort (",
                    }
                };
                mock = new Mock<IReportRepository>(MockBehavior.Strict);
                reportLogic = new RegionLogic(mock.Object);
                reportsEmpty = new List<Report>();
            }
        [TestMethod]
        public void TestGetHousesReportByOk ()
        {
            int idTP = 1;
            DateTime dateFrom = new DateTime(2020, 11, 29);
            DateTime dateOut = new DateTime(2020, 12, 20);
            mock.Setup(m => m.FilterCantBookigsByHouse(dateFrom,dateOut,idTP)).Returns(reportsToReturn);

            List<Report> result = reportLogic.GetHousesReportBy(dateFrom,dateOut,idTp);

            Assert.IsTrue(result.SequenceEqual(reportsToReturn));
        }
         [TestMethod]
        public void TestGetHousesReportByEmpty ()
        {
            int idTP = 1;
            DateTime dateFrom = new DateTime(2020, 11, 29);
            DateTime dateOut = new DateTime(2020, 12, 20);
            mock.Setup(m => m.FilterCantBookigsByHouse(dateFrom,dateOut,idTP)).Returns(reportsEmpty);

            List<Report> result = reportLogic.GetHousesReportBy(dateFrom,dateOut,idTP);

            Assert.IsTrue(result.SequenceEqual(reportsEmpty));
        }
    }
}