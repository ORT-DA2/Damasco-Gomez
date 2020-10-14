using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogicInterface;
using Domain;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.In;
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
                    CategoryTouristPoints = new List<CategoryTouristPoint>()
                    {
                        new CategoryTouristPoint()
                        {
                            Id = 1,
                            CategoryId = 2,
                            Category = new Category()
                            {
                                Id = 2,
                            },
                            TouristPointId = 1,
                            TouristPoint = new TouristPoint(){ Id = 1}
                        }
                    },
                },
                new Category()
                {
                    Id = 2,
                    Name = "Other category",
                    CategoryTouristPoints = new List<CategoryTouristPoint>()
                    {
                        new CategoryTouristPoint()
                        {
                            Id = 1,
                            CategoryId = 2,
                            Category = new Category()
                            {
                                Id = 2,
                            },
                            TouristPointId = 1,
                            TouristPoint = new TouristPoint(){ Id = 1}
                        }
                    },
                },
                new Category()
                {
                    Id = 3,
                    Name = "And other category",
                    CategoryTouristPoints = new List<CategoryTouristPoint>()
                    {
                        new CategoryTouristPoint()
                        {
                            Id = 1,
                            CategoryId = 2,
                            Category = new Category()
                            {
                                Id = 2,
                            },
                            TouristPointId = 1,
                            TouristPoint = new TouristPoint(){ Id = 1}
                        }
                    },
                },
                new Category()
                {
                    Id = 4,
                    Name = "And one more category",
                    CategoryTouristPoints = new List<CategoryTouristPoint>()
                    {
                        new CategoryTouristPoint()
                        {
                            Id = 1,
                            CategoryId = 2,
                            Category = new Category()
                            {
                                Id = 2,
                            },
                            TouristPointId = 1,
                            TouristPoint = new TouristPoint(){ Id = 1}
                        }
                    },
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
            IEnumerable<CategoryBasicInfoModel> categoriesModels = categoriesToReturn.Select(m => new CategoryBasicInfoModel(m));

            var result = controller.Get();

            var okResult = result as OkObjectResult;
            var categories = okResult.Value as IEnumerable<CategoryBasicInfoModel>;
            Assert.IsTrue(categoriesModels.SequenceEqual(categories));
        }

        [TestMethod]
        public void TestGetAllCategoriesVacia()
        {
            mock.Setup(m => m.GetAll()).Returns(categoriesToReturnEmpty);
            IEnumerable<CategoryBasicInfoModel> categoriesModels = categoriesToReturnEmpty.Select(m => new CategoryBasicInfoModel(m));

            var result = controller.Get();

            var okResult = result as OkObjectResult;
            var categories = okResult.Value as IEnumerable<CategoryBasicInfoModel>;
            mock.VerifyAll();
            Assert.IsTrue(categoriesModels.SequenceEqual(categories));
        }
        [TestMethod]
        public void TestGetByOk()
        {
            int id = 1;
            mock.Setup(m => m.GetBy(id)).Returns(categoryId1);
            CategoryDetailInfoModel categoriesModels = new CategoryDetailInfoModel(categoryId1);

            var result = controller.GetBy(id);

            var okResult = result as OkObjectResult;
            var categories = okResult.Value as CategoryDetailInfoModel;
            Assert.IsTrue(categoriesModels.Equals(categories));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGetByNotFound()
        {
            int id = 4;
            ArgumentException exist = new ArgumentException();
            mock.Setup(m => m.GetBy(id)).Throws(exist);

            var result = controller.GetBy(id);

            mock.VerifyAll();
            //Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        [TestMethod]
        public void TestPostOk()
        {
            CategoryModel categoryModel = new CategoryModel()
            {
                Name = categoryId1.Name,
                TouristPoints = new List<int>(){}
            };
            categoryId1 = categoryModel.ToEntity();
            mock.Setup(m => m.Add(categoryId1)).Returns(categoryId1);
            CategoryBasicInfoModel modelOut  = new CategoryBasicInfoModel(categoryId1);

            var result = controller.Post(categoryModel);

            var okResult = result as CreatedAtRouteResult;
            mock.VerifyAll();
            Assert.IsNotNull(okResult);
            Assert.AreEqual("GetCategory", okResult.RouteName);
            Assert.AreEqual(okResult.Value, modelOut);
        }
        [TestMethod]
        [ExpectedException(typeof(AggregateException))]
        public void TestPostFailSameCategory()
        {
            CategoryModel categoryModel = new CategoryModel()
            {
                Name = categoryId1.Name,
                TouristPoints = new List<int>(){1}
            };
            categoryId1 = categoryModel.ToEntity();
            Exception exist = new AggregateException();
            mock.Setup(p => p.Add(categoryId1)).Throws(exist);

            var result = controller.Post(categoryModel);

            mock.VerifyAll();
            //Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPostFailValidation()
        {
            CategoryModel categoryModel = new CategoryModel()
            {
                Name = categoryId1.Name,
                TouristPoints = new List<int>()
            };
            categoryId1 = categoryModel.ToEntity();
            Exception exist = new ArgumentException();
            mock.Setup(p => p.Add(categoryId1)).Throws(exist);

            var result = controller.Post(categoryModel);

            mock.VerifyAll();
            //Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestPostFailServer()
        {
            CategoryModel categoryModel = new CategoryModel()
            {
                Name = categoryId1.Name,
                TouristPoints = new List<int>()
            };
            categoryId1 = categoryModel.ToEntity();
            Exception exist = new Exception();
            mock.Setup(p => p.Add(categoryId1)).Throws(exist);

            var result = controller.Post(categoryModel);

            mock.VerifyAll();
            //Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        [TestMethod]
        public void TestPutOk()
        {
            CategoryModel categoryModel = new CategoryModel()
            {
                Name = categoryId1.Name,
                TouristPoints = new List<int>()
            };
            categoryId1 = categoryModel.ToEntity();
            categoryId1.Name = "New name";
            mock.Setup(m => m.Update(categoryId1.Id,categoryId1)).Returns(categoryId1);
            CategoryBasicInfoModel modelOut  = new CategoryBasicInfoModel(categoryId1);

            var result = controller.Put(categoryId1.Id, categoryModel);

            var okResult = result as CreatedAtRouteResult;
            mock.VerifyAll();
            Assert.IsNotNull(okResult);
            Assert.AreEqual("GetCategory", okResult.RouteName);
            Assert.AreEqual(okResult.Value, modelOut);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPutFailValidate()
        {
            CategoryModel categoryModel = new CategoryModel()
            {
                Name = categoryId1.Name,
                TouristPoints = new List<int>()
            };
            categoryId1 = categoryModel.ToEntity();
            Exception exist = new ArgumentException();
            mock.Setup(p => p.Update(categoryId1.Id,categoryId1)).Throws(exist);

            var result = controller.Put(categoryId1.Id, categoryModel);

            mock.VerifyAll();
            //Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestPutFailServer()
        {
            CategoryModel categoryModel = new CategoryModel()
            {
                Name = categoryId1.Name,
                TouristPoints = new List<int>()
            };
            categoryId1 = categoryModel.ToEntity();
            Exception exist = new Exception();
            mock.Setup(p => p.Update(categoryId1.Id,categoryId1)).Throws(exist);

            var result = controller.Put(categoryId1.Id, categoryModel);

            mock.VerifyAll();
            //Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
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

            //Assert.IsInstanceOfType(result,typeof(NotFoundResult));
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