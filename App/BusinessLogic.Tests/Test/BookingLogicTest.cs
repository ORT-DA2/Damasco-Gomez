using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic.Logics;
using DataAccessInterface.Repositories;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Moq;

namespace BusinessLogic.Tests.Test
{
    [TestClass]
    public class BookingLogicTest
    {
        private  List<Booking> bookingsToReturn;
        private  List<Booking>  emptyBookings;
        private BookingLogic bookingLogic;
        private Mock<IBookingRepository> mock;
        private Mock<IHouseRepository> mock2;
        private House houseId1;

        [TestInitialize]
        public void initVariables()
        {
            bookingsToReturn = new List<Booking>()
            {
                new Booking()
                {
                    Id = 1,
                    Name = "Booking 1",
                    HouseId = 1,
                },
                new Booking()
                {
                    Id = 2,
                    Name = "Booking 2",
                    HouseId = 1,
                }
            };
            houseId1 = new House() {Id = 1, Avaible=true};
            emptyBookings = new List<Booking>();
            mock = new Mock<IBookingRepository>(MockBehavior.Strict);
            mock2 = new Mock<IHouseRepository>(MockBehavior.Strict);
            mock2.Setup(c => c.Find(houseId1.Id)).Returns(houseId1);
            bookingLogic = new BookingLogic(mock.Object,mock2.Object);
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
            Booking booking = bookingsToReturn.First();
            mock.Setup(m => m.Find(booking.Id)).Returns(booking);

            var result = bookingLogic.GetBy(booking.Id);

            mock.VerifyAll();
            Assert.AreEqual(result,booking);
        }
        [TestMethod]
        public void TestGetByFail()
        {
            Booking booking = bookingsToReturn.First();
            Booking empty = null;
            mock.Setup(m => m.Find(booking.Id)).Returns(empty);

            var result = bookingLogic.GetBy(booking.Id);

            mock.VerifyAll();
            Assert.IsNull(result);
        }
        public void TestAddOk()
        {
            BookingModel bookingModel = new BookingModel()
            {
                Name = "nombre",
                HouseId = 1
            };
            Booking booking = bookingModel.ToEntity();
            mock.Setup(m => m.Add(booking)).Returns(booking);
            var result = bookingLogic.Add(booking);

            Assert.AreEqual(booking, result);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddNull()
        {
            Booking booking = null;
            ArgumentException e = new ArgumentException();
            mock.Setup(m => m.Add(booking)).Throws(e);

            var result = bookingLogic.Add(booking);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddNullHouseId()
        {
            BookingModel bookingModel = new BookingModel()
            {
                Name = "nombre",
                HouseId = 0
            };
            Booking booking = bookingModel.ToEntity();
            mock2.Setup(m => m.ExistElement(booking.HouseId)).Returns(false);

            var result = bookingLogic.Add(booking);
        }
        [TestMethod]
        public void TestUpdateOk ()
        {
            BookingModel bookingModel = new BookingModel()
            {
                Name = "new name",
                HouseId = 1
            };
            Booking booking = bookingModel.ToEntity();
            int id  = booking.Id;
            mock.Setup(m => m.Update(booking.Id,booking));
            mock.Setup(m => m.Find(booking.Id)).Returns(booking);
            mock2.Setup(m => m.ExistElement(booking.HouseId)).Returns(true);
            mock2.Setup(m => m.Find(booking.HouseId)).Returns(houseId1);

            bookingLogic.Update(id, booking);

            mock.VerifyAll();
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestUpdateNull()
        {
            int id = 10000;
            Booking nullBooking = null;

            bookingLogic.Update(id,nullBooking);

            mock.VerifyAll();
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestUpdateNullHouseId()
        {
            BookingModel bookingModel = new BookingModel()
            {
                Name = "nombre",
                HouseId = 12
            };
            Booking booking = bookingModel.ToEntity();
            mock2.Setup(m => m.ExistElement(booking.HouseId)).Returns(false);

            bookingLogic.Update(booking.Id,booking);
        }
        [TestMethod]
        public void TestExistOk()
        {
            Booking booking = bookingsToReturn.First();
            mock.Setup(m => m.ExistElement(booking)).Returns(true);

            var result = bookingLogic.Exist(booking);

            mock.VerifyAll();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestNotExistOk()
        {
            Booking booking = bookingsToReturn.First();
            mock.Setup(m => m.ExistElement(booking)).Returns(false);
            var result = bookingLogic.Exist(booking);
            mock.VerifyAll();
            Assert.IsFalse(result);
        }
    }
}