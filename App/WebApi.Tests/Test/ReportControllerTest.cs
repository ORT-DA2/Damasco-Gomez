using System.Collections.Generic;
using System.Linq;
using BusinessLogicInterface.Interfaces;
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
    public class ReportControllerTest
    {
        private List<Report> reportsToReturn;
        private List<Report> reportsToReturnEmpty;
        private Report report;
        private Mock<IReportLogic> mockReportLogic;
        private ReportController controllerReport;
        [TestInitialize]
        public void InitVariables()
        {
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
                        NameHouse = "Solanas Punta Del Este Spa & Resort",
                    }
            };
            reportsToReturnEmpty = new List<Report>();
            report = reportsToReturn.First();
            mockReportLogic = new Mock<IReportLogic>(MockBehavior.Strict);
            controllerReport = new ReportController(mockReportLogic.Object);
        }
        [TestMethod]
        public void TestGetHousesReportBookingWithId1ByOk()
        {
            ReportTouristPointModel reportTouristPointModel = new ReportTouristPointModel()
            {
                IdTouristPoint = 1,
                DateFrom = "01/01/2020",
                DateOut = "09/01/2020",
            };
            ReportTouristPoint reportTouristPoint = reportTouristPointModel.ToEntity();
            IEnumerable<ReportHousesBasicModel> reportsBasic = reportsToReturn.Select(m => new ReportHousesBasicModel(m));

            mockReportLogic.Setup(m => m.GetHousesReportBy(It.IsAny<ReportTouristPoint>())).Returns(reportsToReturn);

            var result = controllerReport.GetHousesReportBy(reportTouristPointModel);

            var okResult = result as OkObjectResult;
            var reports = okResult.Value as IEnumerable<ReportHousesBasicModel>;
            mockReportLogic.VerifyAll();
            Assert.IsTrue(reportsBasic.SequenceEqual(reports));

        }
        [TestMethod]
        public void TestGetHousesReportByOk()
        {
            ReportTouristPointModel reportTouristPointModel = new ReportTouristPointModel()
            {
                IdTouristPoint = 1,
                DateFrom = "01/12/2020",
                DateOut = "31/12/2020",
            };
            ReportTouristPoint reportTouristPoint = reportTouristPointModel.ToEntity();
            IEnumerable<ReportHousesBasicModel> reportsBasic = reportsToReturn.Select(m => new ReportHousesBasicModel(m));

            mockReportLogic.Setup(m => m.GetHousesReportBy(It.IsAny<ReportTouristPoint>())).Returns(reportsToReturn);

            var result = controllerReport.GetHousesReportBy(reportTouristPointModel);

            var okResult = result as OkObjectResult;
            var reports = okResult.Value as IEnumerable<ReportHousesBasicModel>;
            mockReportLogic.VerifyAll();
            Assert.IsTrue(reportsBasic.SequenceEqual(reports));

        }
        [TestMethod]
        public void TestGetHousesReportByNullResult()
        {
            ReportTouristPointModel reportTouristPointModel = new ReportTouristPointModel()
            {
                IdTouristPoint = 1,
                DateFrom = "01/12/2020",
                DateOut = "31/12/2020",
            };
            List<Report> reportsToReturnEmpty = new List<Report>();
            ReportTouristPoint reportTouristPoint = reportTouristPointModel.ToEntity();
            IEnumerable<ReportHousesBasicModel> reportsBasic = new List<ReportHousesBasicModel>() { };

            mockReportLogic.Setup(m => m.GetHousesReportBy(It.IsAny<ReportTouristPoint>())).Returns(reportsToReturnEmpty);

            var result = controllerReport.GetHousesReportBy(reportTouristPointModel);

            var okResult = result as OkObjectResult;
            var reports = okResult.Value as IEnumerable<ReportHousesBasicModel>;
            mockReportLogic.VerifyAll();
            Assert.IsTrue(reportsBasic.SequenceEqual(reports));
        }
    }
}