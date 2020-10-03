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
                    House = null,
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
                    Email = "",
                    House = null,
                    State = "",
                    Price = 0,
                    CheckIn = DateTime.MinValue,
                    CheckOut= DateTime.MinValue,
                };

            Booking.Update(booking,newBooking);

            Assert.AreEqual(newBooking.Name, booking.Name);
        }
        [TestMethod]
        public void TestUpdateEmail()
        {
            Booking newBooking = new Booking()
                {
                    Name = "",
                    Email = "new mail",
                    House = null,
                    State = "",
                    Price = 0,
                    CheckIn = DateTime.MinValue,
                    CheckOut= DateTime.MinValue,
                };

            Booking.Update(booking,newBooking);

            Assert.AreEqual(newBooking.Email, booking.Email);
        }
        [TestMethod]
        public void TestUpdateHouse()
        {
            Booking newBooking = new Booking()
                {
                    Name = "",
                    Email = "",
                    House = null,
                    State = "",
                    Price = 0,
                    CheckIn = DateTime.MinValue,
                    CheckOut= DateTime.MinValue,
                };

            Booking.Update(booking,newBooking);

            //Assert.AreEqual(newBooking.House, booking.House);
        }
        [TestMethod]
        public void TestUpdatePrice()
        {
            Booking newBooking = new Booking()
                {
                    Name = "",
                    Email = "",
                    House = null,
                    State = "",
                    Price = 110,
                    CheckIn = DateTime.MinValue,
                    CheckOut= DateTime.MinValue,
                };

            Booking.Update(booking,newBooking);

            Assert.AreEqual(newBooking.Price, booking.Price);
        }
        [TestMethod]
        public void TestUpdateCheckIn()
        {
            Booking newBooking = new Booking()
                {
                    Name = "",
                    Email = "",
                    House = null,
                    State = "",
                    Price = 0,
                    CheckIn = DateTime.Today,
                    CheckOut= DateTime.MinValue,
                };

            Booking.Update(booking,newBooking);

            Assert.AreEqual(newBooking.CheckIn, booking.CheckIn);
        }
        [TestMethod]
        public void TestUpdateCheckOut()
        {
            Booking newBooking = new Booking()
                {
                    Name = "",
                    Email = "",
                    House = null,
                    State = "",
                    Price = 0,
                    CheckIn = DateTime.MinValue,
                    CheckOut= DateTime.Today,
                };

            Booking.Update(booking,newBooking);

            Assert.AreEqual(newBooking.CheckOut, booking.CheckOut);
        }
    }
}