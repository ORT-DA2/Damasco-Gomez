using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogicInterface;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.In;
using Model.Out;
using Moq;
using WebApi.Controllers;

namespace WebApi.Test
{
    [TestClass]
    public class RegionControllerTest
    {
        private List<Region> regionToReturnEmpty;
        private List<Region> regionsToReturn;
        private Region regionWithId1;
        private Mock<IRegionLogic> mockRegionLogic;
        private RegionController controllerRegion ;

        [TestInitialize]
        public void InitVariables()
        {
            regionsToReturn = new List<Region>()
            {
                new Region()
                {
                    Id = 1,
                    Name = "New region",
                },
                new Region()
                {
                    Id = 2,
                    Name = "Other region",
                },
                new Region()
                {
                    Id = 3,
                    Name = "And other region",
                },
                new Region()
                {
                    Id = 4,
                    Name = "And one more region",
                }
            };
            regionToReturnEmpty = new List<Region>();
            regionWithId1 = regionsToReturn.First();
            mockRegionLogic = new Mock<IRegionLogic>(MockBehavior.Strict);
            controllerRegion = new RegionController(mockRegionLogic.Object);
        }
        [TestMethod]
        public void TestGetAllRegionsOk()
        {
            mockRegionLogic.Setup(m => m.GetAll()).Returns(regionsToReturn);
            IEnumerable<RegionDetailModel> regionsBasic = regionsToReturn.Select(m => new RegionDetailModel(m));

            var result = controllerRegion.Get();

            var okResult = result as OkObjectResult;
            var regions = okResult.Value as IEnumerable<RegionDetailModel>;
            mockRegionLogic.VerifyAll();
            Assert.IsTrue(regionsBasic.SequenceEqual(regions));
        }

