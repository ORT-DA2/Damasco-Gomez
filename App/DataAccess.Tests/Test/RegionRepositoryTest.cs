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

namespace DataAccess.Tests
{
    [TestClass]
    public class RegionRepositoryTest
    {
        private List<Region> regionsToReturn;
        private RepositoryMaster repositoryMaster;
        private VidlyDbSet<Region> mockSet;
        private Mock<DbContext> mockDbContext;
        private RegionRepository repository;
        private List<Region> emptyRegion;
        [TestInitialize]
        public void initVariables()
        {
            regionsToReturn = new List<Region>()
            {
                new Region()
                {
                    Id = 1,
                    Name = "New region",
                },
                new Region()
                {
                    Id = 2,
                    Name = "Other region",
                },
                new Region()
                {
                    Id = 3,
                    Name = "And other region",
                },
                new Region()
                {
                    Id = 4,
                    Name = "And one more region",
                }
            };
            emptyRegion = new List<Region>();
            mockSet = new VidlyDbSet<Region>();
            mockDbContext = new Mock<DbContext>(MockBehavior.Strict);
        }
        [TestMethod]
        public void TestAdd()
        {
            Region region = new Region(){Id = 123, Name="name new"};
            mockDbContext.Setup(d => d.Set<Region>()).Returns(mockSet.GetMockDbSet(regionsToReturn).Object);
            mockDbContext.Setup(d => d.SaveChanges()).Returns(region.Id);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new RegionRepository(repositoryMaster);

            var result = repository.Add(region);

            Assert.AreEqual(result, region);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddFailValidate()
        {
            Region region = regionsToReturn.First();
            mockDbContext.Setup(d => d.Set<Region>()).Returns(mockSet.GetMockDbSet(regionsToReturn).Object);
            mockDbContext.Setup(d => d.SaveChanges()).Returns(region.Id);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new RegionRepository(repositoryMaster);

            repository.Add(region);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddFailExist()
        {
            Region region = regionsToReturn.First();
            ArgumentException exception = new ArgumentException();
            var _mockSet = mockSet.GetMockDbSet(regionsToReturn);
            _mockSet.Setup(d => d.Find(It.IsAny<Region>())).Throws(exception);
            mockDbContext.Setup(d => d.Set<Region>()).Returns(_mockSet.Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new RegionRepository(repositoryMaster);

            repository.Add(region);
        }
        [TestMethod]
        public void TestGetAllRegionsOk()
        {
            mockDbContext.Setup(d => d.Set<Region>()).Returns(mockSet.GetMockDbSet(regionsToReturn).Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new RegionRepository(repositoryMaster);

            var result = repository.GetElements();

            Assert.IsTrue(regionsToReturn.SequenceEqual(result));
        }
        [TestMethod]
        public void TestGetAllRegionsNull()
        {
            List<Region> emptyRegion = new List<Region>();
            mockDbContext.Setup(d => d.Set<Region>()).Returns(mockSet.GetMockDbSet(emptyRegion).Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new RegionRepository(repositoryMaster);

            var result = repository.GetElements();

            Assert.IsTrue(emptyRegion.SequenceEqual(result));
        }
        [TestMethod]
        public void TestExistElement()
        {
            Region region = regionsToReturn.First();
            mockDbContext.Setup(d => d.Set<Region>()).Returns(mockSet.GetMockDbSet(regionsToReturn).Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new RegionRepository(repositoryMaster);

            bool result = repository.ExistElement(region);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestExistElementFail()
        {
            Region region = regionsToReturn.First();
            mockDbContext.Setup(d => d.Set<Region>()).Returns(mockSet.GetMockDbSet(emptyRegion).Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new RegionRepository(repositoryMaster);

            bool result = repository.ExistElement(region);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestExistWithIdFail()
        {
            int regionId = regionsToReturn.First().Id;
            mockDbContext.Setup(d => d.Set<Region>()).Returns(mockSet.GetMockDbSet(regionsToReturn).Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new RegionRepository(repositoryMaster);

            bool result = repository.ExistElement(regionId);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestExistById()
        {
            Region region = regionsToReturn.First();
            var _mockSet = mockSet.GetMockDbSet(regionsToReturn);
            _mockSet.Setup(d => d.Find(It.IsAny<object[]>())).Returns(region);
            mockDbContext.Setup(d => d.Set<Region>()).Returns(_mockSet.Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new RegionRepository(repositoryMaster);

            bool result = repository.ExistElement(region.Id);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestExistByIdFail()
        {
            Region region = new Region(){Id=123423};
            mockDbContext.Setup(d => d.Set<Region>()).Returns(mockSet.GetMockDbSet(regionsToReturn).Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new RegionRepository(repositoryMaster);

            bool result = repository.ExistElement(region.Id);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestFind()
        {
            Region region = regionsToReturn.First();
            var _mockSet = mockSet.GetMockDbSet(regionsToReturn);
            _mockSet.Setup(d => d.Find(It.IsAny<object[]>())).Returns(region);
            mockDbContext.Setup(d => d.Set<Region>()).Returns(_mockSet.Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new RegionRepository(repositoryMaster);

            Region result = repository.Find(region.Id);

            Assert.AreEqual(result,region);
        }

        [TestMethod]
        public void TestFindFail()
        {
            Region region = new Region(){Id=232323};
            Region regionNull = null;
            var _mockSet = mockSet.GetMockDbSet(regionsToReturn);
            ArgumentException exception = new ArgumentException();
            _mockSet.Setup(d => d.Find(It.IsAny<object[]>())).Returns(regionNull);
            mockDbContext.Setup(d => d.Set<Region>()).Returns(_mockSet.Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new RegionRepository(repositoryMaster);

            Region result = repository.Find(region.Id);

            Assert.IsNull(result);
        }
        [TestMethod]
        public void TestUpdate()
        {
            Region region = regionsToReturn.First();
            mockDbContext.Setup(d => d.Set<Region>()).Returns(mockSet.GetMockDbSet(regionsToReturn).Object);
            mockDbContext.Setup(d => d.SaveChanges()).Returns(region.Id);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new RegionRepository(repositoryMaster);

            repository.Update(region);
        }
        [TestMethod]
        //[ExpectedException(typeof(ArgumentException))]
        public void TestUpdateFail()
        {
            Region region = new Region(){Id = 13000};
            mockDbContext.Setup(d => d.Set<Region>()).Returns(mockSet.GetMockDbSet(regionsToReturn).Object);
            mockDbContext.Setup(d => d.SaveChanges()).Returns(regionsToReturn.First().Id);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new RegionRepository(repositoryMaster);

            //repository.Update(region);
        }
        [TestMethod]
        public void TestDelete()
        {
            Region region = regionsToReturn.First();
            int lengthRegions = regionsToReturn.Count();
            mockDbContext.Setup(d => d.Set<Region>()).Returns(mockSet.GetMockDbSet(regionsToReturn).Object);
            mockDbContext.Setup(d => d.SaveChanges()).Returns(region.Id);
            mockDbContext.Setup(d => d.Remove(region));
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new RegionRepository(repositoryMaster);

            repository.Delete(region);
        }
        [TestMethod]
        public void TestDeleteFailExist()
        {
            Region region = regionsToReturn.First();
            int lengthRegions = regionsToReturn.Count();
            mockDbContext.Setup(d => d.Set<Region>()).Returns(mockSet.GetMockDbSet(regionsToReturn).Object);
            mockDbContext.Setup(d => d.SaveChanges()).Returns(region.Id);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new RegionRepository(repositoryMaster);

            repository.Delete(region);
        }
        [TestMethod]
        public void TestDeleteById()
        {
            Region region = regionsToReturn.First();
            int lengthRegions = regionsToReturn.Count();
            var _mockSet = mockSet.GetMockDbSet(regionsToReturn);
            _mockSet.Setup(d => d.Find(It.IsAny<object[]>())).Returns(region);
            mockDbContext.Setup(d => d.Set<Region>()).Returns(_mockSet.Object);
            mockDbContext.Setup(d => d.SaveChanges()).Returns(region.Id);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new RegionRepository(repositoryMaster);

            repository.Delete(region.Id);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestDeleteByIdFailExist()
        {
            Region region = regionsToReturn.First();
            Region regionNull = null;
            int lengthRegions = regionsToReturn.Count();
            var _mockSet = mockSet.GetMockDbSet(regionsToReturn);
            _mockSet.Setup(d => d.Find(It.IsAny<object[]>())).Returns(regionNull);
            mockDbContext.Setup(d => d.Set<Region>()).Returns(_mockSet.Object);
            mockDbContext.Setup(d => d.SaveChanges()).Returns(region.Id);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new RegionRepository(repositoryMaster);

            repository.Delete(region.Id);
        }
    }
}