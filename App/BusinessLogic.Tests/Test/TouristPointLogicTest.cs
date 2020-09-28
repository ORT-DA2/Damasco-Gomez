using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessInterface.Repositories;
using Domain;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BusinessLogic.Tests.Test
{
    [TestClass]
    public class TouristPointLogicTest
    {
        private TouristPointLogic touristPointLogic;
        private List<CategoryTouristPoint> categoriesTouristPoints;
        private Mock<ITouristPointRepository> mock;
        private List<TouristPoint> touristPoints;
        private List<TouristPoint> touristPointsEmpty;
        [TestInitialize]
        public void Initialize ()
        {
            touristPoints = new List<TouristPoint>()
            {
                new TouristPoint()
                {
                    Id = 1,
                    Name = "New pointTurist",
                    Image = null,
                    Description = "one",
                    RegionId = 3,
                    Region = null,
                    CategoriesTouristPoints = null,
                },
                new TouristPoint()
                {
                    Id = 2,
                    Name = "Other pointTurist",
                    Image = null,
                    Description = "two",
                    RegionId = 1,
                    Region = null,
                     CategoriesTouristPoints = null,
                },
                new TouristPoint()
                {
                    Id = 3,
                    Name = "And other pointTurist",
                    Image = null,
                    Description = "three",
                    RegionId = 1,
                    Region = null,
                    CategoriesTouristPoints = null,
                },
                new TouristPoint()
                {
                    Id = 4,
                    Name = "And one more pointTurist",
                    Image = null,
                    Description = "four",
                    RegionId = 2,
                    Region = null,
                    CategoriesTouristPoints = null,
                }
            };
            mock = new Mock<ITouristPointRepository>(MockBehavior.Strict);
            touristPointLogic = new TouristPointLogic(mock.Object);
            touristPointsEmpty = new List<TouristPoint>();
        }
        [TestMethod]
        public void TestGetAll()
        {
            mock.Setup(m => m.GetElements()).Returns(touristPoints);
            var result = touristPointLogic.GetAll();
            mock.VerifyAll();
            Assert.IsTrue(result.SequenceEqual(touristPoints));
        }
        [TestMethod]
        public void TestGetBy()
        {
            TouristPoint touristPoint = touristPoints.First();
            mock.Setup(m => m.Find(touristPoint.Id)).Returns(touristPoint);
            var result = touristPointLogic.GetBy(touristPoint.Id);
            mock.VerifyAll();
            Assert.AreEqual(result,touristPoint);
        }
        [TestMethod]
        public void TestGetByFail()
        {
            TouristPoint touristPoint = touristPoints.First();
            TouristPoint empty = null;
            mock.Setup(m => m.Find(touristPoint.Id)).Returns(empty);
            var result = touristPointLogic.GetBy(touristPoint.Id);
            mock.VerifyAll();
            Assert.IsNull(result);
        }
        [TestMethod]
        public void TestAdd()
        {
            TouristPoint touristPoint = touristPoints.First();
            mock.Setup(m => m.Add(touristPoint)).Returns(touristPoint);
            var touristPointToReturn = touristPointLogic.Add(touristPoint);
            mock.VerifyAll();
            Assert.AreEqual(touristPointLogic, touristPointToReturn );
        }
        [TestMethod]
        public void TestAddValidateError()
        {
            TouristPoint touristPoint = touristPoints.First(); // este punto turistico tiene que terner un formato erroneo despues para que la validación falle
            mock.Setup(m => m.Add(touristPoint)).Returns(touristPoint);
            var touristPointToReturn = touristPointLogic.Add(touristPoint);
            mock.VerifyAll();
            Assert.AreEqual(touristPointLogic, touristPointToReturn); 
        }
        [TestMethod]
        public void TestAddExistError()
        {
            TouristPoint touristPoint = touristPoints.First();
            ArgumentException exception = new ArgumentException();
            mock.Setup(m => m.Add(touristPoint)).Throws(exception);
            var touristPointToReturn = touristPointLogic.Add(touristPoint);
            mock.VerifyAll();
            Assert.IsInstanceOfType(touristPointToReturn, typeof(ArgumentException));
        }

    }
}