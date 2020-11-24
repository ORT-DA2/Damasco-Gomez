using System;
using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.Test.Test
{
    [TestClass]
    public class ImageHouseTest
    {
        public ImageHouse image;
        public House house;
        [TestInitialize]
        public void SetUp()
        {
            house = new House() {Id = 1, Name = "Name  house"};
            image = new ImageHouse("image.png",house.Id);
        }
        [TestMethod]
        public void TestUpdateName()
        {
            string nameImage = "otherImage.png";
            ImageHouse newImage = new ImageHouse(nameImage, house.Id);

            image.Update(newImage);

            Assert.AreEqual(newImage.Name, nameImage);
        }
        [TestMethod]
        public void TestUpdateNameNull()
        {
            image = new ImageHouse("NameImage.png",house.Id);
            string nameShouldBe = image.Name;
            ImageHouse newImage = new ImageHouse("Other.png", house.Id){Name=null};

            image.Update(newImage);

            Assert.AreEqual(nameShouldBe, image.Name);
        }
        [TestMethod]
        public void TestGetExtention()
        {
            string nameImage = "otherImage.png";
            string extention = "png";

            ImageHouse newImage = new ImageHouse(nameImage, house.Id);

            Assert.AreEqual(newImage.Extention,extention);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGetExtentionFail()
        {
            string nameImage = "otherImage";

            ImageHouse newImage = new ImageHouse(nameImage, house.Id);
        }
    }
}