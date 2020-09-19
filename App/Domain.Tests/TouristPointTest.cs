using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Domain.Tests
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
        }
         [TestMethod]
        public void TestUdpateName()
        {
        }
    }
}
