using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.Test.Test
{
    [TestClass]
    public class ImageTouristPointTest
    {
        public ImageTouristPoint image;
        public TouristPoint touristPoint;
        [TestInitialize]
        public void SetUp()
        {
            touristPoint = new TouristPoint(){Id = 1};
            image = new ImageTouristPoint("image.png");
        }
        [TestMethod]
        public void TestUpdateName()
        {
            ImageTouristPoint newImage = new ImageTouristPoint("otherImage.png");

            image.Update(newImage);

            Assert.AreEqual(newImage.Name, image.Name);
        }
        [TestMethod]
        public void TestUpdateNameEmpty()
        {
            image = new ImageTouristPoint("Name");
            string nameShouldBe = image.Name;
            ImageTouristPoint newImage = new ImageTouristPoint("");

            image.Update(newImage);

            Assert.AreEqual(nameShouldBe, image.Name);
        }
    }
}