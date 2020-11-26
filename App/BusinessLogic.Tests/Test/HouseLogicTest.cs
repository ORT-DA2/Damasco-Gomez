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
    public class HouseLogicTest
    {
        private  List<House> housesToReturn;
        private  List<House>  emptyHouses;
        private HouseLogic houseLogic;
        private Mock<IHouseRepository> mockHouseRepository;
        private Mock<ITouristPointRepository> mockTouristPointRepository;
        private Mock<IImageHouseRepository> mockImageHouseRepository;
        [TestInitialize]
        public void InitVariables()
        {
            housesToReturn = new List<House>()
            {
                new House()
                {
                    Id = 1,
                    Name = "House 1",
                    
                },
                new House()
                {
                    Id = 2,
                    Name = "House 2",
                }
            };
            emptyHouses = new List<House>();
            mockHouseRepository = new Mock<IHouseRepository>(MockBehavior.Strict);
            mockTouristPointRepository = new Mock<ITouristPointRepository>(MockBehavior.Strict);
            mockImageHouseRepository = new Mock<IImageHouseRepository>(MockBehavior.Strict);
            houseLogic = new HouseLogic(mockHouseRepository.Object,mockTouristPointRepository.Object,mockImageHouseRepository.Object);
        }

        [TestMethod]
        public void TestDeleteById()
        {
            int lengthTouristPoint = housesToReturn.Count;
            mockHouseRepository.Setup(m => m.Delete(housesToReturn.First().Id));

            houseLogic.Delete(housesToReturn.First().Id);

            mockHouseRepository.VerifyAll();
        }

        [TestMethod]
        public void TestDelete()
        {
            int lengthRegions = housesToReturn.Count;
            mockHouseRepository.Setup(m => m.GetElements()).Returns(housesToReturn);
            foreach (House t in housesToReturn)
            {
                mockHouseRepository.Setup(m => m.Delete(t.Id));
            }

            houseLogic.Delete();

            mockHouseRepository.VerifyAll();
        }
        [TestMethod]
        public void TestDeleteEmpty()
        {
            mockHouseRepository.Setup(m => m.GetElements()).Returns(emptyHouses);

            houseLogic.Delete();

            mockHouseRepository.VerifyAll();
        }
        [TestMethod]
        public void GetAll()
        {
            mockHouseRepository.Setup(m => m.GetElements()).Returns(housesToReturn);

            var result = houseLogic.GetAll();

            Assert.IsTrue(result.SequenceEqual(housesToReturn));
        }
        [TestMethod]
        public void GetByTestOk()
        {
            House house = housesToReturn.First();
            mockHouseRepository.Setup(m => m.Find(house.Id)).Returns(house);

            House result = houseLogic.GetBy(house.Id);

            Assert.AreEqual(result,house);
        }
        [TestMethod]
        public void TestGetByFail()
        {
            House house = housesToReturn.First();
            House empty = null;
            mockHouseRepository.Setup(m => m.Find(house.Id)).Returns(empty);

            var result = houseLogic.GetBy(house.Id);

            Assert.IsNull(result);
        }
        [TestMethod]
        public void TestAddOk()
        {
            House house = housesToReturn.First();
            mockTouristPointRepository.Setup(m => m.ExistElement(house.TouristPointId)).Returns(true);
            mockHouseRepository.Setup(m => m.Find(house.Id)).Returns(house);
            mockHouseRepository.Setup(m => m.Add(house)).Returns(house);

            House result = houseLogic.Add(house);

            Assert.AreEqual(house, result);
        }
        [TestMethod]
        public void TestAddValidateError()
        {
            House house = housesToReturn.First();
            mockTouristPointRepository.Setup(m => m.ExistElement(house.TouristPointId)).Returns(true);
            mockHouseRepository.Setup(m => m.Find(house.Id)).Returns(house);
            mockHouseRepository.Setup(m => m.Add(house)).Returns(house);

            var result = houseLogic.Add(house);

            Assert.AreEqual(house, result);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddExistError()
        {
            House house = housesToReturn.First();
            mockTouristPointRepository.Setup(m => m.ExistElement(house.TouristPointId)).Returns(true);
            ArgumentException exception = new ArgumentException();
            mockHouseRepository.Setup(m => m.Find(house.Id)).Returns(house);
            mockHouseRepository.Setup(m => m.Add(house)).Throws(exception);

            var reuslt = houseLogic.Add(house);

            mockHouseRepository.VerifyAll();
        }
        [TestMethod]
        public void TestUpdateOk ()
        {
            House house = housesToReturn.First();
            mockTouristPointRepository.Setup(m => m.ExistElement(house.TouristPointId)).Returns(true);
            mockHouseRepository.Setup(m => m.Find(house.Id)).Returns(house);
            mockHouseRepository.Setup(m => m.Update(house.Id,house));

            House result = houseLogic.Update(house.Id,house);

            Assert.AreEqual(result,house);
        }
        [TestMethod]
        public void TestUpdateValidateError()
        {
            House house = housesToReturn.First();
            mockTouristPointRepository.Setup(m => m.ExistElement(house.TouristPointId)).Returns(true);
            mockHouseRepository.Setup(m => m.Find(house.Id)).Returns(house);
            mockHouseRepository.Setup(m => m.Update(house.Id,house));

            houseLogic.Update(house.Id,house);

            mockHouseRepository.VerifyAll();
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestUpdateValidateTouristPointId()
        {
            House house = housesToReturn.First();
            house.TouristPointId = 1;
            mockTouristPointRepository.Setup(m => m.ExistElement(house.TouristPointId)).Returns(false);

            houseLogic.Update(house.Id, house);

            mockHouseRepository.VerifyAll();
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestUpdateExistError()
        {
            House house = housesToReturn.First();
            mockTouristPointRepository.Setup(m => m.ExistElement(house.TouristPointId)).Returns(true);
            ArgumentException exception = new ArgumentException();
            mockHouseRepository.Setup(m => m.Find(house.Id)).Returns(house);
            mockHouseRepository.Setup(m => m.Update(house.Id,house)).Throws(exception);

            houseLogic.Update(house.Id,house);

            mockHouseRepository.VerifyAll();
        }
        [TestMethod]
        public void TestExistOk()
        {
            House house = housesToReturn.First();
            mockHouseRepository.Setup(m => m.ExistElement(house)).Returns(true);

            var result = houseLogic.Exist(house);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestNotExistOk()
        {
            House house = housesToReturn.First();
            mockHouseRepository.Setup(m => m.ExistElement(house)).Returns(false);

            var result = houseLogic.Exist(house);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestGetHousesByOk()
        {
            List<House> houses = new List<House>()
            {
                housesToReturn.First()
            };
            HouseSearch houseSearch = new HouseSearch(){
                TouristPointId = 100,
                CheckIn= new DateTime(2020,12,02),
                CheckOut= new DateTime(2020,12,02),
                CantAdults = 2,
                CantChildrens = 1,
                CantBabys = 0,
            };
            mockHouseRepository.Setup(m => m.GetByIdTouristPoint(houseSearch.TouristPointId)).Returns(houses);

            IEnumerable<House> result = houseLogic.GetHousesBy(houseSearch);

            Assert.AreEqual(houses, result);
        }
        [TestMethod]
        public void TestGetHousesByEmpty()
        {
            List<House> emptyHouses = new List<House>();
            HouseSearch houseSearch = new HouseSearch(){
                TouristPointId = 100,
                CheckIn= new DateTime(2020,12,02),
                CheckOut= new DateTime(2020,12,02),
                CantAdults = 2,
                CantChildrens = 1,
                CantBabys = 0,
            };
            mockHouseRepository.Setup(m => m.GetByIdTouristPoint(houseSearch.TouristPointId)).Returns(emptyHouses);

            IEnumerable<House> result = houseLogic.GetHousesBy(houseSearch);

            Assert.AreEqual(emptyHouses, result);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestValidateNotExistHouse()
        {
            House house = housesToReturn.First();
            mockTouristPointRepository.Setup(m => m.ExistElement(house.TouristPointId)).Returns(false);

            House result = houseLogic.Add(house);

            Assert.AreEqual(house, result);
        }
    }
}