using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic.Logics;
using DataAccess.Repositories;
using DataAccessInterface.Repositories;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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

        [TestInitialize]
        public void initVariables()
        {
             bookingsToReturn = new List<Booking>()
            {
                new Booking()
                {
                    Id = 1,
                    Name = "Booking 1",
                },
                new Booking()
                {
                    Id = 2,
                    Name = "Booking 2",
                }
            };
            emptyBookings = new List<Booking>();
            mock = new Mock<IBookingRepository>(MockBehavior.Strict);
            bookingLogic = new BookingLogic(mock.Object);
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
            Booking booking = bookingsToReturn.First();
            mock.Setup(m => m.Add(booking)).Returns(booking);
            var result= bookingLogic.Add(booking);
        
            Assert.AreEqual(booking, result );
        }
         [TestMethod]
        public void TestAddValidateError()
        {
            Booking booking = bookingsToReturn.First(); // Booking tiene que terner un formato erroneo despues para que la validación falle
            mock.Setup(m => m.Add(booking)).Returns(booking);

            var result = bookingLogic.Add(booking);

            Assert.AreEqual(booking, result); 
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddExistError()
        {
            Booking booking = bookingsToReturn.First(); 
            ArgumentException exception = new ArgumentException();
            mock.Setup(m => m.Add(booking)).Throws(exception);

            var reuslt = bookingLogic.Add(booking);
        }
         [TestMethod]
        public void TestUdpateOk ()
        {
            Booking booking = bookingsToReturn.First();
            mock.Setup(m => m.Update(booking.Id,booking));

            bookingLogic.Update(booking.Id, booking);

            mock.VerifyAll();
        }
         [TestMethod]
        public void TestUpdateValidateError()
        {
            Booking booking = bookingsToReturn.First();// Booking tiene que terner un formato erroneo despues para que la validación falle
             mock.Setup(m => m.Update(booking.Id,booking));

            bookingLogic.Update(booking.Id,booking);

            mock.VerifyAll();
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestUpdateExistError()
        {
            Booking booking = bookingsToReturn.First();
            ArgumentException exception = new ArgumentException();
            mock.Setup(m => m.Update(booking.Id, booking)).Throws(exception);

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