        [TestMethod]
        public void TestGetAllEmptyRegions ()
        {
            var mockRegionLogic = new Mock<IRegionLogic>(MockBehavior.Strict);
            mockRegionLogic.Setup(m => m.GetAll()).Returns(regionToReturnEmpty);
            IEnumerable<RegionDetailModel> regionsBasic = regionToReturnEmpty.Select(m => new RegionDetailModel(m));
            var controllerRegion = new RegionController(mockRegionLogic.Object);

            var result = controllerRegion.Get();

            var okResult = result as OkObjectResult;
            var regions = okResult.Value as IEnumerable<RegionDetailModel>;
            mockRegionLogic.VerifyAll();
            Assert.IsTrue(regionsBasic.SequenceEqual(regions));

        }
        [TestMethod]
        public void TestGetByOk()
        {
            int id = 1;
            regionWithId1 = regionsToReturn.First();
            mockRegionLogic.Setup(m => m.GetBy(id)).Returns(regionWithId1);
            RegionDetailModel regionsBasic = new RegionDetailModel(regionWithId1);

            var result = controllerRegion.GetBy(id);

            var okResult = result as OkObjectResult;
            var region = okResult.Value as RegionDetailModel;
            mockRegionLogic.VerifyAll();
            Assert.IsTrue(region.Equals(regionsBasic));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGetByNotFoud ()
        {
            int id = 4;
            ArgumentException exist = new ArgumentException();
            mockRegionLogic.Setup(m => m.GetBy(id)).Throws(exist);

            var result = controllerRegion.GetBy(id);

            mockRegionLogic.VerifyAll();
        }
        [TestMethod]
        public void TestPostOk ()
        {
            RegionModel regionModel = new RegionModel()
            {
                Name = "name region",
            };
            regionWithId1 = regionModel.ToEntity();
            mockRegionLogic.Setup(m => m.Add(regionWithId1)).Returns(regionWithId1);
            RegionDetailModel regionsBasic = new RegionDetailModel(regionWithId1);

            var result = controllerRegion.Post(regionModel);

            var okResult = result as CreatedAtRouteResult;
            mockRegionLogic.VerifyAll();
            Assert.IsNotNull(okResult);
            Assert.AreEqual("GetRegion", okResult.RouteName);
            Assert.AreEqual(okResult.Value, regionsBasic);
        }
        [TestMethod]
        [ExpectedException(typeof(AggregateException))]
        public void TestPostFailSameRegion()
        {
            RegionModel regionModel = new RegionModel()
            {
                Name = "name region",
            };
            regionWithId1 = regionModel.ToEntity();
            Exception exist = new AggregateException();
            mockRegionLogic.Setup(p => p.Add(regionWithId1)).Throws(exist);

            var result = controllerRegion.Post(regionModel);

            mockRegionLogic.VerifyAll();
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPostFailValidation()
        {
            RegionModel regionModel = new RegionModel()
            {
                Name = "name region",
            };
            regionWithId1 = regionModel.ToEntity();
            Exception exist = new ArgumentException();
            mockRegionLogic.Setup(p => p.Add(regionWithId1)).Throws(exist);

            var result = controllerRegion.Post(regionModel);

            mockRegionLogic.VerifyAll();
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestPostFailServer()
        {
            RegionModel regionModel = new RegionModel()
            {
                Name = "name region",
            };
            regionWithId1 = regionModel.ToEntity();
            Exception exist = new Exception();
            mockRegionLogic.Setup(p => p.Add(regionWithId1)).Throws(exist);

            var result = controllerRegion.Post(regionModel);

            mockRegionLogic.VerifyAll();
        }
        [TestMethod]
        public void TestPutOk()
        {
            RegionModel regionModel = new RegionModel()
            {
                Name = "name region",
            };
            regionWithId1 = regionModel.ToEntity();
            RegionDetailModel regionsBasic = new RegionDetailModel(regionWithId1);
            mockRegionLogic.Setup(m => m.Update(regionWithId1.Id,regionWithId1)).Returns(regionWithId1);

            var result = controllerRegion.Put(regionWithId1.Id, regionModel);

            var okResult = result as CreatedAtRouteResult;
            mockRegionLogic.VerifyAll();
            Assert.IsNotNull(okResult);
            Assert.AreEqual("GetRegion", okResult.RouteName);
            Assert.AreEqual(okResult.Value, regionsBasic);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPutFailValidate()
        {
            RegionModel regionModel = new RegionModel()
            {
                Name = "name region",
            };
            regionWithId1 = regionModel.ToEntity();
            Exception exist = new ArgumentException();
            mockRegionLogic.Setup(p => p.Update(regionWithId1.Id,regionWithId1)).Throws(exist);

            var result = controllerRegion.Put(regionWithId1.Id, regionModel);

            mockRegionLogic.VerifyAll();
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestPutFailServer()
        {
            RegionModel regionModel = new RegionModel()
            {
                Name = "name region",
            };
            regionWithId1 = regionModel.ToEntity();
            Exception exist = new Exception();
            mockRegionLogic.Setup(p => p.Update(regionWithId1.Id,regionWithId1)).Throws(exist);

            var result = controllerRegion.Put(regionWithId1.Id, regionModel);

            mockRegionLogic.VerifyAll();
        }
        [TestMethod]
        public void TestDeleteWithId()
        {
            Region region = regionsToReturn.First();
            mockRegionLogic.Setup(m => m.GetBy(region.Id)).Returns(region);
            mockRegionLogic.Setup(mockRegionLogic=> mockRegionLogic.Delete(region.Id));

            var result = controllerRegion.Delete(region.Id);

            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestDeleteWithIdNotFound()
        {
            Region region = regionsToReturn.First();
            Region regionNull = null;
            mockRegionLogic.Setup(m => m.GetBy(region.Id)).Returns(regionNull);
            mockRegionLogic.Setup(mockRegionLogic=> mockRegionLogic.Delete(region.Id));

            var result = controllerRegion.Delete(region.Id);
        }
        [TestMethod]
        public void TestDelete()
        {
            mockRegionLogic.Setup(mockRegionLogic=> mockRegionLogic.Delete());
            
            var result = controllerRegion.Delete();

            Assert.IsNotNull(result);
        }

    }
}