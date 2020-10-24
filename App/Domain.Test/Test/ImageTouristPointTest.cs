using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.Test.Test
{
    [TestClass]
    public class ImageTouristPointTest
    {
        public ImageTouristPoint image;
        [TestInitialize]
        public void SetUp()
        {
            image = new ImageTouristPoint()
                {
                    Id = 2,
                    Name = "image.png",
                };
        }
        [TestMethod]
        public void TestUpdateName()
        {
            ImageTouristPoint newImage = new ImageTouristPoint()
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
            ImageTouristPoint newImage = new ImageTouristPoint()
                {
                    Name = null,
                };

            image.Update(newImage);

            Assert.AreEqual(nameShouldBe, image.Name);
        }
    }
}