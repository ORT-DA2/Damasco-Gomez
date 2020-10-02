using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessInterface.Repositories;
using Domain;
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
            houseLogic = new HouseLogic(mock.Object);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Assert.IsTrue(true);
        }
         [TestMethod]
        public void DeleteTestByIdOk()
        {
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void GetByTestOk()
        {
             House house = housesToReturn.First();
            mock.Setup(m => m.Find(house.Id)).Returns(house);

            var result = houseLogic.GetBy(house.Id);

            mock.VerifyAll();
            Assert.AreEqual(result,house);
        }
         [TestMethod]
         public void TestGetByFail()
        {
            House house = housesToReturn.First();
            House empty = null;
            mock.Setup(m => m.Find(house.Id)).Returns(empty);

            var result = houseLogic.GetBy(house.Id);

            mock.VerifyAll();
            Assert.IsNull(result);
        }
        public void TestAddOk()
        {
            House house = housesToReturn.First();
            mock.Setup(m => m.Add(house)).Returns(house);
            var result= houseLogic.Add(house);
        
            Assert.AreEqual(house, result );
        }
         [TestMethod]
        public void TestAddValidateError()
        {
            House house = housesToReturn.First(); // House tiene que terner un formato erroneo despues para que la validación falle
            mock.Setup(m => m.Add(house)).Returns(house);

            var result = houseLogic.Add(house);

            Assert.AreEqual(house, result); 
        }
        [TestMethod]
         [ExpectedException(typeof(ArgumentException))]
        public void TestAddExistError()
        {
            House house = housesToReturn.First(); 
            ArgumentException exception = new ArgumentException();
            mock.Setup(m => m.Add(house)).Throws(exception);

            var reuslt = houseLogic.Add(house);
        }
         [TestMethod]
        public void TestUdpateOk ()
        {
            House house = housesToReturn.First();
            mock.Setup(m => m.Update(house.Id,house));

            houseLogic.Update(house.Id,house);

            mock.VerifyAll();
        }
         [TestMethod]
        public void TestUpdateValidateError()
        {
            House house = housesToReturn.First();// House tiene que terner un formato erroneo despues para que la validación falle
             mock.Setup(m => m.Update(house.Id,house));

            houseLogic.Update(house.Id,house);

            mock.VerifyAll();
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestUpdateExistError()
        {
            House house = housesToReturn.First();
            ArgumentException exception = new ArgumentException();
            mock.Setup(m => m.Update(house.Id,house)).Throws(exception);
            
            houseLogic.Update(house.Id,house);
        }
          [TestMethod]
        public void TestExistOk()
        {
            House house = housesToReturn.First();
            mock.Setup(m => m.ExistElement(house)).Returns(true);

            var result = houseLogic.Exist(house);

            mock.VerifyAll();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestNotExistOk()
        {
            House house = housesToReturn.First();
            mock.Setup(m => m.ExistElement(house)).Returns(false);
            var result = houseLogic.Exist(house);
            mock.VerifyAll();
            Assert.IsFalse(result);
        }
        //falta delete
    }
}