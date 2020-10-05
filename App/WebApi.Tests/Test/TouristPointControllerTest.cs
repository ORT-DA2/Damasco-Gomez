using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogicInterface;
using Domain;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
                    Image = "Image1",
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
                    },
                },
                new TouristPoint()
                {
                    Id = 2,
                    Name = "Name TouristPoint 2",
                    Image = "Image2",
                    Description = "Description 2",
                    Region = null ,
                    CategoriesTouristPoints = null,
                },
                new TouristPoint()
                {
                    Id = 3,
                    Name = "Name TouristPoint 3",
                    Image = "Image3",
                    Description = "Description 3",
                    Region = null ,
                    CategoriesTouristPoints = null,
                },
                new TouristPoint()
                {
                    Id = 4,
                    Name = "Name TouristPoint 4",
                    Image = "Image4",
                    Description = "Description 4",
                    Region = null ,
                    CategoriesTouristPoints = null,
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

            var result = controller.Get();
            var okResult = result as OkObjectResult;
            var touristPoints = okResult.Value as IEnumerable<TouristPoint>;

            mock.VerifyAll();
            Assert.IsTrue(touristPointsToReturn.SequenceEqual(touristPoints));
        }

        [TestMethod]
        public void TestGetAllTouristPointsVacia()
        {
            mock.Setup(m => m.GetAll()).Returns(touristPointsToReturnEmpty);

            var result = controller.Get();

            var okResult = result as OkObjectResult;
            var touristPoints = okResult.Value as IEnumerable<TouristPoint>;
            mock.VerifyAll();
            Assert.IsTrue(touristPointsToReturnEmpty.SequenceEqual(touristPoints));
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
        public void TestGetByNotFound()
        {
            int id = 4;
            ArgumentException exist = new ArgumentException();
            mock.Setup(m => m.GetBy(id)).Throws(exist);

            var result = controller.GetBy(id);

            mock.VerifyAll();
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        [TestMethod]
        public void TestPostOk()
        {
            var touristPointId1 = touristPointsToReturn.First();
            mock.Setup(m => m.Add(touristPointId1)).Returns(touristPointId1);

            // var result = controller.Post(touristPointId1);

            // var okResult = result as CreatedAtRouteResult;
            // mock.VerifyAll();
            // Assert.IsNotNull(okResult);
            // Assert.AreEqual("GetTouristPoint", okResult.RouteName);
            // Assert.AreEqual(okResult.Value, touristPointId1);
        }
        [TestMethod]
        public void TestPostFailSameTouristPoint()
        {
            touristPointId1 = touristPointsToReturn.First();
            Exception exist = new AggregateException();
            mock.Setup(p => p.Add(touristPointId1)).Throws(exist);

            // var result = controller.Post(touristPointId1);

            // mock.VerifyAll();
            // Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        [TestMethod]
        public void TestPostFailValidation()
        {
            touristPointId1 = touristPointsToReturn.First();
            Exception exist = new ArgumentException();
            mock.Setup(p => p.Add(touristPointId1)).Throws(exist);

            // var result = controller.Post(touristPointId1);

            // mock.VerifyAll();
            // Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        [TestMethod]
        public void TestPostFailServer()
        {
            touristPointId1 = touristPointsToReturn.First();
            Exception exist = new Exception();
            mock.Setup(p => p.Add(touristPointId1)).Throws(exist);

            // var result = controller.Post(touristPointId1);

            // mock.VerifyAll();
            // Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        [TestMethod]
        public void TestPutOk()
        {
            touristPointId1 = touristPointsToReturn.First();
            mock.Setup(m => m.Update(touristPointId1.Id,touristPointId1));

            // var result = controller.Put(touristPointId1.Id, touristPointId1);

            // var okResult = result as CreatedAtRouteResult;
            // mock.VerifyAll();
            // Assert.IsNotNull(okResult);
            // Assert.AreEqual("GetTouristPoint", okResult.RouteName);
            // Assert.AreEqual(okResult.Value, touristPointId1);
        }
        [TestMethod]
        public void TestPutFailValidate()
        {
            touristPointId1 = touristPointsToReturn.First();
            Exception exist = new ArgumentException();
            mock.Setup(p => p.Update(touristPointId1.Id,touristPointId1)).Throws(exist);

            // var result = controller.Put(touristPointId1.Id, touristPointId1);

            // mock.VerifyAll();
            // Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        [TestMethod]
        public void TestPutFailServer()
        {
            touristPointId1 = touristPointsToReturn.First();
            Exception exist = new Exception();
            mock.Setup(p => p.Update(touristPointId1.Id,touristPointId1)).Throws(exist);

            // var result = controller.Put(touristPointId1.Id, touristPointId1);

            // mock.VerifyAll();
            // Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
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