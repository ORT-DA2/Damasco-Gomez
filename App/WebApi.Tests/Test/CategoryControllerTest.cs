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
                },
                new Category()
                {
                    Id = 3,
                    Name = "And other category",
                    CategoryTouristPoints = null,
                },
                new Category()
                {
                    Id = 4,
                    Name = "And one more category",
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
            mock.Setup(m => m.Add(categoryId1)).Returns(categoryId1);

            var result = controller.Post(categoryId1);

            var okResult = result as CreatedAtRouteResult;
            mock.VerifyAll();
            Assert.IsNotNull(okResult);
            Assert.AreEqual("GetCategory", okResult.RouteName);
            Assert.AreEqual(okResult.Value, categoryId1);
        }
        [TestMethod]
        public void TestPostFailSameCategory()
        {
            categoryId1 = categoriesToReturn.First();
            Exception exist = new AggregateException();
            mock.Setup(p => p.Add(categoryId1)).Throws(exist);

            var result = controller.Post(categoryId1);

            mock.VerifyAll();
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        [TestMethod]
        public void TestPostFailValidation()
        {
            categoryId1 = categoriesToReturn.First();
            Exception exist = new ArgumentException();
            mock.Setup(p => p.Add(categoryId1)).Throws(exist);

            var result = controller.Post(categoryId1);

            mock.VerifyAll();
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        [TestMethod]
        public void TestPostFailServer()
        {
            categoryId1 = categoriesToReturn.First();
            Exception exist = new Exception();
            mock.Setup(p => p.Add(categoryId1)).Throws(exist);

            var result = controller.Post(categoryId1);

            mock.VerifyAll();
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        [TestMethod]
        public void TestPutOk()
        {
            categoryId1 = categoriesToReturn.First();
            mock.Setup(m => m.Update(categoryId1.Id,categoryId1));

            var result = controller.Put(categoryId1.Id, categoryId1);

            var okResult = result as CreatedAtRouteResult;
            mock.VerifyAll();
            Assert.IsNotNull(okResult);
            Assert.AreEqual("GetCategory", okResult.RouteName);
            Assert.AreEqual(okResult.Value, categoryId1);
        }
        [TestMethod]
        public void TestPutFailValidate()
        {
            categoryId1 = categoriesToReturn.First();
            Exception exist = new ArgumentException();
            mock.Setup(p => p.Update(categoryId1.Id,categoryId1)).Throws(exist);

            var result = controller.Put(categoryId1.Id, categoryId1);

            mock.VerifyAll();
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        [TestMethod]
        public void TestPutFailServer()
        {
            categoryId1 = categoriesToReturn.First();
            Exception exist = new Exception();
            mock.Setup(p => p.Update(categoryId1.Id,categoryId1)).Throws(exist);

            var result = controller.Put(categoryId1.Id, categoryId1);

            mock.VerifyAll();
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        [TestMethod]
        public void TestDeleteWithId()
        {
            Category category = categoriesToReturn.First();
            mock.Setup(m => m.GetBy(category.Id)).Returns(category);
            mock.Setup(mock=> mock.Delete(category.Id));

            var result = controller.Delete(category.Id);

            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestDeleteWithIdNotFound()
        {
            Category category = categoriesToReturn.First();
            Category categoryNull = null;
            mock.Setup(m => m.GetBy(category.Id)).Returns(categoryNull);
            mock.Setup(mock=> mock.Delete(category.Id));

            var result = controller.Delete(category.Id);

            Assert.IsInstanceOfType(result,typeof(NotFoundResult));
        }

        [TestMethod]
        public void TestDelete()
        {
            mock.Setup(mock=> mock.Delete());

            var result = controller.Delete();
            
            Assert.IsNotNull(result);
        }
    }
}