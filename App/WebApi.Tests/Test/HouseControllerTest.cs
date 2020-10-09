using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogicInterface;
using Domain;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Model.In;
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
        private HouseSearchModel houseSearchModelNull;
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
                    TouristPoint = new TouristPoint(){Id = 1, Name = "touriste point hose"},
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
                    TouristPoint = new TouristPoint(){Id = 2, Name = "touriste point hose"},
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
                    TouristPointId = 2,
                    TouristPoint = new TouristPoint(){Id = 2, Name = "touriste point hose"},
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
                    TouristPointId = 2,
                    TouristPoint = new TouristPoint(){Id = 2, Name = "touriste point hose"},
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
            houseSearchModelNull = new HouseSearchModel();
        }
        [TestMethod]
        public void TestGetAllHousesOk()
        {
            IEnumerable<HouseBasicModel> houseBasicModels = housesToReturn.Select(m => new HouseBasicModel(m));
            mock.Setup(m => m.GetAll()).Returns(housesToReturn);

            var result = controller.GetHousesBy(houseSearchModelNull);

            var okResult = result as OkObjectResult;
            var houses = okResult.Value as IEnumerable<HouseBasicModel>;
            mock.VerifyAll();
            Assert.IsTrue(houseBasicModels.SequenceEqual(houses));
        }

        [TestMethod]
        public void TestGetAllHousesVacia()
        {
            IEnumerable<HouseBasicModel> houseBasicModels = housesToReturnEmpty.Select(m => new HouseBasicModel(m));
            mock.Setup(m => m.GetAll()).Returns(housesToReturnEmpty);

            var result = controller.GetHousesBy(houseSearchModelNull);

            var okResult = result as OkObjectResult;
            var houses = okResult.Value as IEnumerable<HouseBasicModel>;
            mock.VerifyAll();
            Assert.IsTrue(houseBasicModels.SequenceEqual(houses));
        }
        [TestMethod]
        public void TestGetByOk()
        {
            int id = 1;
            HouseDetailModel houseDetailModel = new HouseDetailModel(houseId1);
            mock.Setup(m => m.GetBy(id)).Returns(houseId1);

            var result = controller.GetBy(id);

            var okResult = result as OkObjectResult;
            var houses = okResult.Value as HouseDetailModel;
            Assert.IsTrue(houses.Equals(houseDetailModel));
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
            HouseModel houseModel = new HouseModel()
            {
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
            };
            House house = houseModel.ToEntity();
            mock.Setup(m => m.Add(house)).Returns(house);

            var result = controller.Post(houseModel);

            var okResult = result as CreatedAtRouteResult;
            mock.VerifyAll();
            Assert.IsNotNull(okResult);
            Assert.AreEqual("GetHouse", okResult.RouteName);
            Assert.AreEqual(okResult.Value, house);
        }
        [TestMethod]
        public void TestPostFailSameHouse()
        {
            HouseModel houseModel = new HouseModel()
            {
            };
            House house = houseModel.ToEntity();
            Exception exist = new AggregateException();
            mock.Setup(p => p.Add(house)).Throws(exist);

            var result = controller.Post(houseModel);

            mock.VerifyAll();
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        [TestMethod]
        public void TestPostFailValidation()
        {
            HouseModel houseModel = new HouseModel();
            House house = houseModel.ToEntity();
            Exception exist = new ArgumentException();
            mock.Setup(p => p.Add(house)).Throws(exist);

            var result = controller.Post(houseModel);

            mock.VerifyAll();
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        [TestMethod]
        public void TestPostFailServer()
        {
            HouseModel houseModel = new HouseModel();
            House house = houseModel.ToEntity();
            Exception exist = new Exception();
            mock.Setup(p => p.Add(house)).Throws(exist);

            var result = controller.Post(houseModel);

            mock.VerifyAll();
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        [TestMethod]
        public void TestPutOk()
        {
            HouseModel houseModel = new HouseModel()
            {
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
            };
            houseId1 = houseModel.ToEntity();
            mock.Setup(m => m.Update(houseId1.Id,houseId1)).Returns(houseId1);

            var result = controller.Put(houseId1.Id, houseModel);

            var okResult = result as CreatedAtRouteResult;
            mock.VerifyAll();
            Assert.IsNotNull(okResult);
            Assert.AreEqual("GetHouse", okResult.RouteName);
            Assert.AreEqual(okResult.Value, houseId1);
        }
        [TestMethod]
        public void TestPutFailValidate()
        {
            HouseModel houseModel = new HouseModel()
            {
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
            };
            houseId1 = houseModel.ToEntity();
            Exception exist = new ArgumentException();
            mock.Setup(p => p.Update(houseId1.Id,houseId1)).Throws(exist);

            var result = controller.Put(houseId1.Id, houseModel);

            mock.VerifyAll();
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        [TestMethod]
        public void TestPutFailServer()
        {
            HouseModel houseModel = new HouseModel()
            {
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
            };
            houseId1 = houseModel.ToEntity();
            Exception exist = new Exception();
            mock.Setup(p => p.Update(houseId1.Id,houseId1)).Throws(exist);

            var result = controller.Put(houseId1.Id, houseModel);

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
            HouseSearchModel houseSearchModel = new HouseSearchModel(){
                TouristPointId = 1,
                CheckIn= "01/12/2020",
                CheckOut= "21/12/2020",
                CantAdults = 2,
                CantChildrens = 1,
                CantBabys = 0,
            };
            HouseSearch houseSearch = houseSearchModel.ToEntity();
            IEnumerable<House> housesWithIdTP = new List<House>()
            {
                housesToReturn.First()
            };
            mock.Setup(m => m.GetHousesBy(It.IsAny<HouseSearch>())).Returns(housesWithIdTP);

            var result = controller.GetHousesBy(houseSearchModel);

            var okResult = result as OkObjectResult;
            var houses = okResult.Value as IEnumerable<HouseSearchResultModel>;
            //Assert.IsTrue(housesResult.SequenceEqual(houses));
        }
        [TestMethod]
        public void TestGetHousesByEmpty()
        {

            HouseSearchModel houseSearchModel = new HouseSearchModel(){
                TouristPointId = 5,
                CheckIn= "01/12/2020",
                CheckOut= "21/12/2020",
                CantAdults = 2,
                CantChildrens = 1,
                CantBabys = 0,
            };
            List<House> emptyHousesWithIdTP = new List<House>();
            List<HouseSearchResultModel> housesResult = new List<HouseSearchResultModel>(){};
            HouseSearch houseSearch = houseSearchModel.ToEntity();
            mock.Setup(mock=> mock.GetHousesBy(It.IsAny<HouseSearch>())).Returns(emptyHousesWithIdTP);

            var result = controller.GetHousesBy(houseSearchModel);

            var okResult = result as OkObjectResult;
            var houses = okResult.Value as IEnumerable<HouseSearchResultModel>;
            Assert.IsTrue(housesResult.SequenceEqual(houses));
        }
    }
}