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

            Region.Update(region,newRegion);

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

            Region.Update(region,newRegion);

            Assert.AreEqual(nameShouldBe, region.Name);
        }
    }
}