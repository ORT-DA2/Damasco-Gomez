using System.Collections.Generic;
using BusinessLogicInterface ;
using Domain;

namespace WebApi.Test
{
    [TessClass]

   
    public class RegionControllerTest
    {
         [TestMethod]
         public void TestGetRegionsOk()
         {
           List<Region> regionsToReturn = new List<Region> ();
           new Region () 
           {
               Id = 1,
               Name = "CentroSur",
               List<TouristPoint> TestTouristPointController = null,


           }
           new Region () 
           {
               Id = 2,
               Name = "Costanera",
               List<TouristPoint> TestTouristPointController = new List <TouristPoint>(),

           }
           var mock = new Mock <IRegionLogic> (MockBehavior.Strict);
           mock.Setup(mock => mock.GetAll()).Returns(regionsToReturn);
           var controller = new RegionController (mock.Object);
           var result = controller.Get();
           var okResult = result as OkObjectResult;
           var regions = okResult.Value as IEnumerable<Region>;
           mock.VerfyAll();
           Assert.IsTrue(regionsToReturn.SequenceEqual(regions));
         }

    }
}