using System;
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
        private Category categoryId1;
        private Mock<ICategoryLogic> mock;
        private CategoryController controller ;
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
            categoryId1 = categoriesToReturn.First();
            mock = new Mock<ICategoryLogic>(MockBehavior.Strict);
            controller = new CategoryController(mock.Object);
        }
        [TestMethod]
        public void TestGetAllCategoriesOk()
        {
            mock.Setup(m => m.GetAll()).Returns(categoriesToReturn);
            var result = controller.Get();
            var okResult = result as OkObjectResult;
            var categories = okResult.Value as IEnumerable<CategoryBasicInfoModel>;
            mock.VerifyAll();
            Assert.IsTrue(categoriesToReturn.Select(n => new CategoryBasicInfoModel(n)).SequenceEqual(categories));
        }

        [TestMethod]
        public void TestGetAllCategoriesVacia()
        {
            mock.Setup(m => m.GetAll()).Returns(categoriesToReturnEmpty);
            var result = controller.Get();
            var okResult = result as OkObjectResult;
            var categories = okResult.Value as IEnumerable<CategoryBasicInfoModel>;
            mock.VerifyAll();
            Assert.IsTrue(categoriesToReturnEmpty.Select(n => new CategoryBasicInfoModel(n)).SequenceEqual(categories));
        }
        [TestMethod]
        public void TestGetByOk()
        {
            int id = 1;
            mock.Setup(m => m.GetBy(id)).Returns(categoryId1);
            var result = controller.GetBy(id);
            var okResult = result as OkObjectResult;
            var categories = okResult.Value as Category;
            mock.VerifyAll();
            Assert.IsTrue(categories.Equals(categoryId1));
        }
        [TestMethod]
        public void TestGetByNotFound()
        {
            int id = 4;
            Category categoryReturn = null;
            mock.Setup(m => m.GetBy(id)).Returns(categoryReturn);
            var result = controller.GetBy(id);
            var okResult = result as OkObjectResult;
            var categories = okResult.Value as Category;
            mock.VerifyAll();
            Assert.IsNull(categories);
        }
        [TestMethod]
        public void TestPostOk()
        {
            mock.Setup(m => m.Add(categoryId1));
            var result = controller.Post(categoryId1);
            var okResult = result as CreatedAtRouteResult;
            mock.VerifyAll();
            Assert.IsNotNull(okResult);
            Assert.AreEqual("Api", okResult.RouteName);
            Assert.AreEqual(okResult.Value, categoryId1);
        }
        [TestMethod]
        public void TestPostFailSameCategory()
        {
            mock.Setup(m => m.Add(categoryId1));
            Exception exist = new AggregateException();
            mock.Setup(p => p.Add(categoryId1)).Throws(exist);
            var result = controller.Post(categoryId1);
            mock.VerifyAll();
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        [TestMethod]
        public void TestPostFailValidation()
        {
            mock.Setup(m => m.Add(categoryId1));
            Exception exist = new ArgumentException();
            mock.Setup(p => p.Add(categoryId1)).Throws(exist);
            var result = controller.Post(categoryId1);
            mock.VerifyAll();
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        [TestMethod]
        public void TestPostFailServer()
        {
            mock.Setup(m => m.Add(categoryId1));
            Exception exist = new Exception();
            mock.Setup(p => p.Add(categoryId1)).Throws(exist);
            var result = controller.Post(categoryId1);
            mock.VerifyAll();
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
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