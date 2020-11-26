using System;
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
        public void TestUpdateNameNull()
        {
            image = new ImageTouristPoint("Name.png");
            string nameShouldBe = image.Name;
            ImageTouristPoint newImage = new ImageTouristPoint("NameTwo.png"){Name = null};

            image.Update(newImage);

            Assert.AreEqual(nameShouldBe, image.Name);
        }
        [TestMethod]
        public void TestGetExtention()
        {
            string nameImage = "otherImage.png";
            string extention = "png";

            ImageTouristPoint newImage = new ImageTouristPoint(nameImage);

            Assert.AreEqual(newImage.Extention,extention);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGetExtentionFail()
        {
            string nameImage = "otherImage";

            ImageTouristPoint newImage = new ImageTouristPoint(nameImage);
        }
    }
}