using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogicInterface;
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
            var mock2 = new Mock<ICategoryLogic>(MockBehavior.Strict);
            touristPointLogic = new TouristPointLogic(mock.Object,mock2.Object);
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
         public void TestGetEmptyGetAll()
        {
            List<TouristPoint> touristPointEmpty = new List<TouristPoint>();
            mock.Setup(m => m.GetElements()).Returns(touristPointEmpty);
            var result = touristPointLogic.GetAll();
            mock.VerifyAll();
            Assert.AreEqual(touristPointEmpty, result);
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

            Assert.AreEqual(touristPoint, touristPointToReturn );
        }
        [TestMethod]
        public void TestAddValidateError()
        {
            TouristPoint touristPoint = touristPoints.First(); // este punto turistico tiene que terner un formato erroneo despues para que la validación falle
            mock.Setup(m => m.Add(touristPoint)).Returns(touristPoint);
            var touristPointToReturn = touristPointLogic.Add(touristPoint);
            mock.VerifyAll();
            Assert.AreEqual(touristPoint, touristPointToReturn); 
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddExistError()
        {
            TouristPoint touristPoint = touristPoints.First();
            ArgumentException exception = new ArgumentException();
            mock.Setup(m => m.Add(touristPoint)).Throws(exception);

            var touristPointToReturn = touristPointLogic.Add(touristPoint);
        }
        [TestMethod]
        public void TestUdpateOk ()
        {
            TouristPoint touristPoint = touristPoints.First();
            mock.Setup(m => m.Update(touristPoint.Id,touristPoint));
            touristPointLogic.Update(touristPoint.Id,touristPoint);
            mock.VerifyAll();
            
        }
         [TestMethod]
        public void TestUpdateValidateError()
        {
            TouristPoint touristPoint = touristPoints.First(); // este punto turistico tiene que terner un formato erroneo despues para que la validación falle
            mock.Setup(m => m.Update(touristPoint.Id,touristPoint));
            touristPointLogic.Update(touristPoint.Id,touristPoint);
            mock.VerifyAll();
            
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestUpdateExistError()
        {
            TouristPoint touristPoint = touristPoints.First();
            ArgumentException exception = new ArgumentException();
            mock.Setup(m => m.Update(touristPoint.Id,touristPoint)).Throws(exception);
            
            touristPointLogic.Update(touristPoint.Id,touristPoint);
   
        }
        [TestMethod]
        public void TestExistOk()
        {
            TouristPoint touristPoint = touristPoints.First();
            mock.Setup(m => m.ExistElement(touristPoint)).Returns(true);
            var touristPointToReturn = touristPointLogic.Exist(touristPoint);
            mock.VerifyAll();
            Assert.IsTrue(touristPointToReturn);
        }
        [TestMethod]
        public void TestNotExistOk()
        {
            TouristPoint touristPoint = touristPoints.First();
            mock.Setup(m => m.ExistElement(touristPoint)).Returns(false);
            var touristPointToReturn = touristPointLogic.Exist(touristPoint);
            mock.VerifyAll();
            Assert.IsFalse(touristPointToReturn);
        }
        /*[TestMethod]*/
        /*public void TestDeleteById ()
        {
            int id= 1;
            TouristPoint touristPoint = touristPoints.First();
            TouristPoint touristPoint2 = touristPoints.Second();
            int lengthTouristPoint = touristPoints.Count();
            mock.Setup(m => m.Add(id)).Returns(touristPoint);
            mock.Setup(m => m.Add(id)).Returns(touristPoint);
            mock.Setup(m => m.Delete(id));
            touristPointLogic.Delete(touristPoint);
            mock.VerifyAll();
            Assert.AreEqual(touristPoints.Count, lengthTouristPoint - 1 );
        }*/
/*
         [TestMethod]
        public void TestDeleteFail ()
        {
            var int id= 1;
            TouristPoint touristPoint = touristPoints.First();
            mock.Setup(m => m.Delete(id));
            touristPointLogic.Delete(touristPoint);
            mock.VerifyAll();
           // Assert.IsInstanceOfType(touristPointToReturn, typeof(ArgumentException));
            
        }*/


    }
}