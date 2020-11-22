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
        private Mock<IHouseRepository> mock;
        private Mock<ITouristPointRepository> mock2;
        private Mock<IImageHouseRepository> mock3;
        [TestInitialize]
        public void initVariables()
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
            mock = new Mock<IHouseRepository>(MockBehavior.Strict);
            mock2 = new Mock<ITouristPointRepository>(MockBehavior.Strict);
            mock3 = new Mock<IImageHouseRepository>(MockBehavior.Strict);
            houseLogic = new HouseLogic(mock.Object,mock2.Object,mock3.Object);
        }

        [TestMethod]
        public void TestDeleteById()
        {
            int lengthTouristPoint = housesToReturn.Count;
            mock.Setup(m => m.Delete(housesToReturn.First().Id));

            houseLogic.Delete(housesToReturn.First().Id);

            mock.VerifyAll();
        }

        [TestMethod]
        public void TestDelete()
        {
            int lengthRegions = housesToReturn.Count;
            mock.Setup(m => m.GetElements()).Returns(housesToReturn);
            foreach (House t in housesToReturn)
            {
                mock.Setup(m => m.Delete(t.Id));
            }

            houseLogic.Delete();

            mock.VerifyAll();
        }
        [TestMethod]
        public void TestDeleteEmpty()
        {
            mock.Setup(m => m.GetElements()).Returns(emptyHouses);

            houseLogic.Delete();

            mock.VerifyAll();
        }
        [TestMethod]
        public void GetAll()
        {
            mock.Setup(m => m.GetElements()).Returns(housesToReturn);

            var result = houseLogic.GetAll();

            Assert.IsTrue(result.SequenceEqual(housesToReturn));
        }
        [TestMethod]
        public void GetByTestOk()
        {
            House house = housesToReturn.First();
            mock.Setup(m => m.Find(house.Id)).Returns(house);

            House result = houseLogic.GetBy(house.Id);

            Assert.AreEqual(result,house);
        }
        [TestMethod]
        public void TestGetByFail()
        {
            House house = housesToReturn.First();
            House empty = null;
            mock.Setup(m => m.Find(house.Id)).Returns(empty);

            var result = houseLogic.GetBy(house.Id);

            Assert.IsNull(result);
        }
        [TestMethod]
        public void TestAddOk()
        {
            House house = housesToReturn.First();
            mock2.Setup(m => m.ExistElement(house.TouristPointId)).Returns(true);
            mock.Setup(m => m.Find(house.Id)).Returns(house);
            mock.Setup(m => m.Add(house)).Returns(house);

            House result = houseLogic.Add(house);

            Assert.AreEqual(house, result);
        }
        [TestMethod]
        public void TestAddValidateError()
        {
            House house = housesToReturn.First();
            mock2.Setup(m => m.ExistElement(house.TouristPointId)).Returns(true);
            mock.Setup(m => m.Find(house.Id)).Returns(house);
            mock.Setup(m => m.Add(house)).Returns(house);

            var result = houseLogic.Add(house);

            Assert.AreEqual(house, result);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddExistError()
        {
            House house = housesToReturn.First();
            mock2.Setup(m => m.ExistElement(house.TouristPointId)).Returns(true);
            ArgumentException exception = new ArgumentException();
            mock.Setup(m => m.Find(house.Id)).Returns(house);
            mock.Setup(m => m.Add(house)).Throws(exception);

            var reuslt = houseLogic.Add(house);

            mock.VerifyAll();
        }
        [TestMethod]
        public void TestUpdateOk ()
        {
            House house = housesToReturn.First();
            mock2.Setup(m => m.ExistElement(house.TouristPointId)).Returns(true);
            mock.Setup(m => m.Find(house.Id)).Returns(house);
            mock.Setup(m => m.Update(house.Id,house));

            House result = houseLogic.Update(house.Id,house);

            Assert.AreEqual(result,house);
        }
        [TestMethod]
        public void TestUpdateValidateError()
        {
            House house = housesToReturn.First();
            mock2.Setup(m => m.ExistElement(house.TouristPointId)).Returns(true);
            mock.Setup(m => m.Find(house.Id)).Returns(house);
            mock.Setup(m => m.Update(house.Id,house));

            houseLogic.Update(house.Id,house);

            mock.VerifyAll();
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestUpdateValidateTouristPointId()
        {
            House house = housesToReturn.First();
            house.TouristPointId = 1;
            mock2.Setup(m => m.ExistElement(house.TouristPointId)).Returns(false);

            houseLogic.Update(house.Id, house);

            mock.VerifyAll();
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestUpdateExistError()
        {
            House house = housesToReturn.First();
            mock2.Setup(m => m.ExistElement(house.TouristPointId)).Returns(true);
            ArgumentException exception = new ArgumentException();
            mock.Setup(m => m.Find(house.Id)).Returns(house);
            mock.Setup(m => m.Update(house.Id,house)).Throws(exception);

            houseLogic.Update(house.Id,house);

            mock.VerifyAll();
        }
        [TestMethod]
        public void TestExistOk()
        {
            House house = housesToReturn.First();
            mock.Setup(m => m.ExistElement(house)).Returns(true);

            var result = houseLogic.Exist(house);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestNotExistOk()
        {
            House house = housesToReturn.First();
            mock.Setup(m => m.ExistElement(house)).Returns(false);

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
            mock.Setup(m => m.GetByIdTouristPoint(houseSearch.TouristPointId)).Returns(houses);

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
            mock.Setup(m => m.GetByIdTouristPoint(houseSearch.TouristPointId)).Returns(emptyHouses);

            IEnumerable<House> result = houseLogic.GetHousesBy(houseSearch);

            Assert.AreEqual(emptyHouses, result);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestValidateNotExistHouse()
        {
            House house = housesToReturn.First();
            mock2.Setup(m => m.ExistElement(house.TouristPointId)).Returns(false);

            House result = houseLogic.Add(house);

            Assert.AreEqual(house, result);
        }
    }
}