using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.Test.Test
{
    [TestClass]
    public class BookingTest
    {
        public Booking booking;
        [TestInitialize]
        public void SetUp()
        {
            booking = new Booking()
                {
                    Id = 2,
                    Name = "Other booking",
                    Email = "mail2@mail.com",
                    HouseId = 0,
                    State = "Passed",
                    Price = 200,
                    CheckIn = new System.DateTime(),
                    CheckOut= new System.DateTime(),
                };
        }
        [TestMethod]
        public void TestUpdateName()
        {
            Booking newBooking = new Booking()
                {
                    Name = "new name booking",
                    Email = null,
                    HouseId = 0,
                    State = null,
                    Price = 0,
                    CheckIn = DateTime.MinValue,
                    CheckOut= DateTime.MinValue,
                };

            booking.Update(newBooking);

            Assert.AreEqual(newBooking.Name, booking.Name);
        }
        [TestMethod]
        public void TestUpdateEmail()
        {
            Booking newBooking = new Booking()
                {
                    Name = null,
                    Email = "new mail",
                    HouseId = 0,
                    State = null,
                    Price = 0,
                    CheckIn = DateTime.MinValue,
                    CheckOut= DateTime.MinValue,
                };

            booking.Update(newBooking);

            Assert.AreEqual(newBooking.Email, booking.Email);
        }
        [TestMethod]
        public void TestUpdateHouseId()
        {
            Booking newBooking = new Booking()
                {
                    Name = null,
                    Email = null,
                    HouseId = 120,
                    State = null,
                    Price = 0,
                    CheckIn = DateTime.MinValue,
                    CheckOut= DateTime.MinValue,
                };

            booking.Update(newBooking);

            Assert.AreEqual(newBooking.HouseId, booking.HouseId);
        }
        [TestMethod]
        public void TestUpdatePrice()
        {
            Booking newBooking = new Booking()
                {
                    Name = null,
                    Email = null,
                    HouseId = 0,
                    State = null,
                    Price = 110,
                    CheckIn = DateTime.MinValue,
                    CheckOut= DateTime.MinValue,
                };

            booking.Update(newBooking);

            Assert.AreEqual(newBooking.Price, booking.Price);
        }
        [TestMethod]
        public void TestUpdateCheckIn()
        {
            Booking newBooking = new Booking()
                {
                    Name = null,
                    Email = null,
                    HouseId = 0,
                    State = null,
                    Price = 0,
                    CheckIn = DateTime.Today,
                    CheckOut= DateTime.MinValue,
                };

            booking.Update(newBooking);

            Assert.AreEqual(newBooking.CheckIn, booking.CheckIn);
        }
        [TestMethod]
        public void TestUpdateCheckOut()
        {
            Booking newBooking = new Booking()
                {
                    Name = null,
                    Email = null,
                    HouseId = 0,
                    State = null,
                    Price = 0,
                    CheckIn = DateTime.MinValue,
                    CheckOut= DateTime.Today,
                };

            booking.Update(newBooking);

            Assert.AreEqual(newBooking.CheckOut, booking.CheckOut);
        }

        [TestMethod]
        public void TestRandom()
        {
            string random = Booking.RandomString();
            Booking newBooking = new Booking()
                {
                    Name = null,
                    Email = null,
                    HouseId = 0,
                    State = null,
                    Price = 0,
                    Code = random,
                    CheckIn = DateTime.MinValue,
                    CheckOut= DateTime.Today,
                };


            Assert.AreEqual(random,newBooking.Code);
        }
        [TestMethod]
        public void TestState()
        {
            string stateNew = "state";
            Booking newBooking = new Booking()
            {
                Name = null,
                Email = null,
                HouseId = 0,
                State = stateNew,
                Price = 0,
                Code = null,
                CheckIn = DateTime.MinValue,
                CheckOut = DateTime.Today,
            };

            booking.Update(newBooking);

            Assert.AreEqual(stateNew, newBooking.State);
        }
        [TestMethod]
        public void TestId()
        {
            int id = 1;

            Booking newBooking = new Booking()
            {
                Name = null,
                Email = null,
                HouseId = 0,
                Id = 1,
                Price = 0,
                Code = null,
                CheckIn = DateTime.MinValue,
                CheckOut = DateTime.Today,
            };


            Assert.AreEqual(id, newBooking.Id);
        }
        [TestMethod]
        public void TestTouristPoint()
        {
            House house = new House();

            Booking newBooking = new Booking()
            {
                Name = null,
                Email = null,
                HouseId = 0,
                House = house,
                Price = 0,
                Code = null,
                CheckIn = DateTime.MinValue,
                CheckOut = DateTime.Today,
            };


            Assert.AreEqual(house, newBooking.House);
        }
    }
}