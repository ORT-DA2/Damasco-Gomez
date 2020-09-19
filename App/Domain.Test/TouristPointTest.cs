using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.Test
{
    [TestClass]
    public class TouristPointTest
    {
        [TestMethod]
        public void TestUdpateImge()
        {
            Image newImage = new Image ();
            TouristPoint  touristPoint = new TouristPoint();
            touristPoint.UpdateImage(newImage);
            Image realImage = touristPoint.Image();
            assertEquals(realImage, newImage);
        }
        [TestMethod]
        public void TestUdpateDescription()
        {
            string newDescription = "Un lugar paridisíaco";
            TouristPoint  touristPoint = new TouristPoint();
            touristPoint.UpdateDescription(newDescription);
            string realDescription = touristPoint.Description();
            assertEquals(realDescription , newDescription);


        }
          [TestMethod]
        public void TestUdpateName()
        {
            string newName = "Yuliana";
            TouristPoint touristPoint = new TouristPoint();
            touristPoint.UdpateName(newName);
            string realName = touristPoint.Name();
            assertEquals(realName , newName);
        }
    }
}
