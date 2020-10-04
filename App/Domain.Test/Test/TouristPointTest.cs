using System;
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
                    Image = "mail2@mail.com",
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
                    Image = null,
                    Description = null,
                    RegionId = 0,
                };

            TouristPoint.Update(touristPoint,newTouristPoint);

            Assert.AreEqual(newTouristPoint.Name, touristPoint.Name);
        }
        [TestMethod]
        public void TestUpdateImage()
        {
            TouristPoint newTouristPoint = new TouristPoint()
                {
                    Name = null,
                    Image = "new image",
                    Description = null,
                    RegionId = 0,
                };

            TouristPoint.Update(touristPoint,newTouristPoint);

            Assert.AreEqual(newTouristPoint.Image, touristPoint.Image);
        }
        [TestMethod]
        public void TestUpdateDescription()
        {
            TouristPoint newTouristPoint = new TouristPoint()
                {
                    Name = null,
                    Image = null,
                    Description = "new description",
                    RegionId = 0,
                };

            TouristPoint.Update(touristPoint,newTouristPoint);

            Assert.AreEqual(newTouristPoint.Description, touristPoint.Description);
        }
        [TestMethod]
        public void TestUpdateRegionId()
        {
            TouristPoint newTouristPoint = new TouristPoint()
                {
                    Name = "",
                    Image = null,
                    Description = null,
                    RegionId = 330,
                };

            TouristPoint.Update(touristPoint,newTouristPoint);

            Assert.AreEqual(newTouristPoint.RegionId, touristPoint.RegionId);
        }
    }
}