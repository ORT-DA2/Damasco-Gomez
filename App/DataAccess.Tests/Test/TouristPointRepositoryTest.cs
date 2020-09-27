using System.Collections.Generic;
using System.Linq;
using DataAccess.Context;
using DataAccess.Repositories;
using DataAccess.Tests.Utils;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DataAccess.Tests.Test
{
    [TestClass]
    public class TouristPointRepositoryTest
    {
        private List<TouristPoint> touristPointsToReturn;
        private List<TouristPoint> touristPointsToReturnEmpty;
        private RepositoryMaster repositoryMaster;
        private VidlyContext context;
        private VidlyDbSet<TouristPoint> mockSet;
        private Mock<DbContext> mockDbContext;
        private TouristPointRepository repository;
        private List<TouristPoint> emptyTouristPoint;
        [TestInitialize]
        public void initVariables()
        {
            touristPointsToReturn = new List<TouristPoint>()
            {
                new TouristPoint()
                {
                    Id = 1,
                    Name = "New touristPoint",
                },
                new TouristPoint()
                {
                    Id = 2,
                    Name = "Other touristPoint",
                },
                new TouristPoint()
                {
                    Id = 3,
                    Name = "And other touristPoint",
                },
                new TouristPoint()
                {
                    Id = 4,
                    Name = "And one more touristPoint",
                }
            };
            emptyTouristPoint = new List<TouristPoint>();
            mockSet = new VidlyDbSet<TouristPoint>();
            mockDbContext = new Mock<DbContext>(MockBehavior.Strict);
        }
        [TestMethod]
        public void TestGetAllTouristPointsOk()
        {
            mockDbContext.Setup(d => d.Set<TouristPoint>()).Returns(mockSet.GetMockDbSet(touristPointsToReturn).Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new TouristPointRepository(repositoryMaster);
            var result = repository.GetElements();
            Assert.IsTrue(touristPointsToReturn.SequenceEqual(result));
        }
        [TestMethod]
        public void TestGetAllTouristPointsNull()
        {
            List<TouristPoint> emptyTouristPoint = new List<TouristPoint>();
            mockDbContext.Setup(d => d.Set<TouristPoint>()).Returns(mockSet.GetMockDbSet(emptyTouristPoint).Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new TouristPointRepository(repositoryMaster);
            var result = repository.GetElements();
            Assert.IsTrue(emptyTouristPoint.SequenceEqual(result));
        }
        [TestMethod]
        public void TestExistNot()
        {
            TouristPoint touristPoint = touristPointsToReturn.First();
            mockDbContext.Setup(d => d.Set<TouristPoint>()).Returns(mockSet.GetMockDbSet(emptyTouristPoint).Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new TouristPointRepository(repositoryMaster);
            bool result = repository.ExistElement(touristPoint);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestExist()
        {
            TouristPoint touristPoint = touristPointsToReturn.First();
            mockDbContext.Setup(d => d.Set<TouristPoint>()).Returns(mockSet.GetMockDbSet(touristPointsToReturn).Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new TouristPointRepository(repositoryMaster);
            bool result = repository.ExistElement(touristPoint);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestExistWithIdFail()
        {
            int touristPointId = touristPointsToReturn.First().Id;
            mockDbContext.Setup(d => d.Set<TouristPoint>()).Returns(mockSet.GetMockDbSet(touristPointsToReturn).Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new TouristPointRepository(repositoryMaster);
            bool result = repository.ExistElement(touristPointId);
            Assert.IsFalse(result);
        }
        // [TestMethod]
        // public void TestExistTouristPointById()
        // {
        //     TouristPoint touristPoint = touristPointsToReturn.First();
        //     mockDbContext.Setup(d => d.Set<TouristPoint>()).Returns(mockSet.GetMockDbSet(touristPointsToReturn).Object);
        //     repositoryMaster = new RepositoryMaster(mockDbContext.Object);
        //     repository = new TouristPointRepository(repositoryMaster);
        //     bool result = repository.ExistElement(touristPoint.Id);
        //     Assert.IsTrue(result);
        // }
        [TestMethod]
        public void TestExistTouristPoint()
        {
            TouristPoint touristPoint = touristPointsToReturn.First();
            mockDbContext.Setup(d => d.Set<TouristPoint>()).Returns(mockSet.GetMockDbSet(touristPointsToReturn).Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new TouristPointRepository(repositoryMaster);
            bool result = repository.ExistElement(touristPoint);
            Assert.IsTrue(result);
        }
        // [TestMethod]
        // public void TestFind()
        // {
        //     TouristPoint touristPoint = touristPointsToReturn.First();
        //     mockDbContext.Setup(d => d.Set<TouristPoint>()).Returns(mockSet.GetMockDbSet(touristPointsToReturn).Object);
        //     repositoryMaster = new RepositoryMaster(mockDbContext.Object);
        //     repository = new TouristPointRepository(repositoryMaster);
        //     TouristPoint result = repository.Find(touristPoint.Id);
        //     Assert.AreEqual(result,touristPoint);
        // }

        [TestMethod]
        public void TestFindFail()
        {
            TouristPoint touristPoint = touristPointsToReturn.First();
            mockDbContext.Setup(d => d.Set<TouristPoint>()).Returns(mockSet.GetMockDbSet(touristPointsToReturn).Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new TouristPointRepository(repositoryMaster);
            TouristPoint result = repository.Find(touristPoint.Id + 1000);
            // Exception exception = new ArgumentException();
            // Assert.IsInstanceOfType(result, typeof(Exception));
            Assert.IsNull(result);
        }
        [TestMethod]
        public void TestUpdate()
        {
            TouristPoint touristPoint = touristPointsToReturn.First();
            touristPoint.Name = "New name of touristPoint";
            string newName = touristPoint.Name;
            mockDbContext.Setup(d => d.Set<TouristPoint>()).Returns(mockSet.GetMockDbSet(touristPointsToReturn).Object);
            mockDbContext.Setup(d => d.SaveChanges()).Returns(touristPointsToReturn.First().Id);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new TouristPointRepository(repositoryMaster);
            repository.Update(touristPoint);
            Assert.AreEqual(touristPoint.Name,newName);
        }
        [TestMethod]
        public void TestUpdateFail()
        {
            TouristPoint touristPoint = new TouristPoint(){Id = 13000};
            string newName = touristPoint.Name;
            mockDbContext.Setup(d => d.Set<TouristPoint>()).Returns(mockSet.GetMockDbSet(touristPointsToReturn).Object);
            mockDbContext.Setup(d => d.SaveChanges()).Returns(touristPointsToReturn.First().Id);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new TouristPointRepository(repositoryMaster);
            repository.Update(touristPoint);
            // Exception exception = new ArgumentException();
            // Assert.IsInstanceOfType(result, typeof(Exception));
        }
    }
}