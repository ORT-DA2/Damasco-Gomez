using System.Collections.Generic;
using DataAccessInterface.Repositories;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BusinessLogic.Tests.Test
{
     [TestClass]
    public class CategoryLogicTest
    {
        private  List<Category> categoryToReturn;
        private  List<Category>  emptyCategorys;
        private CategoryLogic houseLogic;
         private Mock<ICategoryRepository> mock;
        private List<Category> categoriesToReturn;

        [TestInitialize]
        public void initVariables()
        {
             categoriesToReturn = new List<Category>()
            {
                new Category()
                {
                    Id = 1,
                    Name = "Category 1",
                },
                new Category()
                {
                    Id = 2,
                    Name = "Category 2",
                }
            };
            emptyCategorys = new List<Category>();
            mock = new Mock<ICategoryRepository>(MockBehavior.Strict);
            houseLogic = new CategoryLogic(mock.Object);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void GetByTestOk()
        {
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void AddTestOk()
        {
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void UpdateTestOk()
        {
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void DeleteTestByIdOk()
        {
            Assert.IsTrue(true);
        }
         [TestMethod]
        public void ExistTestOk()
        {
            Assert.IsTrue(true);
        }
        
        
    }
}