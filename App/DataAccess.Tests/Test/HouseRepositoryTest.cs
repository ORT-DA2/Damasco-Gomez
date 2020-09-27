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
    public class HouseRepositoryTest
    {
        private List<House> housesToReturn;
        private List<House> housesToReturnEmpty;
        private RepositoryMaster repositoryMaster;
        private VidlyContext context;
        private VidlyDbSet<House> mockSet;
        private Mock<DbContext> mockDbContext;
        private HouseRepository repository;
        private List<House> emptyHouse;
        [TestInitialize]
        public void initVariables()
        {
            housesToReturn = new List<House>()
            {
                new House()
                {
                    Id = 1,
                    Name = "New house",
                },
                new House()
                {
                    Id = 2,
                    Name = "Other house",
                },
                new House()
                {
                    Id = 3,
                    Name = "And other house",
                },
                new House()
                {
                    Id = 4,
                    Name = "And one more house",
                }
            };
            emptyHouse = new List<House>();
            mockSet = new VidlyDbSet<House>();
            mockDbContext = new Mock<DbContext>(MockBehavior.Strict);
        }
        [TestMethod]
        public void TestGetAllHousesOk()
        {
            mockDbContext.Setup(d => d.Set<House>()).Returns(mockSet.GetMockDbSet(housesToReturn).Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new HouseRepository(repositoryMaster);
            var result = repository.GetElements();
            Assert.IsTrue(housesToReturn.SequenceEqual(result));
        }
        [TestMethod]
        public void TestGetAllHousesNull()
        {
            List<House> emptyHouse = new List<House>();
            mockDbContext.Setup(d => d.Set<House>()).Returns(mockSet.GetMockDbSet(emptyHouse).Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new HouseRepository(repositoryMaster);
            var result = repository.GetElements();
            Assert.IsTrue(emptyHouse.SequenceEqual(result));
        }
        [TestMethod]
        public void TestExistNot()
        {
            House house = housesToReturn.First();
            mockDbContext.Setup(d => d.Set<House>()).Returns(mockSet.GetMockDbSet(emptyHouse).Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new HouseRepository(repositoryMaster);
            bool result = repository.ExistElement(house);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestExist()
        {
            House house = housesToReturn.First();
            mockDbContext.Setup(d => d.Set<House>()).Returns(mockSet.GetMockDbSet(housesToReturn).Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new HouseRepository(repositoryMaster);
            bool result = repository.ExistElement(house);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestExistWithIdFail()
        {
            int houseId = housesToReturn.First().Id;
            mockDbContext.Setup(d => d.Set<House>()).Returns(mockSet.GetMockDbSet(housesToReturn).Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new HouseRepository(repositoryMaster);
            bool result = repository.ExistElement(houseId);
            Assert.IsFalse(result);
        }
        // [TestMethod]
        // public void TestExistHouseById()
        // {
        //     House house = housesToReturn.First();
        //     mockDbContext.Setup(d => d.Set<House>()).Returns(mockSet.GetMockDbSet(housesToReturn).Object);
        //     repositoryMaster = new RepositoryMaster(mockDbContext.Object);
        //     repository = new HouseRepository(repositoryMaster);
        //     bool result = repository.ExistElement(house.Id);
        //     Assert.IsTrue(result);
        // }
        [TestMethod]
        public void TestExistHouse()
        {
            House house = housesToReturn.First();
            mockDbContext.Setup(d => d.Set<House>()).Returns(mockSet.GetMockDbSet(housesToReturn).Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new HouseRepository(repositoryMaster);
            bool result = repository.ExistElement(house);
            Assert.IsTrue(result);
        }
        // [TestMethod]
        // public void TestFind()
        // {
        //     House house = housesToReturn.First();
        //     mockDbContext.Setup(d => d.Set<House>()).Returns(mockSet.GetMockDbSet(housesToReturn).Object);
        //     repositoryMaster = new RepositoryMaster(mockDbContext.Object);
        //     repository = new HouseRepository(repositoryMaster);
        //     House result = repository.Find(house.Id);
        //     Assert.AreEqual(result,house);
        // }

        [TestMethod]
        public void TestFindFail()
        {
            House house = housesToReturn.First();
            mockDbContext.Setup(d => d.Set<House>()).Returns(mockSet.GetMockDbSet(housesToReturn).Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new HouseRepository(repositoryMaster);
            House result = repository.Find(house.Id + 1000);
            // Exception exception = new ArgumentException();
            // Assert.IsInstanceOfType(result, typeof(Exception));
            Assert.IsNull(result);
        }
        [TestMethod]
        public void TestUpdate()
        {
            House house = housesToReturn.First();
            house.Name = "New name of house";
            string newName = house.Name;
            mockDbContext.Setup(d => d.Set<House>()).Returns(mockSet.GetMockDbSet(housesToReturn).Object);
            mockDbContext.Setup(d => d.SaveChanges()).Returns(housesToReturn.First().Id);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new HouseRepository(repositoryMaster);
            repository.Update(house);
            Assert.AreEqual(house.Name,newName);
        }
        [TestMethod]
        public void TestUpdateFail()
        {
            House house = new House(){Id = 13000};
            string newName = house.Name;
            mockDbContext.Setup(d => d.Set<House>()).Returns(mockSet.GetMockDbSet(housesToReturn).Object);
            mockDbContext.Setup(d => d.SaveChanges()).Returns(housesToReturn.First().Id);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new HouseRepository(repositoryMaster);
            repository.Update(house);
            // Exception exception = new ArgumentException();
            // Assert.IsInstanceOfType(result, typeof(Exception));
        }
    }
}