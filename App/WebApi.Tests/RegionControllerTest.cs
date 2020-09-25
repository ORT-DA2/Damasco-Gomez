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
         public void TestGetAllCategoriesOk()
        {
            List<Region> categoriesToReturn = new List<Region>()
            {
                new Region()
                {
                    Id = 1,
                    Name = "New Region",
                    TouristPoints = null,
                },
                new Region()
                {
                    Id = 2,
                    Name = "Other Region",
                    TouristPoints = null,
                }
            };
            var mock = new Mock<IRegionLogic>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll()).Returns(categoriesToReturn);
            var controller = new RegionController(mock.Object);
            var result = controller.Get();
            var okResult = result as OkObjectResult;
            var categories = okResult.Value as IEnumerable<Region>;
            mock.VerifyAll();
            Assert.IsTrue(categoriesToReturn.SequenceEqual(categories));
        }

    }
}