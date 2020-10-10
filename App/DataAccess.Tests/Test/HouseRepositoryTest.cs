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
        private DbContext context;
        private DbContextOptions options;
        private HouseRepository repository;
        [TestInitialize]
        public void Setup()
        {
            this.options = new DbContextOptionsBuilder<VidlyContext>().UseInMemoryDatabase(databaseName: "VidlyDBtest").Options;
            this.context = new VidlyContext(this.options);
            housesToReturn = new List<House>()
            {
                new House()
                {
                    Id = 1,
                    Name = "House 1",
                    TouristPointId= 1,
                    Avaible = true,
                },
                new House()
                {
                    Id = 2,
                    Name = "House 2",
                    TouristPointId= 2,
                }
            };
            housesToReturn.ForEach(m => this.context.Add(m));
            this.context.SaveChanges();
            repositoryMaster = new RepositoryMaster(context);
            repository = new HouseRepository(repositoryMaster);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.context.Database.EnsureDeleted();
        }
        [TestMethod]
        public void TestAdd()
        {
            House house = new House()
            {
                Id = 123,
                Name="name new",
                PricePerNight=11,
                Starts=2
            };
            HouseRepository repo = new HouseRepository(this.repositoryMaster);
            int cantRepo = this.repository.GetElements().Count();

            repo.Add(house);

            Assert.AreEqual(repo.GetElements().Count(),cantRepo+1);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddFailValidateStars0()
        {
            House house = new House()
            {
                Id = 123,
                Name="name new",
                PricePerNight=11,
                Starts=0
            };

            repository.Add(house);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddFailValidateStars6()
        {
            House house = new House()
            {
                Id = 123,
                Name="name new",
                PricePerNight=11,
                Starts=8
            };

            repository.Add(house);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddFailValidate3()
        {
            House house = new House(){Id = 123, Name="name new",PricePerNight=0,Starts=2};

            repository.Add(house);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddFailExist()
        {
            House house = housesToReturn.First();
            ArgumentException exception = new ArgumentException();

            repository.Add(house);
        }
        [TestMethod]
        public void TestGetAllHousesOk()
        {
            var result = repository.GetElements();

            Assert.IsTrue(housesToReturn.SequenceEqual(result));
        }
        [TestMethod]
        public void TestExistElement()
        {
            House house = housesToReturn.First();

            bool result = repository.ExistElement(house);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestExistElementFail()
        {
            House house = new House(){Id = 223 , Name="name"};

            bool result = repository.ExistElement(house);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestExistWithIdFail()
        {
            int houseId = 234234234;

            bool result = repository.ExistElement(houseId);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestExistById()
        {
            House house = housesToReturn.First();

            bool result = repository.ExistElement(house.Id);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestExistByIdFail()
        {
            House house = new House(){Id=123423};

            bool result = repository.ExistElement(house.Id);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestFind()
        {
            House house = housesToReturn.First();

            House result = repository.Find(house.Id);

            Assert.AreEqual(result,house);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestFindFail()
        {
            House house = new House(){Id=232323};

            House result = repository.Find(house.Id);
        }
        [TestMethod]
        public void TestUpdate()
        {
            House house = housesToReturn.First();
            house.Name = "New name of house";
            string newName = house.Name;

            repository.Update(house.Id,house);

            Assert.AreEqual(house.Name,newName);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestUpdateFail()
        {
            House house = new House(){Id = 13000};
            string newName = house.Name;

            repository.Update(house.Id,house);
        }
        [TestMethod]
        public void TestDelete()
        {
            House house = housesToReturn.First();
            int repoCount = this.repository.GetElements().Count();

            repository.Delete(house);

            Assert.AreEqual(repoCount - 1 , repository.GetElements().Count());
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestDeleteFailExist()
        {
            House house = new House(){Id = 2342342};

            repository.Delete(house);
        }
        [TestMethod]
        public void TestDeleteById()
        {
            House house = housesToReturn.First();
            int repoCount = this.repository.GetElements().Count();

            repository.Delete(house.Id);

            Assert.AreEqual(repoCount - 1 , repository.GetElements().Count());
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestDeleteByIdFailExist()
        {
            int id = 23123123;

            repository.Delete(id);
        }
        [TestMethod]
        public void TestGetByIdTouristPointOk ()
        {
            int idTP = 1;
            List <House> houses = new List<House>()
            {
                housesToReturn.First()
            };

            var result = repository.GetByIdTouristPoint(idTP);

            Assert.IsTrue(houses.SequenceEqual(result));
        }
        [TestMethod]
        public void TestGetByIdTouristPointEmpty ()
        {
            int idTP = 3;
            List <House> emptyHouses = new List<House>();

            var result = repository.GetByIdTouristPoint(idTP);
           
            Assert.IsTrue(emptyHouses.SequenceEqual(result));
        }
    }
}