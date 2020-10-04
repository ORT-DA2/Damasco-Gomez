using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogicInterface;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApi.Controllers;

namespace WebApi.Tests
{
    [TestClass]
    public class HouseControllerTest
    {
        private List<House> housesToReturn;
        private List<House> housesToReturnEmpty;
        private House houseId1;
        private Mock<IHouseLogic> mock;
        private HouseController controller ;
        [TestInitialize]
        public void initVariables()
        {
            housesToReturn = new List<House>()
            {
                new House()
                {
                    Id = 1,
                    Avaible = true ,
                    PricePerNight = 100,
                    TouristPointId = 1,
                    Name = "Name house 1",
                    Starts = 1,
                    Address = "Address 1",
                    Ilustrations = "Image here",
                    Description = "Description house 1",
                    Phone = 99898899 ,
                    Contact = "Person Name1",
                },
                new House()
                {
                    Id = 2,
                    Avaible = false ,
                    PricePerNight = 200,
                    TouristPointId = 2,
                    Name = "Name house 2",
                    Starts = 2,
                    Address = "Address 2",
                    Ilustrations = "Image here",
                    Description = "Description house 2",
                    Phone = 99898899 ,
                    Contact = "Person Name2",
                },
                new House()
                {
                    Id = 3,
                    Avaible = true ,
                    PricePerNight = 300,
                    TouristPointId = 3,
                    Name = "Name house 3",
                    Starts = 4,
                    Address = "Address 3",
                    Ilustrations = "Image here",
                    Description = "Description house 3",
                    Phone = 99898899 ,
                    Contact = "Person Name3",
                },
                new House()
                {
                    Id = 4,
                    Avaible = true ,
                    PricePerNight = 400,
                    TouristPointId = 4,
                    Name = "Name house 4",
                    Starts = 4,
                    Address = "Address 4",
                    Ilustrations = "Image here",
                    Description = "Description house 4",
                    Phone = 99898899 ,
                    Contact = "Person Name4",
                }
            };
            housesToReturnEmpty = new List<House>();
            houseId1 = housesToReturn.First();
            mock = new Mock<IHouseLogic>(MockBehavior.Strict);
            controller = new HouseController(mock.Object);
        }
        [TestMethod]
        public void TestGetAllHousesOk()
        {
            mock.Setup(m => m.GetAll()).Returns(housesToReturn);

            var result = controller.Get();

            var okResult = result as OkObjectResult;
            var houses = okResult.Value as IEnumerable<House>;
            mock.VerifyAll();
            Assert.IsTrue(housesToReturn.SequenceEqual(houses));
        }

        [TestMethod]
        public void TestGetAllHousesVacia()
        {
            mock.Setup(m => m.GetAll()).Returns(housesToReturnEmpty);

            var result = controller.Get();

            var okResult = result as OkObjectResult;
            var houses = okResult.Value as IEnumerable<House>;
            mock.VerifyAll();
            Assert.IsTrue(housesToReturnEmpty.SequenceEqual(houses));
        }
        [TestMethod]
        public void TestGetByOk()
        {
            int id = 1;
            mock.Setup(m => m.GetBy(id)).Returns(houseId1);

            var result = controller.GetBy(id);

            var okResult = result as OkObjectResult;
            var houses = okResult.Value as House;
            mock.VerifyAll();
            Assert.IsTrue(houses.Equals(houseId1));
        }
        [TestMethod]
        public void TestGetByNotFound()
        {
            int id = 4;
            ArgumentException exist = new ArgumentException();
            mock.Setup(m => m.GetBy(id)).Throws(exist);

            var result = controller.GetBy(id);

            mock.VerifyAll();
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        [TestMethod]
        public void TestPostOk()
        {
            mock.Setup(m => m.Add(houseId1)).Returns(houseId1);

            var result = controller.Post(houseId1);

            var okResult = result as CreatedAtRouteResult;
            mock.VerifyAll();
            Assert.IsNotNull(okResult);
            Assert.AreEqual("GetHouse", okResult.RouteName);
            Assert.AreEqual(okResult.Value, houseId1);
        }
        [TestMethod]
        public void TestPostFailSameHouse()
        {
            houseId1 = housesToReturn.First();
            Exception exist = new AggregateException();
            mock.Setup(p => p.Add(houseId1)).Throws(exist);

            var result = controller.Post(houseId1);

            mock.VerifyAll();
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        [TestMethod]
        public void TestPostFailValidation()
        {
            houseId1 = housesToReturn.First();
            Exception exist = new ArgumentException();
            mock.Setup(p => p.Add(houseId1)).Throws(exist);

            var result = controller.Post(houseId1);

            mock.VerifyAll();
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        [TestMethod]
        public void TestPostFailServer()
        {
            houseId1 = housesToReturn.First();
            Exception exist = new Exception();
            mock.Setup(p => p.Add(houseId1)).Throws(exist);

            var result = controller.Post(houseId1);

            mock.VerifyAll();
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        [TestMethod]
        public void TestPutOk()
        {
            houseId1 = housesToReturn.First();
            mock.Setup(m => m.Update(houseId1.Id,houseId1));

            var result = controller.Put(houseId1.Id, houseId1);

            var okResult = result as CreatedAtRouteResult;
            mock.VerifyAll();
            Assert.IsNotNull(okResult);
            Assert.AreEqual("GetHouse", okResult.RouteName);
            Assert.AreEqual(okResult.Value, houseId1);
        }
        [TestMethod]
        public void TestPutFailValidate()
        {
            houseId1 = housesToReturn.First();
            Exception exist = new ArgumentException();
            mock.Setup(p => p.Update(houseId1.Id,houseId1)).Throws(exist);

            var result = controller.Put(houseId1.Id, houseId1);

            mock.VerifyAll();
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        [TestMethod]
        public void TestPutFailServer()
        {
            houseId1 = housesToReturn.First();
            Exception exist = new Exception();
            mock.Setup(p => p.Update(houseId1.Id,houseId1)).Throws(exist);

            var result = controller.Put(houseId1.Id, houseId1);

            mock.VerifyAll();
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        [TestMethod]
        public void TestDeleteWithId()
        {
            House house = housesToReturn.First();
            mock.Setup(m => m.GetBy(house.Id)).Returns(house);
            mock.Setup(mock=> mock.Delete(house.Id));

            var result = controller.Delete(house.Id);

            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestDeleteWithIdNotFound()
        {
            House house = housesToReturn.First();
            House houseNull = null;
            mock.Setup(m => m.GetBy(house.Id)).Returns(houseNull);
            mock.Setup(mock=> mock.Delete(house.Id));

            var result = controller.Delete(house.Id);

            Assert.IsInstanceOfType(result,typeof(NotFoundResult));
        }

        [TestMethod]
        public void TestDelete()
        {
            mock.Setup(mock=> mock.Delete());
            
            var result = controller.Delete();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestGetHousesBy()
        {
            int idTP = 1;
            string checkIn= "01/12/2020";
            string checkOut= "21/12/2020";
            int cantA = 2;
            int cantC = 1;
            int cantB = 0;
            List<House> housesWithIdTP = new List<House>()
            {
                housesToReturn.First(),
            };
            // mock.Setup(mock=> mock.GetHousesBy(idTP,checkIn,checkOut,cantA,cantC,cantB)).Returns(housesWithIdTP);
          
            // var result = controller.GetHousesBy(idTP,checkIn,checkOut,cantA,cantC,cantB);

            //Assert.AreEqual(result ,housesWithIdTP);
        }
    }
}