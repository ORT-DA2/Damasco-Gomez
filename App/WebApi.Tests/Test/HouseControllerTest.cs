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
        private House houseWithdId1;
        private Mock<IHouseLogic> mockHouseLogic;
        private HouseController controller ;
        private HouseSearchModel houseSearchModelNull;
        [TestInitialize]
        public void InitVariables()
        {
            housesToReturn = new List<House>()
            {
                new House()
                {
                    Id = 1,
                    Avaible = true ,
                    PricePerNight = 100,
                    TouristPointId = 1,
                    TouristPoint = new TouristPoint()
                    {
                        Id = 1, 
                        Name = "touriste point hose",
                        CategoriesTouristPoints = new List<CategoryTouristPoint>()
                        {
                            new CategoryTouristPoint()
                            {
                                Category = new Category(){Id=1,Name="Name category"},
                                CategoryId = 1,
                                TouristPoint = new TouristPoint(){Id = 1},
                                TouristPointId = 1,
                            }
                        }
                    },
                    Name = "Name house 1",
                    Starts = 1,
                    Address = "Address 1",
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
                    Description = "Description house 4",
                    Phone = 99898899 ,
                    Contact = "Person Name4",
                }
            };
            housesToReturnEmpty = new List<House>();
            houseWithdId1 = housesToReturn.First();
            mockHouseLogic = new Mock<IHouseLogic>(MockBehavior.Strict);
            controller = new HouseController(mockHouseLogic.Object);
            houseSearchModelNull = new HouseSearchModel();
        }
        [TestMethod]
        public void TestGetAllHousesOk()
        {
            IEnumerable<HouseBasicModel> houseBasicModels = housesToReturn.Select(m => new HouseBasicModel(m));
            mockHouseLogic.Setup(m => m.GetAll()).Returns(housesToReturn);

            var result = controller.GetHousesBy(houseSearchModelNull);

            var okResult = result as OkObjectResult;
            var houses = okResult.Value as IEnumerable<HouseBasicModel>;
            mockHouseLogic.VerifyAll();
            Assert.IsTrue(houseBasicModels.SequenceEqual(houses));
        }

        [TestMethod]
        public void TestGetAllHousesVacia()
        {
            IEnumerable<HouseBasicModel> houseBasicModels = housesToReturnEmpty.Select(m => new HouseBasicModel(m));
            mockHouseLogic.Setup(m => m.GetAll()).Returns(housesToReturnEmpty);

            var result = controller.GetHousesBy(houseSearchModelNull);

            var okResult = result as OkObjectResult;
            var houses = okResult.Value as IEnumerable<HouseBasicModel>;
            mockHouseLogic.VerifyAll();
            Assert.IsTrue(houseBasicModels.SequenceEqual(houses));
        }
        [TestMethod]
        public void TestGetByOk()
        {
            int id = 1;
            HouseDetailModel houseDetailModel = new HouseDetailModel(houseWithdId1);
            mockHouseLogic.Setup(m => m.GetBy(id)).Returns(houseWithdId1);

            var result = controller.GetBy(id);

            var okResult = result as OkObjectResult;
            var houses = okResult.Value as HouseDetailModel;
            Assert.IsTrue(houses.Equals(houseDetailModel));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGetByNotFound()
        {
            int id = 4;
            ArgumentException exist = new ArgumentException();
            mockHouseLogic.Setup(m => m.GetBy(id)).Throws(exist);

            var result = controller.GetBy(id);

            mockHouseLogic.VerifyAll();
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
                Description = "Description house 1",
                Phone = 99898899 ,
                Contact = "Person Name1",
            };
            House house = houseModel.ToEntity();
            mockHouseLogic.Setup(m => m.Add(house)).Returns(house);
            HouseBasicModel houseBasicModel = new HouseBasicModel(house);

            var result = controller.Post(houseModel);

            var okResult = result as CreatedAtRouteResult;
            mockHouseLogic.VerifyAll();
            Assert.IsNotNull(okResult);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPostFailSameHouse()
        {
            HouseModel houseModel = new HouseModel()
            {
            };
            House house = houseModel.ToEntity();
            Exception exist = new AggregateException();
            mockHouseLogic.Setup(p => p.Add(house)).Throws(exist);

            var result = controller.Post(houseModel);

            mockHouseLogic.VerifyAll();
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPostFailValidation()
        {
            HouseModel houseModel = new HouseModel();
            House house = houseModel.ToEntity();
            ArgumentException exist = new ArgumentException();
            mockHouseLogic.Setup(p => p.Add(house)).Throws(exist);

            var result = controller.Post(houseModel);

            mockHouseLogic.VerifyAll();
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPostFailServer()
        {
            HouseModel houseModel = new HouseModel();
            House house = houseModel.ToEntity();
            ArgumentException exist = new ArgumentException();
            mockHouseLogic.Setup(p => p.Add(house)).Throws(exist);

            var result = controller.Post(houseModel);

            mockHouseLogic.VerifyAll();
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
                Description = "Description house 1",
                Phone = 99898899 ,
                Contact = "Person Name1",
            };
            houseWithdId1 = houseModel.ToEntity();
            mockHouseLogic.Setup(m => m.Update(houseWithdId1.Id,houseWithdId1)).Returns(houseWithdId1);
            HouseBasicModel basicModel = new HouseBasicModel(houseWithdId1);

            var result = controller.Put(houseWithdId1.Id, houseModel);

            var okResult = result as CreatedAtRouteResult;
            mockHouseLogic.VerifyAll();
            Assert.IsNotNull(okResult);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
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
                Description = "Description house 1",
                Phone = 99898899 ,
                Contact = "Person Name1",
            };
            houseWithdId1 = houseModel.ToEntity();
            ArgumentException exception = new ArgumentException();
            mockHouseLogic.Setup(p => p.Update(houseWithdId1.Id,houseWithdId1)).Throws(exception);

            var result = controller.Put(houseWithdId1.Id, houseModel);

            mockHouseLogic.VerifyAll();
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
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
                Description = "Description house 1",
                Phone = 99898899 ,
                Contact = "Person Name1",
                Images = new List<string>(){"image.png"},
            };
            houseWithdId1 = houseModel.ToEntity();
            Exception exist = new Exception();
            mockHouseLogic.Setup(p => p.Update(houseWithdId1.Id,houseWithdId1)).Throws(exist);

            var result = controller.Put(houseWithdId1.Id, houseModel);

            mockHouseLogic.VerifyAll();
        }
        [TestMethod]
        public void TestDeleteWithId()
        {
            House house = housesToReturn.First();
            mockHouseLogic.Setup(m => m.GetBy(house.Id)).Returns(house);
            mockHouseLogic.Setup(mockHouseLogic=> mockHouseLogic.Delete(house.Id));

            var result = controller.Delete(house.Id);

            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestDeleteWithIdNotFound()
        {
            House house = housesToReturn.First();
            House houseNull = null;
            mockHouseLogic.Setup(m => m.GetBy(house.Id)).Returns(houseNull);
            mockHouseLogic.Setup(mockHouseLogic=> mockHouseLogic.Delete(house.Id));

            var result = controller.Delete(house.Id);
        }

        [TestMethod]
        public void TestDelete()
        {
            mockHouseLogic.Setup(mockHouseLogic=> mockHouseLogic.Delete());
            
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
            IEnumerable<HouseBasicModel> housesDetail = housesWithIdTP.Select(m => new HouseBasicModel(m));
            mockHouseLogic.Setup(m => m.GetHousesBy(It.IsAny<HouseSearch>())).Returns(housesWithIdTP);

            var result = controller.GetHousesBy(houseSearchModel);

            var okResult = result as OkObjectResult;
            var houses = okResult.Value as IEnumerable<HouseBasicModel>;
            Assert.IsTrue(housesDetail.SequenceEqual(houses));
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
            List<HouseBasicModel> housesResult = new List<HouseBasicModel>(){};
            HouseSearch houseSearch = houseSearchModel.ToEntity();
            mockHouseLogic.Setup(mockHouseLogic=> mockHouseLogic.GetHousesBy(It.IsAny<HouseSearch>())).Returns(emptyHousesWithIdTP);

            var result = controller.GetHousesBy(houseSearchModel);

            var okResult = result as OkObjectResult;
            var houses = okResult.Value as IEnumerable<HouseBasicModel>;
            Assert.IsTrue(housesResult.SequenceEqual(houses));
        }
    }
}
