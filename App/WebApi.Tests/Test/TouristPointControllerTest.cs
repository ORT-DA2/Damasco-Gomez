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
        private TouristPoint touristPointWithId1;
        private Mock<ITouristPointLogic> mockTouristPointLogic;
        private TouristPointController controllerTouristPoint;
        [TestInitialize]
        public void InitVariables()
        {
            touristPointsToReturn = new List<TouristPoint>()
            {
                new TouristPoint()
                {
                    Id = 1,
                    Name = "Name TouristPoint 1",
                    Description = "Description 1",
                    RegionId = 1,
                    Region = new Region()
                    {
                        Id=1,
                        Name="Name region",
                    } ,
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
                    ImageTouristPointId = 1,
                    ImageTouristPoint = new ImageTouristPoint("image.png"),
                },
                new TouristPoint()
                {
                    Id = 2,
                    Name = "Name TouristPoint 2",
                    Description = "Description 2",
                    Region = new Region()
                    {
                        Id=1,
                        Name="Name region",
                    } ,
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
                    Description = "Description 3",
                    Region = new Region()
                    {
                        Id=1,
                        Name="Name region",
                    } ,
                    RegionId = 1,
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
                    Description = "Description 4",
                    Region = new Region()
                    {
                        Id=1,
                        Name="Name region",
                    } ,
                    RegionId = 1,
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
            touristPointWithId1 = touristPointsToReturn.First();
            mockTouristPointLogic = new Mock<ITouristPointLogic>(MockBehavior.Strict);
            controllerTouristPoint = new TouristPointController(mockTouristPointLogic.Object);
        }
        [TestMethod]
        public void TestGetAllTouristPointsOk()
        {
            mockTouristPointLogic.Setup(m => m.GetAll()).Returns(touristPointsToReturn);
            List<TouristPointBasicInfoModel> modelListTouristPoints = new List<TouristPointBasicInfoModel>();
            foreach (var touristPoint in touristPointsToReturn)
            {
                var modelTouristPoint = new TouristPointBasicInfoModel(touristPoint);
                modelListTouristPoints.Add(modelTouristPoint);
            }

            var result = controllerTouristPoint.Get();
            var okResult = result as OkObjectResult;
            var touristPoints = okResult.Value as IEnumerable<TouristPointBasicInfoModel>;

            mockTouristPointLogic.VerifyAll();
            Assert.IsTrue(modelListTouristPoints.SequenceEqual(touristPoints));
        }

        [TestMethod]
        public void TestGetAllTouristPointsVacia()
        {
            mockTouristPointLogic.Setup(m => m.GetAll()).Returns(touristPointsToReturnEmpty);
            List<TouristPointBasicInfoModel> empty = new List<TouristPointBasicInfoModel>() { };

            var result = controllerTouristPoint.Get();

            var okResult = result as OkObjectResult;
            var touristPoints = okResult.Value as List<TouristPointBasicInfoModel>;
            mockTouristPointLogic.VerifyAll();
            Assert.IsTrue(touristPoints.SequenceEqual(empty));
        }
        [TestMethod]
        public void TestGetByOk()
        {
            int id = 1;
            mockTouristPointLogic.Setup(m => m.GetBy(id)).Returns(touristPointWithId1);

            var result = controllerTouristPoint.GetBy(id);

            var okResult = result as OkObjectResult;
            var touristPoints = okResult.Value as TouristPointDetailInfoModel;
            mockTouristPointLogic.VerifyAll();
            Assert.IsTrue(touristPointWithId1.Equals(touristPointWithId1));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGetByNotFound()
        {
            int id = 4;
            ArgumentException exist = new ArgumentException();
            mockTouristPointLogic.Setup(m => m.GetBy(id)).Throws(exist);

            var result = controllerTouristPoint.GetBy(id);

            mockTouristPointLogic.VerifyAll();
        }
        [TestMethod]
        public void TestPostOk()
        {
            TouristPointModel touristPointModel = new TouristPointModel()
            {
                Name = "name tourist point",
                Image = "image.png",
                Description = "description",
                RegionId = 1, 
                Categories = new List<int>() { 1 }
            };
            TouristPoint anotherTouristPoint = touristPointModel.ToEntity();
            anotherTouristPoint.CategoriesTouristPoints[0] = new CategoryTouristPoint()
            {
                Id = 1,
                CategoryId = 1,
                TouristPoint = touristPointWithId1,
                TouristPointId = 1,
                Category = new Category() { Id = 1, Name = "Name category" },
            };
            anotherTouristPoint.Region = new Region() { Id = 1, Name = "RegionName" };
            mockTouristPointLogic.Setup(m => m.Add(anotherTouristPoint)).Returns(anotherTouristPoint);
            TouristPointDetailInfoModel detailInfoModel = new TouristPointDetailInfoModel(touristPointWithId1);

            var result = controllerTouristPoint.Post(touristPointModel);

            var okResult = result as CreatedAtRouteResult;
            mockTouristPointLogic.VerifyAll();
            Assert.IsNotNull(okResult);
        }
        [TestMethod]
        [ExpectedException(typeof(AggregateException))]
        public void TestPostFailSameTouristPoint()
        {
            TouristPointModel touristPointModel = new TouristPointModel()
            {
                Name = "name",
                Image = "image.png",
                Description = "description",
                RegionId = 1,
                Categories = new List<int>() { 1 }
            };
            touristPointWithId1 = touristPointModel.ToEntity();
            AggregateException exist = new AggregateException();
            mockTouristPointLogic.Setup(p => p.Add(touristPointWithId1)).Throws(exist);

            var result = controllerTouristPoint.Post(touristPointModel);

            mockTouristPointLogic.VerifyAll();
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
                Categories = new List<int>() { 1 }
            };
            touristPointWithId1 = touristPointModel.ToEntity();
            Exception exist = new ArgumentException();
            mockTouristPointLogic.Setup(p => p.Add(touristPointWithId1)).Throws(exist);

            var result = controllerTouristPoint.Post(touristPointModel);

            mockTouristPointLogic.VerifyAll();
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestPostFailServer()
        {
            TouristPointModel touristPointModel = new TouristPointModel()
            {
                Name = "name",
                Image = "image.png",
                Description = "description",
                RegionId = 1,
                Categories = new List<int>() { 1 }
            };
            touristPointWithId1 = touristPointModel.ToEntity();
            Exception exist = new Exception();
            mockTouristPointLogic.Setup(p => p.Add(touristPointWithId1)).Throws(exist);

            var result = controllerTouristPoint.Post(touristPointModel);

            mockTouristPointLogic.VerifyAll();
        }
        [TestMethod]
        public void TestPutOk()
        {
            TouristPointModel touristPointModel = new TouristPointModel()
            {
                Name = "new name tourist point",
                Image = "image.png",
                Description = "description",
                RegionId = 1, 
                Categories = new List<int>() { 1 }
            };
            TouristPoint anotherTouristPoint = touristPointModel.ToEntity();
            anotherTouristPoint.CategoriesTouristPoints[0] = new CategoryTouristPoint()
            {
                Id = 1,
                CategoryId = 1,
                TouristPoint = touristPointWithId1,
                TouristPointId = 1,
                Category = new Category() { Id = 1, Name = "Name category" },
            };
            anotherTouristPoint.Region = new Region() { Id = 1, Name = "RegionName" };
            int id = anotherTouristPoint.Id;
            mockTouristPointLogic.Setup(m => m.Update(id, anotherTouristPoint)).Returns(anotherTouristPoint);
            TouristPointDetailInfoModel touristPointBasicModel = new TouristPointDetailInfoModel(anotherTouristPoint);

            var result = controllerTouristPoint.Put(id, touristPointModel);

            var okResult = result as CreatedAtRouteResult;
            mockTouristPointLogic.VerifyAll();
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
                Categories = new List<int>() { 1 }
            };
            touristPointWithId1 = touristPointModel.ToEntity();
            Exception exist = new ArgumentException();
            mockTouristPointLogic.Setup(p => p.Update(touristPointWithId1.Id, touristPointWithId1)).Throws(exist);

            var result = controllerTouristPoint.Put(touristPointWithId1.Id, touristPointModel);

            mockTouristPointLogic.VerifyAll();
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
                Categories = new List<int>() { 1 }
            };
            touristPointWithId1 = touristPointModel.ToEntity();
            ArgumentException exist = new ArgumentException();
            mockTouristPointLogic.Setup(p => p.Update(touristPointWithId1.Id, touristPointWithId1)).Throws(exist);

            var result = controllerTouristPoint.Put(touristPointWithId1.Id, touristPointModel);

            mockTouristPointLogic.VerifyAll();
        }
        [TestMethod]
        public void TestDeleteWithId()
        {
            TouristPoint touristPoint = touristPointsToReturn.First();
            mockTouristPointLogic.Setup(m => m.GetBy(touristPoint.Id)).Returns(touristPoint);
            mockTouristPointLogic.Setup(mockTouristPointLogic => mockTouristPointLogic.Delete(touristPoint.Id));

            var result = controllerTouristPoint.Delete(touristPoint.Id);

            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestDeleteWithIdNotFound()
        {
            TouristPoint touristPoint = touristPointsToReturn.First();
            TouristPoint touristPointNull = null;
            mockTouristPointLogic.Setup(m => m.GetBy(touristPoint.Id)).Returns(touristPointNull);
            mockTouristPointLogic.Setup(mockTouristPointLogic => mockTouristPointLogic.Delete(touristPoint.Id));

            var result = controllerTouristPoint.Delete(touristPoint.Id);
        }

        [TestMethod]
        public void TestDelete()
        {
            mockTouristPointLogic.Setup(mockTouristPointLogic => mockTouristPointLogic.Delete());

            var result = controllerTouristPoint.Delete();

            Assert.IsNotNull(result);
        }
    }
}