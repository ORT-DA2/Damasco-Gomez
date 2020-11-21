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
        public void TestUpdateNameEmpty()
        {
            image = new ImageHouse("NameImage",house.Id);
            string nameShouldBe = image.Name;
            ImageHouse newImage = new ImageHouse("", house.Id);

            image.Update(newImage);

            Assert.AreEqual(nameShouldBe, image.Name);
        }
    }
}