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
    public class HouseRepositoryTest
    {
        private List<House> housesToReturn;
        private RepositoryMaster repositoryMaster;
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
                    Starts = 5,
                    PricePerNight = 40,
                    Spot = new TouristPoint(){Id = 6, Name = "tourist point name"},
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
        public void TestAdd()
        {
            House house = new House(){Id = 123, Name="name new", Starts = 3, PricePerNight = 23};
            mockDbContext.Setup(d => d.Set<House>()).Returns(mockSet.GetMockDbSet(housesToReturn).Object);
            int houses = housesToReturn.Count();
            mockDbContext.Setup(d => d.SaveChanges()).Returns(house.Id);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new HouseRepository(repositoryMaster);

            repository.Add(house);

            Assert.AreEqual(houses+1, housesToReturn.Count());
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddFailValidate()
        {
            House house = new House(){Id = 123, Name="name new"};
            int houseLenght = housesToReturn.Count() ;
            mockDbContext.Setup(d => d.Set<House>()).Returns(mockSet.GetMockDbSet(housesToReturn).Object);
            mockDbContext.Setup(d => d.SaveChanges()).Returns(house.Id);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new HouseRepository(repositoryMaster);

            repository.Add(house);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddFailValidatePrice()
        {
            House house = new House(){Id = 123, Name="name new"};
            int houseLenght = housesToReturn.Count() ;
            mockDbContext.Setup(d => d.Set<House>()).Returns(mockSet.GetMockDbSet(housesToReturn).Object);
            mockDbContext.Setup(d => d.SaveChanges()).Returns(house.Id);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new HouseRepository(repositoryMaster);

            repository.Add(house);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddFailValidateStarts()
        {
            House house = new House(){Id = 123, Name="name new"};
            int houseLenght = housesToReturn.Count() ;
            mockDbContext.Setup(d => d.Set<House>()).Returns(mockSet.GetMockDbSet(housesToReturn).Object);
            mockDbContext.Setup(d => d.SaveChanges()).Returns(house.Id);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new HouseRepository(repositoryMaster);

            repository.Add(house);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddFailExist()
        {
            House house = housesToReturn.First();
            ArgumentException exception = new ArgumentException();
            var _mockSet = mockSet.GetMockDbSet(housesToReturn);
            _mockSet.Setup(d => d.Find(It.IsAny<House>())).Throws(exception);
            mockDbContext.Setup(d => d.Set<House>()).Returns(_mockSet.Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new HouseRepository(repositoryMaster);

            repository.Add(house);
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
        public void TestExistElement()
        {
            House house = housesToReturn.First();
            mockDbContext.Setup(d => d.Set<House>()).Returns(mockSet.GetMockDbSet(housesToReturn).Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new HouseRepository(repositoryMaster);

            bool result = repository.ExistElement(house);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestExistElementFail()
        {
            House house = housesToReturn.First();
            mockDbContext.Setup(d => d.Set<House>()).Returns(mockSet.GetMockDbSet(emptyHouse).Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new HouseRepository(repositoryMaster);

            bool result = repository.ExistElement(house);

            Assert.IsFalse(result);
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
        [TestMethod]
        public void TestExistById()
        {
            House house = housesToReturn.First();
            var _mockSet = mockSet.GetMockDbSet(housesToReturn);
            _mockSet.Setup(d => d.Find(It.IsAny<object[]>())).Returns(house);
            mockDbContext.Setup(d => d.Set<House>()).Returns(_mockSet.Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new HouseRepository(repositoryMaster);

            bool result = repository.ExistElement(house.Id);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestExistByIdFail()
        {
            House house = new House(){Id=123423};
            mockDbContext.Setup(d => d.Set<House>()).Returns(mockSet.GetMockDbSet(housesToReturn).Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new HouseRepository(repositoryMaster);

            bool result = repository.ExistElement(house.Id);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestFind()
        {
            House house = housesToReturn.First();
            var _mockSet = mockSet.GetMockDbSet(housesToReturn);
            _mockSet.Setup(d => d.Find(It.IsAny<object[]>())).Returns(house);
            mockDbContext.Setup(d => d.Set<House>()).Returns(_mockSet.Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new HouseRepository(repositoryMaster);

            House result = repository.Find(house.Id);

            Assert.AreEqual(result,house);
        }

        [TestMethod]
        public void TestFindFail()
        {
            House house = new House(){Id=232323};
            House houseNull = null;
            var _mockSet = mockSet.GetMockDbSet(housesToReturn);
            ArgumentException exception = new ArgumentException();
            _mockSet.Setup(d => d.Find(It.IsAny<object[]>())).Returns(houseNull);
            mockDbContext.Setup(d => d.Set<House>()).Returns(_mockSet.Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new HouseRepository(repositoryMaster);

            House result = repository.Find(house.Id);

            Assert.IsNull(result);
        }
        [TestMethod]
        public void TestUpdate()
        {
            House house = housesToReturn.First();
            house.Name = "New name of house";
            string newName = house.Name;
            mockDbContext.Setup(d => d.Set<House>()).Returns(mockSet.GetMockDbSet(housesToReturn).Object);
            mockDbContext.Setup(d => d.SaveChanges()).Returns(house.Id);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new HouseRepository(repositoryMaster);

            repository.Update(house);

            Assert.AreEqual(house.Name,newName);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestUpdateFail()
        {
            House house = new House(){Id = 13000};
            mockDbContext.Setup(d => d.Set<House>()).Returns(mockSet.GetMockDbSet(housesToReturn).Object);
            mockDbContext.Setup(d => d.SaveChanges()).Returns(housesToReturn.First().Id);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new HouseRepository(repositoryMaster);

            repository.Update(house);
        }
        [TestMethod]
        public void TestDelete()
        {
            House house = housesToReturn.First();
            int lengthHouses = housesToReturn.Count();
            mockDbContext.Setup(d => d.Set<House>()).Returns(mockSet.GetMockDbSet(housesToReturn).Object);
            mockDbContext.Setup(d => d.SaveChanges()).Returns(house.Id);
            mockDbContext.Setup(d => d.Remove(house));
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new HouseRepository(repositoryMaster);

            repository.Delete(house);
        }
        [TestMethod]
        public void TestDeleteFailExist()
        {
            House house = housesToReturn.First();
            int lengthHouses = housesToReturn.Count();
            mockDbContext.Setup(d => d.Set<House>()).Returns(mockSet.GetMockDbSet(housesToReturn).Object);
            mockDbContext.Setup(d => d.SaveChanges()).Returns(house.Id);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new HouseRepository(repositoryMaster);

            repository.Delete(house);
        }
        [TestMethod]
        public void TestDeleteById()
        {
            House house = housesToReturn.First();
            var _mockSet = mockSet.GetMockDbSet(housesToReturn);
            _mockSet.Setup(d => d.Find(It.IsAny<object[]>())).Returns(house);
            mockDbContext.Setup(d => d.Set<House>()).Returns(_mockSet.Object);
            mockDbContext.Setup(d => d.SaveChanges()).Returns(house.Id);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new HouseRepository(repositoryMaster);

            repository.Delete(house.Id);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestDeleteByIdFailExist()
        {
            House house = housesToReturn.First();
            House houseNull = null;
            int lengthHouses = housesToReturn.Count();
            var _mockSet = mockSet.GetMockDbSet(housesToReturn);
            _mockSet.Setup(d => d.Find(It.IsAny<object[]>())).Returns(houseNull);
            mockDbContext.Setup(d => d.Set<House>()).Returns(_mockSet.Object);
            mockDbContext.Setup(d => d.SaveChanges()).Returns(house.Id);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new HouseRepository(repositoryMaster);

            repository.Delete(house.Id);
        }
    }
}