using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.Test.Test
{
    [TestClass]
    public class RegionTest
    {
        public Region region;
        [TestInitialize]
        public void SetUp()
        {
            region = new Region()
                {
                    Id = 2,
                    Name = "Other region",
                };
        }
        [TestMethod]
        public void TestUpdateName()
        {
            Region newRegion = new Region()
                {
                    Name = "new name region",
                };

            region.Update(newRegion);

            Assert.AreEqual(newRegion.Name, region.Name);
        }
        [TestMethod]
        public void TestUpdateNameEmpty()
        {
            string nameShouldBe = region.Name;
            Region newRegion = new Region()
                {
                    Name = null,
                };

            region.Update(newRegion);

            Assert.AreEqual(nameShouldBe, region.Name);
        }
        [TestMethod]
        public void TestUpdateTouristPoints()
        {
            List<TouristPoint> listTouristPoint = new List<TouristPoint>();
            Region newRegion = new Region()
                {
                    Name = null,
                    TouristPoints = listTouristPoint
                };

            region.Update(newRegion);

            Assert.AreEqual(listTouristPoint, region.TouristPoints);
        }
        [TestMethod]
        public void TestUpdateTouristPointsNull()
        {
            List<TouristPoint> listTouristPoint = null;
            Region newRegion = new Region()
                {
                    Name = null,
                    TouristPoints = listTouristPoint
                };

            region.Update(newRegion);

            Assert.IsNull(region.TouristPoints);
        }
    }
}