using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessInterface.Repositories;
using Domain;
using Domain.Entities;
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
        private Mock<ITouristPointRepository> mock2;
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
                    CategoryTouristPoints = new List<CategoryTouristPoint>()
                    {
                        new CategoryTouristPoint()
                        {
                            Id = 1,
                            TouristPoint = new TouristPoint(){Id = 1},
                            CategoryId = 1
                        }
                    }
                },
                new Category()
                {
                    Id = 2,
                    Name = "Category 2",
                }
            };
            emptyCategorys = new List<Category>();
            mock = new Mock<ICategoryRepository>(MockBehavior.Strict);
            mock2 = new Mock<ITouristPointRepository>(MockBehavior.Strict);
            categoryLogic = new CategoryLogic(mock.Object,mock2.Object);
        }

        [TestMethod]
        public void TestDeleteById()
        {
            int lengthTouristPoint = categoriesToReturn.Count;
            mock.Setup(m => m.Delete(categoriesToReturn.First().Id));

            categoryLogic.Delete(categoriesToReturn.First().Id);

            mock.VerifyAll();
        }

        [TestMethod]
        public void TestDelete()
        {
            int lengthRegions = categoriesToReturn.Count;
            mock.Setup(m => m.GetElements()).Returns(categoriesToReturn);
            foreach (Category t in categoriesToReturn)
            {
                mock.Setup(m => m.Delete(t.Id));
            }

            categoryLogic.Delete();

            mock.VerifyAll();
        }
        [TestMethod]
        public void TestDeleteEmpty()
        {
            mock.Setup(m => m.GetElements()).Returns(emptyCategorys);

            categoryLogic.Delete();

            mock.VerifyAll();
        }
        [TestMethod]
        public void GetAll()
        {
            mock.Setup(m => m.GetElements()).Returns(categoriesToReturn);

            var result = categoryLogic.GetAll();

            Assert.IsTrue(result.SequenceEqual(categoriesToReturn));
        }
        [TestMethod]
        public void GetByTestOk()
        {
            Category category = categoriesToReturn.First();
            mock.Setup(m => m.Find(category.Id)).Returns(category);

            var result = categoryLogic.GetBy(category.Id);

            Assert.AreEqual(result,category);
        }
        [TestMethod]
        public void TestGetByFail()
        {
            Category category = categoriesToReturn.First();
            Category empty = null;
            mock.Setup(m => m.Find(category.Id)).Returns(empty);

            var result = categoryLogic.GetBy(category.Id);

            Assert.IsNull(result);
        }
        [TestMethod]
        public void TestAddOk()
        {
            Category category = categoriesToReturn.First();
            mock.Setup(m => m.Add(category)).Returns(category);
            //this.touristPointRepository.Find(m.TouristPointId)
            mock2.Setup(m => m.Find(category.CategoryTouristPoints.First().TouristPointId)).Returns(category.CategoryTouristPoints.First().TouristPoint);

            Category result = categoryLogic.Add(category);

            Assert.AreEqual(category, result );
        }
        [TestMethod]
        public void TestAddValidateError()
        {
            Category category = categoriesToReturn.Last(); // Category tiene que terner un formato erroneo despues para que la validación falle
            mock.Setup(m => m.Add(category)).Returns(category);

            Category result = categoryLogic.Add(category);

            Assert.AreEqual(category, result);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddExistError()
        {
            Category category = categoriesToReturn.Last();
            ArgumentException exception = new ArgumentException();
            mock.Setup(m => m.Add(category)).Throws(exception);

            var reuslt = categoryLogic.Add(category);

            mock.VerifyAll();
        }
        [TestMethod]
        public void TestUpdateOk ()
        {
            Category category = categoriesToReturn.First();
            mock.Setup(m => m.Update(category.Id,category));
            mock.Setup(m => m.Find(category.Id)).Returns(category);
            mock2.Setup(m => m.Find(category.CategoryTouristPoints.First().TouristPointId)).Returns(category.CategoryTouristPoints.First().TouristPoint);

            Category result = categoryLogic.Update(category.Id,category);

            Assert.AreEqual(result,category);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestUpdateExistError()
        {
            Category category = categoriesToReturn.Last();
            ArgumentException exception = new ArgumentException();
            mock.Setup(m => m.Find(category.Id)).Returns(category);
            mock.Setup(m => m.Update(category.Id,category)).Throws(exception);

            categoryLogic.Update(category.Id,category);

            mock.VerifyAll();
        }
        [TestMethod]
        public void TestExistOk()
        {
            Category category = categoriesToReturn.Last();
            mock.Setup(m => m.ExistElement(category)).Returns(true);

            var result = categoryLogic.Exist(category);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestNotExistOk()
        {
            Category category = categoriesToReturn.Last();
            mock.Setup(m => m.ExistElement(category)).Returns(false);

            var result = categoryLogic.Exist(category);

            Assert.IsFalse(result);
        }
    }
}