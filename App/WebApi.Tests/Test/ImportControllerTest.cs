using System.Collections.Generic;
using BusinessLogicInterface.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApi.Controllers;

namespace WebApi.Tests.Test
{
    [TestClass]
    public class ImportControllerTest
    {
        private List<House> houseToReturn;
        private Mock<IImporterLogic> mock;
        private ImportController controller ;
        private List<string> namesToReturn;
        [TestInitialize]
        public void initVariables()
        {
            houseToReturn = new List<House>()
            {
                new House()
                {
                    Id = 1,
                    Name = "New house",
                },
                new House()
                {
                    Id = 2,
                    Name = "Other house",
                },
                new House()
                {
                    Id = 3,
                    Name = "And other house",
                },
                new House()
                {
                    Id = 4,
                    Name = "And one more house",
                }
            };
            mock = new Mock<IImporterLogic>(MockBehavior.Strict);
            controller = new ImportController();
            namesToReturn = new List<string>{"", ""};
        }
        [TestMethod]
        public void TestGetOk()
        {
            mock.Setup(m => m.GetNames()).Returns(namesToReturn);

            // var result  = controller.Get();

            // var okResult = result as OkObjectResult;
            // mock.VerifyAll();
        }

        [TestMethod]
        public void TestGetHousesFail()
        {
            
        }
        
        [TestMethod]
        public void TestPostOk()
        {
            
        }
        [TestMethod]
        public void TestPostFailSame()
        {
            
        }
        
    }
}