using System.Collections.Generic;
using BusinessLogicInterface;
using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BusinessLogic.Tests.Test
{
    [TestClass]
    public class TouristPointLogicTest
    {
        private TouristPointLogic touristPointLogic ; 

        List<CategoryTouristPoint> categoriesTouristPoints ;

        private Mock<ITouristPointLogic> mock;
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
             mock = new Mock<ITouristPointLogic>(MockBehavior.Strict);
             touristPointLogic = new TouristPointLogic(mock.Object);
        }
       [TestMethod]
        public void TestGetAll ()
        {
            id =1;
            var touristPointToReturn = touristPoints.First();
            mock.Setup(m => m.Add(id)).Returns(touristPointToReturn);
            var result = touristPointLogic.GetAll();
            var okResult = result as OkObjectResult;
            var touristPonits = okResult.Value as TouristPointLogic;
            mock.VerifyAll();
            Assert.IsTrue(touristPonits.Equals(touristPointToReturn));
        }

    }
}