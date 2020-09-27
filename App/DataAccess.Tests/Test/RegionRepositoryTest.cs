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
        private List<Region> regionsToReturnEmpty;
        private RepositoryMaster repositoryMaster;
        private VidlyContext context;
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
        public void TestExistNot()
        {
            Region region = regionsToReturn.First();
            mockDbContext.Setup(d => d.Set<Region>()).Returns(mockSet.GetMockDbSet(emptyRegion).Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new RegionRepository(repositoryMaster);
            bool result = repository.ExistElement(region);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestExist()
        {
            Region region = regionsToReturn.First();
            mockDbContext.Setup(d => d.Set<Region>()).Returns(mockSet.GetMockDbSet(regionsToReturn).Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new RegionRepository(repositoryMaster);
            bool result = repository.ExistElement(region);
            Assert.IsTrue(result);
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
        // [TestMethod]
        // public void TestExistRegionById()
        // {
        //     Region region = regionsToReturn.First();
        //     mockDbContext.Setup(d => d.Set<Region>()).Returns(mockSet.GetMockDbSet(regionsToReturn).Object);
        //     repositoryMaster = new RepositoryMaster(mockDbContext.Object);
        //     repository = new RegionRepository(repositoryMaster);
        //     bool result = repository.ExistElement(region.Id);
        //     Assert.IsTrue(result);
        // }
        [TestMethod]
        public void TestExistRegion()
        {
            Region region = regionsToReturn.First();
            mockDbContext.Setup(d => d.Set<Region>()).Returns(mockSet.GetMockDbSet(regionsToReturn).Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new RegionRepository(repositoryMaster);
            bool result = repository.ExistElement(region);
            Assert.IsTrue(result);
        }
        // [TestMethod]
        // public void TestFind()
        // {
        //     Region region = regionsToReturn.First();
        //     mockDbContext.Setup(d => d.Set<Region>()).Returns(mockSet.GetMockDbSet(regionsToReturn).Object);
        //     repositoryMaster = new RepositoryMaster(mockDbContext.Object);
        //     repository = new RegionRepository(repositoryMaster);
        //     Region result = repository.Find(region.Id);
        //     Assert.AreEqual(result,region);
        // }

        [TestMethod]
        public void TestFindFail()
        {
            Region region = regionsToReturn.First();
            mockDbContext.Setup(d => d.Set<Region>()).Returns(mockSet.GetMockDbSet(regionsToReturn).Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new RegionRepository(repositoryMaster);
            Region result = repository.Find(region.Id + 1000);
            // Exception exception = new ArgumentException();
            // Assert.IsInstanceOfType(result, typeof(Exception));
            Assert.IsNull(result);
        }
        [TestMethod]
        public void TestUpdate()
        {
            Region region = regionsToReturn.First();
            region.Name = "New name of region";
            string newName = region.Name;
            mockDbContext.Setup(d => d.Set<Region>()).Returns(mockSet.GetMockDbSet(regionsToReturn).Object);
            mockDbContext.Setup(d => d.SaveChanges()).Returns(regionsToReturn.First().Id);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new RegionRepository(repositoryMaster);
            repository.Update(region);
            Assert.AreEqual(region.Name,newName);
        }
        [TestMethod]
        public void TestUpdateFail()
        {
            Region region = new Region(){Id = 13000};
            string newName = region.Name;
            mockDbContext.Setup(d => d.Set<Region>()).Returns(mockSet.GetMockDbSet(regionsToReturn).Object);
            mockDbContext.Setup(d => d.SaveChanges()).Returns(regionsToReturn.First().Id);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new RegionRepository(repositoryMaster);
            repository.Update(region);
            // Exception exception = new ArgumentException();
            // Assert.IsInstanceOfType(result, typeof(Exception));
        }
    }
}