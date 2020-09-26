using System.Collections.Generic;
using System.Linq;
using DataAccessInterface.Repositories;
using Domain;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BusinessLogic.Tests.Test
{
    [TestClass]
    public class TouristPointLogicTest
    {
        private TouristPointLogic touristPointLogic ;

        private List<CategoryTouristPoint> categoriesTouristPoints ;

        private Mock<ITouristPointRepository> mock;

        private List<TouristPoint> touristPoints;

        [TestInitialize]
        void Initialize ()
        {

             touristPoints = new List<TouristPoint>()
            {
                new TouristPoint()
                {
                    Id = 1,
                    Name = "New pointTurist",
                    Image = null,
                    Description = "one",
                    RegionId = 3,
                    Region = null,
                    CategoriesTouristPoints = null,
                },
                new TouristPoint()
                {
                    Id = 2,
                    Name = "Other pointTurist",
                    Image = null,
                    Description = "two",
                    RegionId = 1,
                    Region = null,
                     CategoriesTouristPoints = null,
                },
                new TouristPoint()
                {
                    Id = 3,
                    Name = "And other pointTurist",
                    Image = null,
                    Description = "three",
                    RegionId = 1,
                    Region = null,
                    CategoriesTouristPoints = null,
                },
                new TouristPoint()
                {
                    Id = 4,
                    Name = "And one more pointTurist",
                    Image = null,
                    Description = "four",
                    RegionId = 2,
                    Region = null,
                    CategoriesTouristPoints = null,
                }
            };
             mock = new Mock<ITouristPointRepository>(MockBehavior.Strict);
             touristPointLogic = new TouristPointLogic(mock.Object);
        }
       [TestMethod]
        public void TestGetAll ()
        {
            mock.Setup(m => m.GetElements()).Returns(touristPoints);
            var result = touristPointLogic.GetAll();
            var okResult = result as OkObjectResult;
            var touristPonits = okResult.Value as TouristPointLogic;
            mock.VerifyAll();
            Assert.IsTrue(touristPonits.Equals(touristPoints));
        }

    }
}