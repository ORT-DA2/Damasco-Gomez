using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessInterface.Repositories;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BusinessLogic.Tests.Test
{
    [TestClass]
    public class RegionLogicTest
    {
        private RegionLogic regionLogic; 
        private Mock<IRegionRepository> mock;
        private List<Region> regionsToReturn;
        private List<Region> regionsEmpty;

         [TestInitialize]
        public void Initialize ()
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
            mock = new Mock<IRegionRepository>(MockBehavior.Strict);
            regionLogic = new RegionLogic(mock.Object);
            regionsEmpty = new List<Region>();
        }
        [TestMethod]
        public void TestGetAll()
        {
            mock.Setup(m => m.GetElements()).Returns(regionsToReturn);
            var result = regionLogic.GetAll();
            mock.VerifyAll();
            Assert.IsTrue(result.SequenceEqual(regionsToReturn));
        }
        [TestMethod]
        public void TestGetEmptyGetAll()
        {
            List<Region> regionEmpty = new List<Region>();
            mock.Setup(m => m.GetElements()).Returns(regionEmpty);
            var result = regionLogic.GetAll();
            mock.VerifyAll();
            Assert.AreEqual(regionEmpty, result);
        }
        [TestMethod]
        public void TestAdd()
        {
            Region region = regionsToReturn.First();
            mock.Setup(m => m.Add(region)).Returns(region);
            var regionToReturn = regionLogic.Add(region);
            mock.VerifyAll();
            Assert.AreEqual(region, regionToReturn );
        }
         [TestMethod]
        public void TestAddValidateError()
        {
            Region region = regionsToReturn.First(); // esta region tiene que terner un formato erroneo despues para que la validación falle
            mock.Setup(m => m.Add(region)).Returns(region);
            mock.VerifyAll();

            var regionToReturn = regionLogic.Add(region);

            Assert.AreEqual(region, regionToReturn); 
        }
        [TestMethod]
         [ExpectedException(typeof(ArgumentException))]
        public void TestAddExistError()
        {
            Region region = regionsToReturn.First();
            ArgumentException exception = new ArgumentException();
            mock.Setup(m => m.Add(region)).Throws(exception);

            var regionToReturn = regionLogic.Add(region);
        }

    }
}