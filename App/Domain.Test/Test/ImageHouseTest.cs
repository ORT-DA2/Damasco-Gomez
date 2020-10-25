using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.Test.Test
{
    [TestClass]
    public class ImageHouseTest
    {
        public ImageHouse image;
        [TestInitialize]
        public void SetUp()
        {
            image = new ImageHouse()
                {
                    Id = 2,
                    Name = "image.png",
                };
        }
        [TestMethod]
        public void TestUpdateName()
        {
            ImageHouse newImage = new ImageHouse()
            {
                Name = "otherImage.png",
            };

            image.Update(newImage);

            Assert.AreEqual(newImage.Name, image.Name);
        }
        [TestMethod]
        public void TestUpdateNameEmpty()
        {
            string nameShouldBe = image.Name;
            ImageHouse newImage = new ImageHouse()
                {
                    Name = null,
                };

            image.Update(newImage);

            Assert.AreEqual(nameShouldBe, image.Name);
        }
    }
}