using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogicInterface;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApi.Controllers;

namespace WebApi.Test
{
    [TestClass]
    public class RegionControllerTest
    {
        private List<Region> regionToReturnEmpty;

         private List<Region> region;
        private List<Region> regionsToReturn;
        private Region regionId1;
        private Mock<IRegionLogic> mock;
        private RegionController controller ;

        [TestInitialize]
        public void initVariables()
        {
            regionsToReturn = new List<Region>()
            {
                new Region()
                {
                    Id = 1,
                    Name = "New region",
                    TouristPoints = null,
                },
                new Region()
                {
                    Id = 2,
                    Name = "Other region",
                    TouristPoints = null,
                },
                new Region()
                {
                    Id = 3,
                    Name = "And other region",
                    TouristPoints = null,
                },
                new Region()
                {
                    Id = 4,
                    Name = "And one more region",
                    TouristPoints = null,
                }
            };
            regionToReturnEmpty = new List<Region>();
            regionId1 = regionsToReturn.First();
            mock = new Mock<IRegionLogic>(MockBehavior.Strict);
            controller = new RegionController(mock.Object);
        }
         [TestMethod]
         public void TestGetAllRegionsOk()
        {
            mock.Setup(m => m.GetAll()).Returns(regionsToReturn);
            var result = controller.Get();
            var okResult = result as OkObjectResult;
            var regions = okResult.Value as IEnumerable<Region>;
            mock.VerifyAll();
            Assert.IsTrue(regionsToReturn.SequenceEqual(regions));
        }
        [TestMethod]
        public void TestGetAllEmptyRegions ()
        {
            var mock = new Mock<IRegionLogic>(MockBehavior.Strict);
             mock.Setup(m => m.GetAll()).Returns(regionToReturnEmpty);
             var controller = new RegionController(mock.Object);
             var result = controller.Get();
             var okResult = result as OkObjectResult;
             var regions = okResult.Value as IEnumerable<Region>;
             mock.VerifyAll();
             Assert.IsTrue(regionToReturnEmpty.SequenceEqual(regions));

        }
        [TestMethod]
         public void TestGetByOk()
        {
            int id = 1;
            regionId1 = regionsToReturn.First();
            mock.Setup(m => m.GetBy(id)).Returns(regionId1);
            var result = controller.GetBy(id);
            var okResult = result as OkObjectResult;
            var region = okResult.Value as Region;
            mock.VerifyAll();
            Assert.IsTrue(region.Equals(regionId1));
        }
         [TestMethod]
         public void TestGetByNotFoud ()
         {
            int id = 5;
            Region regionNull = null;
            mock.Setup(m => m.GetBy(id)).Returns(regionNull);
            var result = controller.GetBy(id);
            var okResult = result as OkObjectResult;
            var region = okResult.Value as Region;
            mock.VerifyAll();
            Assert.IsNull(region);
         }
         [TestMethod]
         public void TestPostOk ()
         {
            mock.Setup(m => m.Add(regionId1));
            var result = controller.Post(regionId1);
            var okResult = result as CreatedAtRouteResult;
            mock.VerifyAll();
            Assert.IsNotNull(okResult);
            Assert.AreEqual("Api", okResult.RouteName);
            Assert.AreEqual(okResult.Value, regionId1);
         }
         [TestMethod]
          public void TestPostFailSameRegion()
        {
            regionId1 = regionsToReturn.First();
            Exception exist = new AggregateException();
            mock.Setup(p => p.Add(regionId1)).Throws(exist);
            var result = controller.Post(regionId1);
            mock.VerifyAll();
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        [TestMethod]
          public void TestPostFailValidation()
        {
            regionId1 = regionsToReturn.First();
            Exception exist = new ArgumentException();
            mock.Setup(p => p.Add(regionId1)).Throws(exist);
            var result = controller.Post(regionId1);
            mock.VerifyAll();
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        [TestMethod]
        public void TestPostFailServer()
        {
            regionId1 = regionsToReturn.First();
            Exception exist = new Exception();
            mock.Setup(p => p.Add(regionId1)).Throws(exist);
            var result = controller.Post(regionId1);
            mock.VerifyAll();
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

    }
}