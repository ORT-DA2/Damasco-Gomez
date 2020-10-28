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
        private Report report1;
        private Mock<IReportLogic> mock;
        private ReportController controller ;
        [TestInitialize]
        public void initVariables()
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
            report1 = reportsToReturn.First();
            mock = new Mock<IReportLogic>(MockBehavior.Strict);
            controller = new ReportController(mock.Object);
        }
        [TestMethod]
        public void TestGetHousesReportByOk()
        {
            ReportTouristPointModel reportTouristPointModel = new ReportTouristPointModel ()
            {
                IdTp = 1,
                DateFrom= "01/12/2020",
                DateOut= "31/12/2020",
            };
            ReportTouristPoint  reportTouristPoint= reportTouristPointModel.ToEntity();
            IEnumerable<ReportHousesBasicModel> reportsBasic = reportsToReturn.Select(m => new ReportHousesBasicModel(m));

            mock.Setup(m => m.GetHousesReportBy(It.IsAny<ReportTouristPoint>())).Returns(reportsToReturn);
        
            var result = controller.GetHousesReportBy(reportTouristPointModel);

            var okResult = result as OkObjectResult;
            var reports = okResult.Value as IEnumerable<ReportHousesBasicModel>;
            mock.VerifyAll();
            Assert.IsTrue(reportsBasic.SequenceEqual(reports));

        }
        [TestMethod]
        public void TestGetHousesReportByNullResult()
        {
            ReportTouristPointModel reportTouristPointModel = new ReportTouristPointModel ()
            {
                IdTp = 1,
                DateFrom= "01/12/2020",
                DateOut= "31/12/2020",
            };
            List <Report> reportsToReturnEmpty = new List<Report>();
            ReportTouristPoint  reportTouristPoint= reportTouristPointModel.ToEntity();
            IEnumerable<ReportHousesBasicModel> reportsBasic = new List<ReportHousesBasicModel>(){}; 

            mock.Setup(m => m.GetHousesReportBy(It.IsAny<ReportTouristPoint>())).Returns(reportsToReturnEmpty);
        
            var result = controller.GetHousesReportBy(reportTouristPointModel);

            var okResult = result as OkObjectResult;
            var reports = okResult.Value as IEnumerable<ReportHousesBasicModel>;
            mock.VerifyAll();
            Assert.IsTrue(reportsBasic.SequenceEqual(reports));
        }
    }
}