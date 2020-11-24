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
        private Category categoryWithId1;
        private Mock<ICategoryLogic> mockCategoryLogic;
        private CategoryController controller ;
        [TestInitialize]
        public void InitVariables()
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
                            CategoryId = 1,
                            Category = new Category()
                            {
                                Id = 1,
                            },
                            TouristPointId = 1,
                            TouristPoint = new TouristPoint()
                            {
                                Id = 1,
                                CategoriesTouristPoints = new List<CategoryTouristPoint>()
                            }
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
            categoryWithId1 = categoriesToReturn.First();
            mockCategoryLogic = new Mock<ICategoryLogic>(MockBehavior.Strict);
            controller = new CategoryController(mockCategoryLogic.Object);



        }
        [TestMethod]
        public void TestGetAllCategoriesOk()
        {
            mockCategoryLogic.Setup(m => m.GetAll()).Returns(categoriesToReturn);
            IEnumerable<CategoryBasicInfoModel> categoriesModels = categoriesToReturn.Select(m => new CategoryBasicInfoModel(m));

            var result = controller.Get();

            var okResult = result as OkObjectResult;
            var categories = okResult.Value as IEnumerable<CategoryBasicInfoModel>;
            Assert.IsTrue(categoriesModels.SequenceEqual(categories));
        }

        [TestMethod]
        public void TestGetAllCategoriesVacia()
        {
            mockCategoryLogic.Setup(m => m.GetAll()).Returns(categoriesToReturnEmpty);
            IEnumerable<CategoryBasicInfoModel> categoriesModels = categoriesToReturnEmpty.Select(m => new CategoryBasicInfoModel(m));

            var result = controller.Get();

            var okResult = result as OkObjectResult;
            var categories = okResult.Value as IEnumerable<CategoryBasicInfoModel>;
            mockCategoryLogic.VerifyAll();
            Assert.IsTrue(categoriesModels.SequenceEqual(categories));
        }
        [TestMethod]
        public void TestGetByOk()
        {
            int id = 1;
            mockCategoryLogic.Setup(m => m.GetBy(id)).Returns(categoryWithId1);
            CategoryDetailInfoModel categoriesModels = new CategoryDetailInfoModel(categoryWithId1);

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
            mockCategoryLogic.Setup(m => m.GetBy(id)).Throws(exist);

            var result = controller.GetBy(id);

            mockCategoryLogic.VerifyAll();
        }
        [TestMethod]
        public void TestPostOk()
        {
            CategoryModel categoryModel = new CategoryModel()
            {
                Name = categoryWithId1.Name,
                TouristPoints = new List<int>(){}
            };
            categoryWithId1 = categoryModel.ToEntity();
            mockCategoryLogic.Setup(m => m.Add(categoryWithId1)).Returns(categoryWithId1);
            CategoryBasicInfoModel modelOut  = new CategoryBasicInfoModel(categoryWithId1);

            var result = controller.Post(categoryModel);

            var okResult = result as CreatedAtRouteResult;
            mockCategoryLogic.VerifyAll();
            Assert.IsNotNull(okResult);
        }
        [TestMethod]
        [ExpectedException(typeof(AggregateException))]
        public void TestPostFailSameCategory()
        {
            CategoryModel categoryModel = new CategoryModel()
            {
                Name = categoryWithId1.Name,
                TouristPoints = new List<int>(){1}
            };
            categoryWithId1 = categoryModel.ToEntity();
            Exception exist = new AggregateException();
            mockCategoryLogic.Setup(p => p.Add(categoryWithId1)).Throws(exist);

            var result = controller.Post(categoryModel);

            mockCategoryLogic.VerifyAll();
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPostFailValidation()
        {
            CategoryModel categoryModel = new CategoryModel()
            {
                Name = categoryWithId1.Name,
                TouristPoints = new List<int>()
            };
            categoryWithId1 = categoryModel.ToEntity();
            Exception exist = new ArgumentException();
            mockCategoryLogic.Setup(p => p.Add(categoryWithId1)).Throws(exist);

            var result = controller.Post(categoryModel);

            mockCategoryLogic.VerifyAll();
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestPostFailServer()
        {
            CategoryModel categoryModel = new CategoryModel()
            {
                Name = categoryWithId1.Name,
                TouristPoints = new List<int>()
            };
            categoryWithId1 = categoryModel.ToEntity();
            Exception exist = new Exception();
            mockCategoryLogic.Setup(p => p.Add(categoryWithId1)).Throws(exist);

            var result = controller.Post(categoryModel);

            mockCategoryLogic.VerifyAll();
        }
        [TestMethod]
        public void TestPutOk()
        {
            CategoryModel categoryModel = new CategoryModel()
            {
                Name = categoryWithId1.Name,
                TouristPoints = new List<int>()
            };
            categoryWithId1 = categoryModel.ToEntity();
            categoryWithId1.Name = "New name";
            mockCategoryLogic.Setup(m => m.Update(categoryWithId1.Id,categoryWithId1)).Returns(categoryWithId1);
            CategoryBasicInfoModel modelOut  = new CategoryBasicInfoModel(categoryWithId1);

            var result = controller.Put(categoryWithId1.Id, categoryModel);

            var okResult = result as CreatedAtRouteResult;
            mockCategoryLogic.VerifyAll();
            Assert.IsNotNull(okResult);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPutFailValidate()
        {
            CategoryModel categoryModel = new CategoryModel()
            {
                Name = categoryWithId1.Name,
                TouristPoints = new List<int>()
            };
            categoryWithId1 = categoryModel.ToEntity();
            Exception exist = new ArgumentException();
            mockCategoryLogic.Setup(p => p.Update(categoryWithId1.Id,categoryWithId1)).Throws(exist);

            var result = controller.Put(categoryWithId1.Id, categoryModel);

            mockCategoryLogic.VerifyAll();
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestPutFailServer()
        {
            CategoryModel categoryModel = new CategoryModel()
            {
                Name = categoryWithId1.Name,
                TouristPoints = new List<int>()
            };
            categoryWithId1 = categoryModel.ToEntity();
            Exception exist = new Exception();
            mockCategoryLogic.Setup(p => p.Update(categoryWithId1.Id,categoryWithId1)).Throws(exist);

            var result = controller.Put(categoryWithId1.Id, categoryModel);

            mockCategoryLogic.VerifyAll();
        }
        [TestMethod]
        public void TestDeleteWithId()
        {
            Category category = categoriesToReturn.First();
            mockCategoryLogic.Setup(m => m.GetBy(category.Id)).Returns(category);
            mockCategoryLogic.Setup(mockCategoryLogic=> mockCategoryLogic.Delete(category.Id));

            var result = controller.Delete(category.Id);

            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestDeleteWithIdNotFound()
        {
            Category category = categoriesToReturn.First();
            Category categoryNull = null;
            mockCategoryLogic.Setup(m => m.GetBy(category.Id)).Returns(categoryNull);
            mockCategoryLogic.Setup(mockCategoryLogic=> mockCategoryLogic.Delete(category.Id));

            var result = controller.Delete(category.Id);
        }

        [TestMethod]
        public void TestDelete()
        {
            mockCategoryLogic.Setup(mockCategoryLogic=> mockCategoryLogic.Delete());

            var result = controller.Delete();
            
            Assert.IsNotNull(result);
        }
    }
}