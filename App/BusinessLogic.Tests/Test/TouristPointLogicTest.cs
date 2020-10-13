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
    public class TouristPointLogicTest
    {
        private TouristPointLogic touristPointLogic;
        private List<CategoryTouristPoint> categoriesTouristPoints;
        private Mock<ITouristPointRepository> mock;
        private Mock<ICategoryRepository> mock2;
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
                    CategoriesTouristPoints = new List<CategoryTouristPoint>
                    { new CategoryTouristPoint()
                        {
                            Id = 1,
                            CategoryId = 1,
                            TouristPointId = 1,
                            Category = new Category() {Id = 1}
                        }
                    }
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
            mock2 = new Mock<ICategoryRepository>(MockBehavior.Strict);
            touristPointLogic = new TouristPointLogic(mock.Object,mock2.Object);
            touristPointsEmpty = new List<TouristPoint>();
        }
        [TestMethod]
        public void TestGetAll()
        {
            mock.Setup(m => m.GetElements()).Returns(touristPoints);
            
            var result = touristPointLogic.GetAll();

            Assert.IsTrue(result.SequenceEqual(touristPoints));
        }
        [TestMethod]
        public void TestGetEmptyGetAll()
        {
            List<TouristPoint> touristPointEmpty = new List<TouristPoint>();
            mock.Setup(m => m.GetElements()).Returns(touristPointEmpty);

            var result = touristPointLogic.GetAll();

            Assert.AreEqual(touristPointEmpty, result);
        }
        [TestMethod]
        public void GetAll()
        {
            mock.Setup(m => m.GetElements()).Returns(touristPoints);

            var result = touristPointLogic.GetAll();

            Assert.IsTrue(result.SequenceEqual(touristPoints));
        }
        [TestMethod]
        public void TestGetBy()
        {
            TouristPoint touristPoint = touristPoints.First();
            mock.Setup(m => m.Find(touristPoint.Id)).Returns(touristPoint);

            var result = touristPointLogic.GetBy(touristPoint.Id);

            Assert.AreEqual(result,touristPoint);
        }
        [TestMethod]
        public void TestGetByFail()
        {
            TouristPoint touristPoint = touristPoints.First();
            TouristPoint empty = null;
            mock.Setup(m => m.Find(touristPoint.Id)).Returns(empty);

            var result = touristPointLogic.GetBy(touristPoint.Id);

            Assert.IsNull(result);
        }
        [TestMethod]
        public void TestAdd()
        {
            TouristPoint touristPoint = touristPoints.First();
            mock.Setup(m => m.Add(touristPoint)).Returns(touristPoint);
            //this.categoryRepository.Find(m.CategoryId)
            mock2.Setup(m => m.Find(touristPoint.CategoriesTouristPoints.First().CategoryId))
                .Returns(touristPoint.CategoriesTouristPoints.First().Category);

            TouristPoint touristPointToReturn = touristPointLogic.Add(touristPoint);

            Assert.AreEqual(touristPoint, touristPointToReturn );
        }
        [TestMethod]
        public void TestAddValidateError()
        {
            TouristPoint touristPoint = touristPoints.Last();
            mock.Setup(m => m.Add(touristPoint)).Returns(touristPoint);

            TouristPoint touristPointToReturn = touristPointLogic.Add(touristPoint);

            Assert.AreEqual(touristPoint, touristPointToReturn);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddExistError()
        {
            TouristPoint touristPoint = touristPoints.Last();
            ArgumentException exception = new ArgumentException();
            mock.Setup(m => m.Add(touristPoint)).Throws(exception);

            touristPointLogic.Add(touristPoint);

            mock.VerifyAll();
        }
        [TestMethod]
        public void TestUpdateOk ()
        {
            TouristPoint touristPoint = touristPoints.First();
            Category category = new Category(){Id = 1};
            mock.Setup(m => m.Update(touristPoint.Id,touristPoint));
            mock2.Setup(m => m.Find(category.Id)).Returns(category);
            mock.Setup(m => m.Find(touristPoint.Id)).Returns(touristPoint);

            TouristPoint result =  touristPointLogic.Update(touristPoint.Id,touristPoint);

            Assert.AreEqual(result, touristPoint);
        }
        [TestMethod]
        public void TestUpdateValidateError()
        {
            TouristPoint touristPoint = touristPoints.Last();
            mock.Setup(m => m.Update(touristPoint.Id,touristPoint));
            mock.Setup(m => m.Find(touristPoint.Id)).Returns(touristPoint);

            touristPointLogic.Update(touristPoint.Id,touristPoint);

            mock.VerifyAll();
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestUpdateExistError()
        {
            TouristPoint touristPoint = touristPoints.Last();
            ArgumentException exception = new ArgumentException();
            mock.Setup(m => m.Update(touristPoint.Id,touristPoint)).Throws(exception);
            mock.Setup(m => m.Find(touristPoint.Id)).Returns(touristPoint);

            touristPointLogic.Update(touristPoint.Id,touristPoint);

            mock.VerifyAll();
        }
        [TestMethod]
        public void TestExistOk()
        {
            TouristPoint touristPoint = touristPoints.First();
            mock.Setup(m => m.ExistElement(touristPoint)).Returns(true);

            bool touristPointToReturn = touristPointLogic.Exist(touristPoint);

            Assert.IsTrue(touristPointToReturn);
        }
        [TestMethod]
        public void TestNotExistOk()
        {
            TouristPoint touristPoint = touristPoints.First();
            mock.Setup(m => m.ExistElement(touristPoint)).Returns(false);

            bool touristPointToReturn = touristPointLogic.Exist(touristPoint);

            Assert.IsFalse(touristPointToReturn);
        }
        [TestMethod]
        public void TestDeleteById()
        {
            int lengthTouristPoint = touristPoints.Count;
            mock.Setup(m => m.Delete(touristPoints.First().Id));

            touristPointLogic.Delete(touristPoints.First().Id);

            mock.VerifyAll();
        }

        [TestMethod]
        public void TestDelete()
        {
            int lengthTouristPoint = touristPoints.Count;
            mock.Setup(m => m.GetElements()).Returns(touristPoints);
            foreach (TouristPoint t in touristPoints)
            {
                mock.Setup(m => m.Delete(t.Id));
            }

            touristPointLogic.Delete();

            mock.VerifyAll();
        }
        [TestMethod]
        public void TestDeleteEmpty()
        {
            mock.Setup(m => m.GetElements()).Returns(touristPointsEmpty);

            touristPointLogic.Delete();

            mock.VerifyAll();
        }
    }
}