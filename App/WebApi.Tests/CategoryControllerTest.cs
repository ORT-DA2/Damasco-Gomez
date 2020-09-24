using System.Collections.Generic;
using System.Linq;
using BusinessLogicInterface;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Out;
using Moq;
using WebApi.Controllers;

namespace WebApi.Test
{
    [TestClass]
    public class CategoryControllerTest
    {
        private List<Category> categoriesToReturn;
        private List<Category> categoriesToReturnEmpty;
        private Mock<ICategoryLogic> mock;
        [TestInitialize]
        public void initVariables()
        {
            categoriesToReturn = new List<Category>()
            {
                new Category()
                {
                    Id = 1,
                    Name = "New category",
                    CategoryTouristPoints = null,
                },
                new Category()
                {
                    Id = 2,
                    Name = "Other category",
                    CategoryTouristPoints = null,
                }
            };
            categoriesToReturnEmpty = new List<Category>();
            mock = new Mock<ICategoryLogic>();
        }
        [TestMethod]
        public void TestGetAllCategoriesOk()
        {
            mock = new Mock<ICategoryLogic>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll()).Returns(categoriesToReturn);
            var controller = new CategoryController(mock.Object);
            var result = controller.Get();
            var okResult = result as OkObjectResult;
            var categories = okResult.Value as IEnumerable<CategoryBasicInfoModel>;
            mock.VerifyAll();
            Assert.IsTrue(categoriesToReturn.Select(n => new CategoryBasicInfoModel(n)).SequenceEqual(categories));
        }

        [TestMethod]
        public void TestGetAllCategoriesVacia()
        {
            mock = new Mock<ICategoryLogic>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll()).Returns(categoriesToReturnEmpty);
            var controller = new CategoryController(mock.Object);
            var result = controller.Get();
            var okResult = result as OkObjectResult;
            var categories = okResult.Value as IEnumerable<CategoryBasicInfoModel>;
            mock.VerifyAll();
            Assert.IsTrue(categoriesToReturnEmpty.Select(n => new CategoryBasicInfoModel(n)).SequenceEqual(categories));
        }
        [TestMethod]
        public void TestGetBy()
        {
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void TestPost()
        {
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void TestPut()
        {
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void TestDeleteWithId()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestDelete()
        {
            Assert.IsTrue(true);
        }
    }
}