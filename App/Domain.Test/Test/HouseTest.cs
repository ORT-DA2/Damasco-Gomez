using System;
using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.Test.Test
{
    [TestClass]
    public class HouseTest
    {
        public House house;
        [TestInitialize]
        public void SetUp()
        {
            house = new House()
                {
                    Id = 1,
                    Avaible = false ,
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
        }
        [TestMethod]
        public void TestUpdateAvailable()
        {
            House newHouse = new House()
                {
                    Avaible = true ,
                    PricePerNight = 0,
                    TouristPointId = 0,
                    Name = null,
                    Starts = 0,
                    Address = null,
                    Ilustrations = null,
                    Description = null,
                    Phone = 0 ,
                    Contact = null,
                };

            house.Update(newHouse);

            Assert.AreEqual(newHouse.Avaible, house.Avaible);
        }
        [TestMethod]
        public void TestUpdateAvailableFalse()
        {
            House newHouse = new House()
                {
                    Avaible = false ,
                    PricePerNight = 0,
                    TouristPointId = 0,
                    Name = null,
                    Starts = 0,
                    Address = null,
                    Ilustrations = null,
                    Description = null,
                    Phone = 0 ,
                    Contact = null,
                };

            house.Update(newHouse);

            Assert.AreEqual(newHouse.Avaible, house.Avaible);
        }
        [TestMethod]
        public void TestUpdateName()
        {
            House newHouse = new House()
                {
                    Avaible = true ,
                    PricePerNight = 0,
                    TouristPointId = 0,
                    Name = "New name",
                    Starts = 0,
                    Address = null,
                    Ilustrations = null,
                    Description = null,
                    Phone = 0 ,
                    Contact = null,
                };

            house.Update(newHouse);

            Assert.AreEqual(newHouse.Name, house.Name);
        }
        [TestMethod]
        public void TestUpdatePricePerNight()
        {
            House newHouse = new House()
                {
                    Avaible = true ,
                    PricePerNight = 12220,
                    TouristPointId = 0,
                    Name = null,
                    Starts = 0,
                    Address = null,
                    Ilustrations = null,
                    Description = null,
                    Phone = 0 ,
                    Contact = null,
                };

            house.Update(newHouse);

            Assert.AreEqual(newHouse.PricePerNight, house.PricePerNight);
        }
        [TestMethod]
        public void TestUpdateTouristPointId()
        {
            House newHouse = new House()
                {
                    Avaible = true ,
                    PricePerNight = 0,
                    TouristPointId = 234234,
                    Name = null,
                    Starts = 0,
                    Address = null,
                    Ilustrations = null,
                    Description = null,
                    Phone = 0 ,
                    Contact = null,
                };

            house.Update(newHouse);

            Assert.AreEqual(newHouse.TouristPointId, house.TouristPointId);
        }
        [TestMethod]
        public void TestUpdateStarts()
        {
            House newHouse = new House()
                {
                    Avaible = true ,
                    PricePerNight = 0,
                    TouristPointId = 0,
                    Name = null,
                    Starts = 5,
                    Address = null,
                    Ilustrations = null,
                    Description = null,
                    Phone = 0 ,
                    Contact = null,
                };

            house.Update(newHouse);

            Assert.AreEqual(newHouse.Starts, house.Starts);
        }
        [TestMethod]
        public void TestUpdateAddress()
        {
            House newHouse = new House()
                {
                    Avaible = true ,
                    PricePerNight = 0,
                    TouristPointId = 0,
                    Name = null,
                    Starts = 0,
                    Address = "new address",
                    Ilustrations = null,
                    Description = null,
                    Phone = 0 ,
                    Contact = null,
                };

            house.Update(newHouse);

            Assert.AreEqual(newHouse.Address, house.Address);
        }
        [TestMethod]
        public void TestUpdateIlustrations()
        {
            House newHouse = new House()
                {
                    Avaible = true ,
                    PricePerNight = 0,
                    TouristPointId = 0,
                    Name = null,
                    Starts = 0,
                    Address = null,
                    Ilustrations = "new ilust",
                    Description = null,
                    Phone = 0 ,
                    Contact = null,
                };

            house.Update(newHouse);

            Assert.AreEqual(newHouse.Ilustrations, house.Ilustrations);
        }
        [TestMethod]
        public void TestUpdateDescription()
        {
            House newHouse = new House()
                {
                    Avaible = true ,
                    PricePerNight = 0,
                    TouristPointId = 0,
                    Name = null,
                    Starts = 0,
                    Address = null,
                    Ilustrations = null,
                    Description = "new description",
                    Phone = 0 ,
                    Contact = null,
                };

            house.Update(newHouse);

            Assert.AreEqual(newHouse.Description, house.Description);
        }
        [TestMethod]
        public void TestUpdatePhone()
        {
            House newHouse = new House()
                {
                    Avaible = true ,
                    PricePerNight = 0,
                    TouristPointId = 0,
                    Name = null,
                    Starts = 0,
                    Address = null,
                    Ilustrations = null,
                    Description = null,
                    Phone = 3423240 ,
                    Contact = null,
                };

            house.Update(newHouse);

            Assert.AreEqual(newHouse.Phone, house.Phone);
        }
        [TestMethod]
        public void TestUpdatContact()
        {
            House newHouse = new House()
                {
                    Avaible = true ,
                    PricePerNight = 0,
                    TouristPointId = 0,
                    Name = null,
                    Starts = 0,
                    Address = null,
                    Ilustrations = null,
                    Description = null,
                    Phone = 0 ,
                    Contact = "new contact",
                };

            house.Update(newHouse);

            Assert.AreEqual(newHouse.Contact, house.Contact);
        }
        [TestMethod]
        public void TestCalculateTotalPrice()
        {
            house.PricePerNight = 100;
            HouseSearch houseSearch = new HouseSearch()
            {
                CheckIn = DateTime.Today,
                CheckOut = DateTime.Today.AddDays(6),
                CantAdults = 2,
                CantChildrens = 0,
                CantBabys = 0,
            };
            double priceResult = 100*2*6;
            double totalPriceResult = house.CalculateTotalPrice(houseSearch);
            Assert.AreEqual(totalPriceResult , priceResult);
        }
        [TestMethod]
        public void TestIsAvailable()
        {
            House newHouse = new House()
                {
                    Avaible = true ,
                    PricePerNight = 0,
                    TouristPointId = 0,
                    Name = null,
                    Starts = 0,
                    Address = null,
                    Ilustrations = null,
                    Description = null,
                    Phone = 0 ,
                    Contact = "new contact",
                };

            bool result = House.IsAvailable(newHouse);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestIsAvailableFalse()
        {
            House newHouse = new House()
                {
                    Avaible = false ,
                    PricePerNight = 0,
                    TouristPointId = 0,
                    Name = null,
                    Starts = 0,
                    Address = null,
                    Ilustrations = null,
                    Description = null,
                    Phone = 0 ,
                    Contact = "new contact",
                };

            bool result = House.IsAvailable(newHouse);

            Assert.IsFalse(result);
        }
    }
}