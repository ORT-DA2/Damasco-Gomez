using System;
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
        public void TestAdd()
        {
            TouristPoint touristPoint = new TouristPoint(){Id = 123, Name="name new"};
            mockDbContext.Setup(d => d.Set<TouristPoint>()).Returns(mockSet.GetMockDbSet(touristPointsToReturn).Object);
            int touristPoints = touristPointsToReturn.Count();
            mockDbContext.Setup(d => d.SaveChanges()).Returns(touristPoint.Id);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new TouristPointRepository(repositoryMaster);

            repository.Add(touristPoint);

            Assert.AreEqual(touristPoints+1, touristPointsToReturn.Count());
        }
        [TestMethod]
        public void TestAddFailValidate()
        {
            TouristPoint touristPoint = new TouristPoint(){Id = 123, Name="name new"};
            int touristPointLenght = touristPointsToReturn.Count() ;
            mockDbContext.Setup(d => d.Set<TouristPoint>()).Returns(mockSet.GetMockDbSet(touristPointsToReturn).Object);
            mockDbContext.Setup(d => d.SaveChanges()).Returns(touristPoint.Id);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new TouristPointRepository(repositoryMaster);

            repository.Add(touristPoint);

            //Assert.AreEqual(touristPointLenght,repositoryMaster.TouristPoints.Count() + 1);
        }
        [TestMethod]
        public void TestAddFailExist()
        {
            TouristPoint touristPoint = touristPointsToReturn.First();
            ArgumentException exception = new ArgumentException();
            var _mockSet = mockSet.GetMockDbSet(touristPointsToReturn);
            _mockSet.Setup(d => d.Find(It.IsAny<TouristPoint>())).Throws(exception);
            mockDbContext.Setup(d => d.Set<TouristPoint>()).Returns(_mockSet.Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new TouristPointRepository(repositoryMaster);

            //repository.Add(touristPoint);

            //Assert.AreEqual();
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
        public void TestExistElement()
        {
            TouristPoint touristPoint = touristPointsToReturn.First();
            mockDbContext.Setup(d => d.Set<TouristPoint>()).Returns(mockSet.GetMockDbSet(touristPointsToReturn).Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new TouristPointRepository(repositoryMaster);

            bool result = repository.ExistElement(touristPoint);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestExistElementFail()
        {
            TouristPoint touristPoint = touristPointsToReturn.First();
            mockDbContext.Setup(d => d.Set<TouristPoint>()).Returns(mockSet.GetMockDbSet(emptyTouristPoint).Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new TouristPointRepository(repositoryMaster);

            bool result = repository.ExistElement(touristPoint);

            Assert.IsFalse(result);
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
        [TestMethod]
        public void TestExistById()
        {
            TouristPoint touristPoint = touristPointsToReturn.First();
            var _mockSet = mockSet.GetMockDbSet(touristPointsToReturn);
            _mockSet.Setup(d => d.Find(It.IsAny<object[]>())).Returns(touristPoint);
            mockDbContext.Setup(d => d.Set<TouristPoint>()).Returns(_mockSet.Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new TouristPointRepository(repositoryMaster);

            bool result = repository.ExistElement(touristPoint.Id);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestExistByIdFail()
        {
            TouristPoint touristPoint = new TouristPoint(){Id=123423};
            mockDbContext.Setup(d => d.Set<TouristPoint>()).Returns(mockSet.GetMockDbSet(touristPointsToReturn).Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new TouristPointRepository(repositoryMaster);

            bool result = repository.ExistElement(touristPoint.Id);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestFind()
        {
            TouristPoint touristPoint = touristPointsToReturn.First();
            var _mockSet = mockSet.GetMockDbSet(touristPointsToReturn);
            _mockSet.Setup(d => d.Find(It.IsAny<object[]>())).Returns(touristPoint);
            mockDbContext.Setup(d => d.Set<TouristPoint>()).Returns(_mockSet.Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new TouristPointRepository(repositoryMaster);

            TouristPoint result = repository.Find(touristPoint.Id);

            Assert.AreEqual(result,touristPoint);
        }

        [TestMethod]
        public void TestFindFail()
        {
            TouristPoint touristPoint = new TouristPoint(){Id=232323};
            TouristPoint touristPointNull = null;
            var _mockSet = mockSet.GetMockDbSet(touristPointsToReturn);
            ArgumentException exception = new ArgumentException();
            _mockSet.Setup(d => d.Find(It.IsAny<object[]>())).Returns(touristPointNull);
            mockDbContext.Setup(d => d.Set<TouristPoint>()).Returns(_mockSet.Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new TouristPointRepository(repositoryMaster);

            TouristPoint result = repository.Find(touristPoint.Id);

            Assert.IsNull(result);
        }
        [TestMethod]
        public void TestUpdate()
        {
            TouristPoint touristPoint = touristPointsToReturn.First();
            touristPoint.Name = "New name of touristPoint";
            string newName = touristPoint.Name;
            mockDbContext.Setup(d => d.Set<TouristPoint>()).Returns(mockSet.GetMockDbSet(touristPointsToReturn).Object);
            mockDbContext.Setup(d => d.SaveChanges()).Returns(touristPoint.Id);
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
            // Exception exception = new ArgumentException();
            mockDbContext.Setup(d => d.Set<TouristPoint>()).Returns(mockSet.GetMockDbSet(touristPointsToReturn).Object);
            mockDbContext.Setup(d => d.SaveChanges()).Returns(touristPointsToReturn.First().Id);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new TouristPointRepository(repositoryMaster);

            repository.Update(touristPoint);

            // Assert.IsInstanceOfType(result, typeof(Exception));
        }
        [TestMethod]
        public void TestDelete()
        {
            TouristPoint touristPoint = touristPointsToReturn.First();
            int lengthTouristPoints = touristPointsToReturn.Count();
            mockDbContext.Setup(d => d.Set<TouristPoint>()).Returns(mockSet.GetMockDbSet(touristPointsToReturn).Object);
            mockDbContext.Setup(d => d.SaveChanges()).Returns(touristPoint.Id);
            mockDbContext.Setup(d => d.Remove(touristPoint));
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new TouristPointRepository(repositoryMaster);

            repository.Delete(touristPoint);

            //Assert.AreEqual(touristPointsToReturn.Count, lengthTouristPoints - 1 );
        }
        [TestMethod]
        public void TestDeleteFailExist()
        {
            TouristPoint touristPoint = touristPointsToReturn.First();
            int lengthTouristPoints = touristPointsToReturn.Count();
            mockDbContext.Setup(d => d.Set<TouristPoint>()).Returns(mockSet.GetMockDbSet(touristPointsToReturn).Object);
            mockDbContext.Setup(d => d.SaveChanges()).Returns(touristPoint.Id);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new TouristPointRepository(repositoryMaster);

            repository.Delete(touristPoint);

            //Assert.AreEqual(touristPointsToReturn.Count, lengthTouristPoints - 1 );
        }
        [TestMethod]
        public void TestDeleteById()
        {
            TouristPoint touristPoint = touristPointsToReturn.First();
            int lengthTouristPoints = touristPointsToReturn.Count();
            var _mockSet = mockSet.GetMockDbSet(touristPointsToReturn);
            _mockSet.Setup(d => d.Find(It.IsAny<object[]>())).Returns(touristPoint);
            mockDbContext.Setup(d => d.Set<TouristPoint>()).Returns(_mockSet.Object);
            mockDbContext.Setup(d => d.SaveChanges()).Returns(touristPoint.Id);
            //mockDbContext.Setup(d => d.Remove(touristPoint.Id));
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new TouristPointRepository(repositoryMaster);

            repository.Delete(touristPoint.Id);

            //Assert.AreEqual(touristPointsToReturn.Count, lengthTouristPoints - 1 );
        }
        [TestMethod]
        public void TestDeleteByIdFailExist()
        {
            TouristPoint touristPoint = touristPointsToReturn.First();
            TouristPoint touristPointNull = null;
            int lengthTouristPoints = touristPointsToReturn.Count();
            var _mockSet = mockSet.GetMockDbSet(touristPointsToReturn);
            _mockSet.Setup(d => d.Find(It.IsAny<object[]>())).Returns(touristPointNull);
            mockDbContext.Setup(d => d.Set<TouristPoint>()).Returns(_mockSet.Object);
            mockDbContext.Setup(d => d.SaveChanges()).Returns(touristPoint.Id);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new TouristPointRepository(repositoryMaster);

            //repository.Delete(touristPoint.Id);

            //Assert.AreEqual(touristPointsToReturn.Count, lengthTouristPoints - 1 );
        }
    }
}