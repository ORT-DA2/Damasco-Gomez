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

namespace WebApi.Tests
{
    [TestClass]
    public class TouristPointControllerTest
    {
        private List<TouristPoint> touristPointsToReturn;
        private List<TouristPoint> touristPointsToReturnEmpty;
        private TouristPoint touristPointId1;
        private Mock<ITouristPointLogic> mock;
        private TouristPointController controller ;
        [TestInitialize]
        public void initVariables()
        {
            touristPointsToReturn = new List<TouristPoint>()
            {
                new TouristPoint()
                {
                    Id = 1,
                    Name = "Name TouristPoint 1",
                    // Image = "Image1",
                    Description = "Description 1",
                    Region = null ,
                    CategoriesTouristPoints = new List<CategoryTouristPoint>()
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
                    },//HAY QUE TENER CUIDADO CON ESTO NULL, ROMPE TODO , HACER CHECK DE ESTA VAR
                },
                new TouristPoint()
                {
                    Id = 2,
                    Name = "Name TouristPoint 2",
                    // Image = "Image2",
                    Description = "Description 2",
                    Region = null ,
                    CategoriesTouristPoints = new List<CategoryTouristPoint>()
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
                new TouristPoint()
                {
                    Id = 3,
                    Name = "Name TouristPoint 3",
                    // Image = "Image3",
                    Description = "Description 3",
                    Region = null ,
                    CategoriesTouristPoints = new List<CategoryTouristPoint>()
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
                new TouristPoint()
                {
                    Id = 4,
                    Name = "Name TouristPoint 4",
                    // Image = "Image4",
                    Description = "Description 4",
                    Region = null ,
                    CategoriesTouristPoints = new List<CategoryTouristPoint>()
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
            touristPointsToReturnEmpty = new List<TouristPoint>();
            touristPointId1 = touristPointsToReturn.First();
            mock = new Mock<ITouristPointLogic>(MockBehavior.Strict);
            controller = new TouristPointController(mock.Object);
        }
        [TestMethod]
        public void TestGetAllTouristPointsOk()
        {
            mock.Setup(m => m.GetAll()).Returns(touristPointsToReturn);
            List<TouristPointBasicInfoModel> modelList = new List<TouristPointBasicInfoModel>();
            foreach (var touristPoint in touristPointsToReturn)
            {
                var model = new TouristPointBasicInfoModel(touristPoint);
                modelList.Add(model);
            }

            var result = controller.Get();
            var okResult = result as OkObjectResult;
            var touristPoints = okResult.Value as IEnumerable<TouristPointBasicInfoModel>;

            mock.VerifyAll();
            Assert.IsTrue(modelList.SequenceEqual(touristPoints));
        }

        [TestMethod]
        public void TestGetAllTouristPointsVacia()
        {
            mock.Setup(m => m.GetAll()).Returns(touristPointsToReturnEmpty);
            List<TouristPointBasicInfoModel> empty = new List<TouristPointBasicInfoModel>(){};

            var result = controller.Get();

            var okResult = result as OkObjectResult;
            var touristPoints = okResult.Value as List<TouristPointBasicInfoModel>;
            mock.VerifyAll();
            Assert.IsTrue(touristPoints.SequenceEqual(empty));
        }
        [TestMethod]
        public void TestGetByOk()
        {
            int id = 1;
            mock.Setup(m => m.GetBy(id)).Returns(touristPointId1);

            var result = controller.GetBy(id);

            var okResult = result as OkObjectResult;
            var touristPoints = okResult.Value as TouristPointDetailInfoModel;
            mock.VerifyAll();
            Assert.IsTrue(touristPointId1.Equals(touristPointId1));
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
            TouristPointModel touristPointModel = new TouristPointModel()
            {
                Name = "name tourist point",
                Image = "image",
                Description = "description",
                RegionId = 1,
                Categories = new List<int>() { 1 }
            };
            touristPointId1 = touristPointModel.ToEntity();
            TouristPointDetailInfoModel detailInfoModel = new TouristPointDetailInfoModel(touristPointId1);
            mock.Setup(m => m.Add(touristPointId1)).Returns(touristPointId1);

            var result = controller.Post(touristPointModel);

            var okResult = result as CreatedAtRouteResult;
            mock.VerifyAll();
            Assert.IsNotNull(okResult);
            Assert.AreEqual("GetTouristPoint", okResult.RouteName);
            Assert.AreEqual(okResult.Value, detailInfoModel);
        }
        [TestMethod]
        [ExpectedException(typeof(AggregateException))]
        public void TestPostFailSameTouristPoint()
        {
            TouristPointModel touristPointModel = new TouristPointModel()
            {
                Name = "name",
                Image = "image",
                Description = "description",
                RegionId = 1,
                Categories = new List<int>(){1}
            };
            touristPointId1 = touristPointModel.ToEntity();
            AggregateException exist = new AggregateException();
            mock.Setup(p => p.Add(touristPointId1)).Throws(exist);

            var result = controller.Post(touristPointModel);

            mock.VerifyAll();
            //Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPostFailValidation()
        {
            TouristPointModel touristPointModel = new TouristPointModel()
            {
                Name = "name",
                Image = "image",
                Description = "description",
                RegionId = 1,
                Categories = new List<int>(){1}
            };
            touristPointId1 = touristPointModel.ToEntity();
            Exception exist = new ArgumentException();
            mock.Setup(p => p.Add(touristPointId1)).Throws(exist);

            var result = controller.Post(touristPointModel);

            mock.VerifyAll();
            //Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestPostFailServer()
        {
            TouristPointModel touristPointModel = new TouristPointModel()
            {
                Name = "name",
                Image = "image",
                Description = "description",
                RegionId = 1,
                Categories = new List<int>(){1}
            };
            touristPointId1 = touristPointModel.ToEntity();
            Exception exist = new Exception();
            mock.Setup(p => p.Add(touristPointId1)).Throws(exist);

            var result = controller.Post(touristPointModel);

            mock.VerifyAll();
            //Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        [TestMethod]
        public void TestPutOk()
        {
            int id = touristPointId1.Id;
            TouristPointModel touristPointModel = new TouristPointModel()
            {
                Name = "new name",
                Image = "image",
                Description = "description",
                RegionId = 1,
                Categories = new List<int>(){1}
            };
            touristPointId1 = touristPointModel.ToEntity();
            TouristPointDetailInfoModel touristPointBasicModel = new TouristPointDetailInfoModel(touristPointId1);
            mock.Setup(m => m.Update(id,touristPointId1)).Returns(touristPointId1);

            var result = controller.Put(id, touristPointModel);

            var okResult = result as CreatedAtRouteResult;
            mock.VerifyAll();
            Assert.IsNotNull(okResult);
            Assert.AreEqual("GetTouristPoint", okResult.RouteName);
            Assert.AreEqual(okResult.Value, touristPointBasicModel);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPutFailValidate()
        {
            TouristPointModel touristPointModel = new TouristPointModel()
            {
                Name = "new name",
                Image = "image",
                Description = "description",
                RegionId = 1,
                Categories = new List<int>(){1}
            };
            touristPointId1 = touristPointModel.ToEntity();
            Exception exist = new ArgumentException();
            mock.Setup(p => p.Update(touristPointId1.Id,touristPointId1)).Throws(exist);

            var result = controller.Put(touristPointId1.Id, touristPointModel);

            mock.VerifyAll();
            //Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPutFailServer()
        {
            TouristPointModel touristPointModel = new TouristPointModel()
            {
                Name = "new name",
                Image = "image",
                Description = "description",
                RegionId = 1,
                Categories = new List<int>(){1}
            };
            touristPointId1 = touristPointModel.ToEntity();
            ArgumentException exist = new ArgumentException();
            mock.Setup(p => p.Update(touristPointId1.Id,touristPointId1)).Throws(exist);

            var result = controller.Put(touristPointId1.Id, touristPointModel);

            mock.VerifyAll();
            //Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        [TestMethod]
        public void TestDeleteWithId()
        {
            TouristPoint touristPoint = touristPointsToReturn.First();
            mock.Setup(m => m.GetBy(touristPoint.Id)).Returns(touristPoint);
            mock.Setup(mock=> mock.Delete(touristPoint.Id));

            var result = controller.Delete(touristPoint.Id);

            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestDeleteWithIdNotFound()
        {
            TouristPoint touristPoint = touristPointsToReturn.First();
            TouristPoint touristPointNull = null;
            mock.Setup(m => m.GetBy(touristPoint.Id)).Returns(touristPointNull);
            mock.Setup(mock=> mock.Delete(touristPoint.Id));

            var result = controller.Delete(touristPoint.Id);
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