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
            regionId1 = regionsToReturn.First();
            mock = new Mock<IRegionLogic>(MockBehavior.Strict);
            controller = new RegionController(mock.Object);
        }
        [TestMethod]
        public void TestGetAllRegionsOk()
        {
            mock.Setup(m => m.GetAll()).Returns(regionsToReturn);
            IEnumerable<RegionDetailModel> regionsBasic = regionsToReturn.Select(m => new RegionDetailModel(m));

            var result = controller.Get();

            var okResult = result as OkObjectResult;
            var regions = okResult.Value as IEnumerable<RegionDetailModel>;
            mock.VerifyAll();
            Assert.IsTrue(regionsBasic.SequenceEqual(regions));
        }

        [TestMethod]
        public void TestGetAllEmptyRegions ()
        {
            var mock = new Mock<IRegionLogic>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll()).Returns(regionToReturnEmpty);
            IEnumerable<RegionDetailModel> regionsBasic = regionToReturnEmpty.Select(m => new RegionDetailModel(m));
            var controller = new RegionController(mock.Object);

            var result = controller.Get();

            var okResult = result as OkObjectResult;
            var regions = okResult.Value as IEnumerable<RegionDetailModel>;
            mock.VerifyAll();
            Assert.IsTrue(regionsBasic.SequenceEqual(regions));

        }
        [TestMethod]
        public void TestGetByOk()
        {
            int id = 1;
            regionId1 = regionsToReturn.First();
            mock.Setup(m => m.GetBy(id)).Returns(regionId1);
            RegionDetailModel regionsBasic = new RegionDetailModel(regionId1);

            var result = controller.GetBy(id);

            var okResult = result as OkObjectResult;
            var region = okResult.Value as RegionDetailModel;
            mock.VerifyAll();
            Assert.IsTrue(region.Equals(regionsBasic));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGetByNotFoud ()
        {
            int id = 4;
            ArgumentException exist = new ArgumentException();
            mock.Setup(m => m.GetBy(id)).Throws(exist);

            var result = controller.GetBy(id);

            mock.VerifyAll();
        }
        [TestMethod]
        public void TestPostOk ()
        {
            RegionModel regionModel = new RegionModel()
            {
                Name = "name region",
            };
            regionId1 = regionModel.ToEntity();
            mock.Setup(m => m.Add(regionId1)).Returns(regionId1);
            RegionDetailModel regionsBasic = new RegionDetailModel(regionId1);

            var result = controller.Post(regionModel);

            var okResult = result as CreatedAtRouteResult;
            mock.VerifyAll();
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
            regionId1 = regionModel.ToEntity();
            Exception exist = new AggregateException();
            mock.Setup(p => p.Add(regionId1)).Throws(exist);

            var result = controller.Post(regionModel);

            mock.VerifyAll();
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPostFailValidation()
        {
            RegionModel regionModel = new RegionModel()
            {
                Name = "name region",
            };
            regionId1 = regionModel.ToEntity();
            Exception exist = new ArgumentException();
            mock.Setup(p => p.Add(regionId1)).Throws(exist);

            var result = controller.Post(regionModel);

            mock.VerifyAll();
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestPostFailServer()
        {
            RegionModel regionModel = new RegionModel()
            {
                Name = "name region",
            };
            regionId1 = regionModel.ToEntity();
            Exception exist = new Exception();
            mock.Setup(p => p.Add(regionId1)).Throws(exist);

            var result = controller.Post(regionModel);

            mock.VerifyAll();
        }
        [TestMethod]
        public void TestPutOk()
        {
            RegionModel regionModel = new RegionModel()
            {
                Name = "name region",
            };
            regionId1 = regionModel.ToEntity();
            RegionDetailModel regionsBasic = new RegionDetailModel(regionId1);
            mock.Setup(m => m.Update(regionId1.Id,regionId1)).Returns(regionId1);

            var result = controller.Put(regionId1.Id, regionModel);

            var okResult = result as CreatedAtRouteResult;
            mock.VerifyAll();
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
            regionId1 = regionModel.ToEntity();
            Exception exist = new ArgumentException();
            mock.Setup(p => p.Update(regionId1.Id,regionId1)).Throws(exist);

            var result = controller.Put(regionId1.Id, regionModel);

            mock.VerifyAll();
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestPutFailServer()
        {
            RegionModel regionModel = new RegionModel()
            {
                Name = "name region",
            };
            regionId1 = regionModel.ToEntity();
            Exception exist = new Exception();
            mock.Setup(p => p.Update(regionId1.Id,regionId1)).Throws(exist);

            var result = controller.Put(regionId1.Id, regionModel);

            mock.VerifyAll();
        }
        [TestMethod]
        public void TestDeleteWithId()
        {
            Region region = regionsToReturn.First();
            mock.Setup(m => m.GetBy(region.Id)).Returns(region);
            mock.Setup(mock=> mock.Delete(region.Id));

            var result = controller.Delete(region.Id);

            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestDeleteWithIdNotFound()
        {
            Region region = regionsToReturn.First();
            Region regionNull = null;
            mock.Setup(m => m.GetBy(region.Id)).Returns(regionNull);
            mock.Setup(mock=> mock.Delete(region.Id));

            var result = controller.Delete(region.Id);
        }
        [TestMethod]
        public void TestDelete()
        {
            mock.Setup(mock=> mock.Delete());
            
            var result = controller.Delete();

            Assert.IsNotNull(result);
        }

    }
}