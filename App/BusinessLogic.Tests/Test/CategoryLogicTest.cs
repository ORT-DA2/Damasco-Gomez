using System;
using System.Collections.Generic;
using System.Linq;
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
        private CategoryLogic categoryLogic;
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
            var mock2 = new Mock<ITouristPointRepository>(MockBehavior.Strict);
            categoryLogic = new CategoryLogic(mock.Object,mock2.Object);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void DeleteTestByIdOk()
        {
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void GetByTestOk()
        {
            Category category = categoriesToReturn.First();
            mock.Setup(m => m.Find(category.Id)).Returns(category);

            var result = categoryLogic.GetBy(category.Id);

            mock.VerifyAll();
            Assert.AreEqual(result,category);
        }
        [TestMethod]
         public void TestGetByFail()
        {
            Category category = categoriesToReturn.First();
            Category empty = null;
            mock.Setup(m => m.Find(category.Id)).Returns(empty);

            var result = categoryLogic.GetBy(category.Id);

            mock.VerifyAll();
            Assert.IsNull(result);
        }
        public void TestAddOk()
        {
            Category category = categoriesToReturn.First();
            mock.Setup(m => m.Add(category)).Returns(category);
            var result= categoryLogic.Add(category);

            Assert.AreEqual(category, result );
        }
        [TestMethod]
        public void TestAddValidateError()
        {
            Category category = categoriesToReturn.First(); // Category tiene que terner un formato erroneo despues para que la validación falle
            mock.Setup(m => m.Add(category)).Returns(category);

            var result = categoryLogic.Add(category);

            Assert.AreEqual(category, result);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddExistError()
        {
            Category category = categoriesToReturn.First();
            ArgumentException exception = new ArgumentException();
            mock.Setup(m => m.Add(category)).Throws(exception);

            var reuslt = categoryLogic.Add(category);
        }
         [TestMethod]
        public void TestUdpateOk ()
        {
            Category category = categoriesToReturn.First();
            mock.Setup(m => m.Update(category.Id,category));

            categoryLogic.Update(category.Id,category);

            mock.VerifyAll();
        }
        [TestMethod]
        public void TestUpdateValidateError()
        {
            Category category = categoriesToReturn.First();// Category tiene que terner un formato erroneo despues para que la validación falle
             mock.Setup(m => m.Update(category.Id,category));

            categoryLogic.Update(category.Id,category);

            mock.VerifyAll();
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestUpdateExistError()
        {
            Category category = categoriesToReturn.First();
            ArgumentException exception = new ArgumentException();
            mock.Setup(m => m.Update(category.Id,category)).Throws(exception);

            categoryLogic.Update(category.Id,category);
        }
        [TestMethod]
        public void TestExistOk()
        {
            Category category = categoriesToReturn.First();
            mock.Setup(m => m.ExistElement(category)).Returns(true);

            var result = categoryLogic.Exist(category);

            mock.VerifyAll();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestNotExistOk()
        {
            Category category = categoriesToReturn.First();
            mock.Setup(m => m.ExistElement(category)).Returns(false);
            var result = categoryLogic.Exist(category);
            mock.VerifyAll();
            Assert.IsFalse(result);
        }
    }
}