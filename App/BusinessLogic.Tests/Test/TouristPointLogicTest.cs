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
        private Mock<ITouristPointRepository> mockTouristPointRepository;
        private Mock<ICategoryRepository> mockCategoryRepository;
        private Mock<IImageTouristPointRepository> mockImageTouristPointRepository;
        private Mock<IRegionRepository> mockRegionRepository;
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
                    ImageTouristPoint = null,
                    Description = "one",
                    RegionId = 3,
                    Region = new Region(){Id = 3},
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
                    ImageTouristPoint = null,
                    Description = "two",
                    RegionId = 1,
                    Region = null,
                    CategoriesTouristPoints = null,
                },
                new TouristPoint()
                {
                    Id = 3,
                    Name = "And other pointTurist",
                    ImageTouristPoint = null,
                    Description = "three",
                    RegionId = 1,
                    Region = null,
                    CategoriesTouristPoints = null,
                },
                new TouristPoint()
                {
                    Id = 4,
                    Name = "And one more pointTurist",
                    ImageTouristPoint = null,
                    Description = "four",
                    RegionId = 2,
                    Region = new Region(){Id=2},
                    CategoriesTouristPoints = null,
                }
            };
            mockTouristPointRepository = new Mock<ITouristPointRepository>(MockBehavior.Strict);
            mockCategoryRepository = new Mock<ICategoryRepository>(MockBehavior.Strict);
            mockImageTouristPointRepository = new Mock<IImageTouristPointRepository>(MockBehavior.Strict);
            mockRegionRepository = new Mock<IRegionRepository>(MockBehavior.Strict);
            touristPointLogic = new TouristPointLogic(mockTouristPointRepository.Object,mockCategoryRepository.Object,mockImageTouristPointRepository.Object,mockRegionRepository.Object);
            touristPointsEmpty = new List<TouristPoint>();
        }
        [TestMethod]
        public void TestGetAll()
        {
            mockTouristPointRepository.Setup(m => m.GetElements()).Returns(touristPoints);
            
            var result = touristPointLogic.GetAll();

            Assert.IsTrue(result.SequenceEqual(touristPoints));
        }
        [TestMethod]
        public void TestGetEmptyGetAll()
        {
            List<TouristPoint> touristPointEmpty = new List<TouristPoint>();
            mockTouristPointRepository.Setup(m => m.GetElements()).Returns(touristPointEmpty);

            var result = touristPointLogic.GetAll();

            Assert.AreEqual(touristPointEmpty, result);
        }
        [TestMethod]
        public void GetAll()
        {
            mockTouristPointRepository.Setup(m => m.GetElements()).Returns(touristPoints);

            var result = touristPointLogic.GetAll();

            Assert.IsTrue(result.SequenceEqual(touristPoints));
        }
        [TestMethod]
        public void TestGetBy()
        {
            TouristPoint touristPoint = touristPoints.First();
            mockTouristPointRepository.Setup(m => m.Find(touristPoint.Id)).Returns(touristPoint);

            var result = touristPointLogic.GetBy(touristPoint.Id);

            Assert.AreEqual(result,touristPoint);
        }
        [TestMethod]
        public void TestGetByFail()
        {
            TouristPoint touristPoint = touristPoints.First();
            TouristPoint empty = null;
            mockTouristPointRepository.Setup(m => m.Find(touristPoint.Id)).Returns(empty);

            var result = touristPointLogic.GetBy(touristPoint.Id);

            Assert.IsNull(result);
        }
        [TestMethod]
        public void TestAdd()
        {
            TouristPoint touristPoint = touristPoints.First();
            mockTouristPointRepository.Setup(m => m.Add(touristPoint)).Returns(touristPoint);
            mockCategoryRepository.Setup(m => m.Find(touristPoint.CategoriesTouristPoints.First().CategoryId))
                .Returns(touristPoint.CategoriesTouristPoints.First().Category);
            mockRegionRepository.Setup(m => m.Find(touristPoint.RegionId)).Returns(touristPoint.Region);

            TouristPoint touristPointToReturn = touristPointLogic.Add(touristPoint);

            Assert.AreEqual(touristPoint, touristPointToReturn );
        }
        [TestMethod]
        public void TestAddValidateError()
        {
            TouristPoint touristPoint = touristPoints.Last();
            mockTouristPointRepository.Setup(m => m.Add(touristPoint)).Returns(touristPoint);
            mockRegionRepository.Setup(m => m.Find(touristPoint.RegionId)).Returns(touristPoint.Region);

            TouristPoint touristPointToReturn = touristPointLogic.Add(touristPoint);

            Assert.AreEqual(touristPoint, touristPointToReturn);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddExistError()
        {
            TouristPoint touristPoint = touristPoints.Last();
            ArgumentException exception = new ArgumentException();
            mockTouristPointRepository.Setup(m => m.Add(touristPoint)).Throws(exception);
            mockRegionRepository.Setup(m => m.Find(touristPoint.RegionId)).Returns(touristPoint.Region);

            touristPointLogic.Add(touristPoint);

            mockTouristPointRepository.VerifyAll();
        }
        [TestMethod]
        public void TestUpdateOk ()
        {
            TouristPoint touristPoint = touristPoints.First();
            Category category = new Category(){Id = 1};
            mockTouristPointRepository.Setup(m => m.Update(touristPoint.Id,touristPoint));
            mockCategoryRepository.Setup(m => m.Find(category.Id)).Returns(category);
            mockTouristPointRepository.Setup(m => m.Find(touristPoint.Id)).Returns(touristPoint);
            mockRegionRepository.Setup(m => m.Find(touristPoint.RegionId)).Returns(touristPoint.Region);

            TouristPoint result =  touristPointLogic.Update(touristPoint.Id,touristPoint);

            Assert.AreEqual(result, touristPoint);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestUpdateValidateError()
        {
            TouristPoint touristPoint = touristPoints.Last();
            mockTouristPointRepository.Setup(m => m.Update(touristPoint.Id,touristPoint));
            mockTouristPointRepository.Setup(m => m.Find(touristPoint.Id)).Returns(touristPoint);
            mockRegionRepository.Setup(m => m.Find(touristPoint.RegionId)).Throws(new ArgumentException());

            touristPointLogic.Update(touristPoint.Id,touristPoint);

            mockTouristPointRepository.VerifyAll();
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestUpdateExistError()
        {
            TouristPoint touristPoint = touristPoints.Last();
            touristPoint.RegionId = 0;
            ArgumentException exception = new ArgumentException();
            mockTouristPointRepository.Setup(m => m.Update(touristPoint.Id,touristPoint)).Throws(exception);
            mockTouristPointRepository.Setup(m => m.Find(touristPoint.Id)).Returns(touristPoint);

            touristPointLogic.Update(touristPoint.Id,touristPoint);

            mockTouristPointRepository.VerifyAll();
        }
        [TestMethod]
        public void TestExistOk()
        {
            TouristPoint touristPoint = touristPoints.First();
            mockTouristPointRepository.Setup(m => m.ExistElement(touristPoint)).Returns(true);

            bool touristPointToReturn = touristPointLogic.Exist(touristPoint);

            Assert.IsTrue(touristPointToReturn);
        }
        [TestMethod]
        public void TestNotExistOk()
        {
            TouristPoint touristPoint = touristPoints.First();
            mockTouristPointRepository.Setup(m => m.ExistElement(touristPoint)).Returns(false);

            bool touristPointToReturn = touristPointLogic.Exist(touristPoint);

            Assert.IsFalse(touristPointToReturn);
        }
        [TestMethod]
        public void TestDeleteById()
        {
            int lengthTouristPoint = touristPoints.Count;
            mockTouristPointRepository.Setup(m => m.Delete(touristPoints.First().Id));

            touristPointLogic.Delete(touristPoints.First().Id);

            mockTouristPointRepository.VerifyAll();
        }

        [TestMethod]
        public void TestDelete()
        {
            int lengthTouristPoint = touristPoints.Count;
            mockTouristPointRepository.Setup(m => m.GetElements()).Returns(touristPoints);
            foreach (TouristPoint t in touristPoints)
            {
                mockTouristPointRepository.Setup(m => m.Delete(t.Id));
            }

            touristPointLogic.Delete();

            mockTouristPointRepository.VerifyAll();
        }
        [TestMethod]
        public void TestDeleteEmpty()
        {
            mockTouristPointRepository.Setup(m => m.GetElements()).Returns(touristPointsEmpty);

            touristPointLogic.Delete();

            mockTouristPointRepository.VerifyAll();
        }
    }
}