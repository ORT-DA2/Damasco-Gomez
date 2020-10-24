using System.Collections.Generic;
using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.Test.Test
{
    [TestClass]
    public class TouristPointTest
    {
        public TouristPoint touristPoint;
        [TestInitialize]
        public void SetUp()
        {
            touristPoint = new TouristPoint()
                {
                    Id = 2,
                    Name = "Other touristPoint",
                    Description = "Passed",
                    RegionId = 200,
                };
        }
        [TestMethod]
        public void TestUpdateName()
        {
            TouristPoint newTouristPoint = new TouristPoint()
                {
                    Name = "new name touristPoint",
                    ImageTouristPoint = null,
                    Description = null,
                    RegionId = 0,
                };

            touristPoint.Update(newTouristPoint);

            Assert.AreEqual(newTouristPoint.Name, touristPoint.Name);
        }
        [TestMethod]
        public void TestUpdateImageTouristPoint()
        {
            TouristPoint newTouristPoint = new TouristPoint()
                {
                    Name = null,
                    // ImageTouristPoint = "new image",
                    Description = null,
                    RegionId = 0,
                };

            touristPoint.Update(newTouristPoint);

            Assert.AreEqual(newTouristPoint.ImageTouristPoint, touristPoint.ImageTouristPoint);
        }
        [TestMethod]
        public void TestUpdateDescription()
        {
            TouristPoint newTouristPoint = new TouristPoint()
                {
                    Name = null,
                    ImageTouristPoint = null,
                    Description = "new description",
                    RegionId = 0,
                };

            touristPoint.Update(newTouristPoint);

            Assert.AreEqual(newTouristPoint.Description, touristPoint.Description);
        }
        [TestMethod]
        public void TestUpdateRegionId()
        {
            TouristPoint newTouristPoint = new TouristPoint()
                {
                    Name = "",
                    ImageTouristPoint = null,
                    Description = null,
                    RegionId = 330,
                };

            touristPoint.Update(newTouristPoint);

            Assert.AreEqual(newTouristPoint.RegionId, touristPoint.RegionId);
        }
        [TestMethod]
        public void TestGetId()
        {
            int id = 1;

            TouristPoint newTouristPoint = new TouristPoint()
            {
                Id = id,
                Name = "",
                ImageTouristPoint = null,
                Description = null,
                RegionId = 330,
            };

            Assert.AreEqual(id, newTouristPoint.Id);
        }
        [TestMethod]
        public void TestGetRegion()
        {
            Region region = new Region();

            TouristPoint newTouristPoint = new TouristPoint()
            {
                Region = region,
                Name = "",
                ImageTouristPoint = null,
                Description = null,
                RegionId = 330,
            };

            Assert.AreEqual(region, newTouristPoint.Region);
        }
        [TestMethod]
        public void TestGetCategories()
        {
            List<CategoryTouristPoint> categories = new List<CategoryTouristPoint>() { };

            TouristPoint newTouristPoint = new TouristPoint()
            {
                CategoriesTouristPoints = categories,
                Name = "",
                ImageTouristPoint = null,
                Description = null,
                RegionId = 330,
            };

            Assert.AreEqual(categories, newTouristPoint.CategoriesTouristPoints);
        }
    }
}