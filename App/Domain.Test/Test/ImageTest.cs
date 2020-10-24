using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.Test.Test
{
    [TestClass]
    public class ImageTest
    {
        public Image image;
        [TestInitialize]
        public void SetUp()
        {
            image = new Image()
                {
                    Id = 2,
                    Name = "image.png",
                };
        }
        [TestMethod]
        public void TestUpdateName()
        {
            Image newImage = new Image()
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
            Image newImage = new Image()
                {
                    Name = null,
                };

            image.Update(newImage);

            Assert.AreEqual(nameShouldBe, image.Name);
        }
    }
}