using System.Collections.Generic;
using System.Linq;
using BusinessLogicInterface;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApi.Controllers;

namespace WebApi.Test
{
    [TestClass] 
    public class RegionControllerTest
    {
         [TestMethod]
         public void TestGetRegionsOk()
         {
           List<Region> regionsToReturn = new List<Region> (){
                new Region ()
                {
                    Id = 1,
                    Name = "CentroSur",
                    TouristPoints = null,


                },
                new Region ()
                {
                    Id = 2,
                    Name = "Costanera",
                    TouristPoints = null,

                }
           };

           var mock = new Mock <IRegionLogic> (MockBehavior.Strict);
           mock.Setup(mock => mock.GetAll()).Returns(regionsToReturn);
           var controller = new RegionController(mock.Object);
           var result = controller.GetAll();
           var okResult = result as OkObjectResult;
           var regions = okResult.Value as IEnumerable<Region>;
           mock.VerifyAll();
           Assert.IsTrue(regionsToReturn.SequenceEqual(regions));
         }

    }
}