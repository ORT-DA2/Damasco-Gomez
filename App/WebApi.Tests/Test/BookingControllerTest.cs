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
    public class BookingControllerTest
    {
        private List<Booking> bookingsToReturn;
        private List<Booking> bookingsToReturnEmpty;
        private Booking bookingId1;
        private Mock<IBookingLogic> mock;
        private BookingController controller ;
        [TestInitialize]
        public void initVariables()
        {
            bookingsToReturn = new List<Booking>()
            {
                new Booking()
                {
                    Id = 1,
                    Name = "New booking",
                    Email = "mail1@mail.com",
                    HouseId = 0,
                    State = "Init",
                    Price = 100,
                    CheckIn = new System.DateTime(),
                    CheckOut= new System.DateTime(),
                },
                new Booking()
                {
                    Id = 2,
                    Name = "Other booking",
                    Email = "mail2@mail.com",
                    HouseId = 0,
                    State = "Passed",
                    Price = 200,
                    CheckIn = new System.DateTime(),
                    CheckOut= new System.DateTime(),
                },
                new Booking()
                {
                    Id = 3,
                    Name = "And other booking",
                    Email = "mail3@mail.com",
                    HouseId = 0,
                    State = "Init",
                    Price = 300,
                    CheckIn = new System.DateTime(),
                    CheckOut= new System.DateTime(),
                },
                new Booking()
                {
                    Id = 4,
                    Name = "And one more booking",
                    Email = "mail4@mail.com",
                    HouseId = 0,
                    State = "Init",
                    Price = 400,
                    CheckIn = new System.DateTime(),
                    CheckOut= new System.DateTime(),
                }
            };
            bookingsToReturnEmpty = new List<Booking>();
            bookingId1 = bookingsToReturn.First();
            mock = new Mock<IBookingLogic>(MockBehavior.Strict);
            controller = new BookingController(mock.Object);
        }
        [TestMethod]
        public void TestGetAllBookingsOk()
        {
            mock.Setup(m => m.GetAll()).Returns(bookingsToReturn);

            var result = controller.Get();

            var okResult = result as OkObjectResult;
            var bookings = okResult.Value as IEnumerable<Booking>;
            mock.VerifyAll();
            Assert.IsTrue(bookingsToReturn.SequenceEqual(bookings));
        }

        [TestMethod]
        public void TestGetAllBookingsVacia()
        {
            mock.Setup(m => m.GetAll()).Returns(bookingsToReturnEmpty);

            var result = controller.Get();

            var okResult = result as OkObjectResult;
            var bookings = okResult.Value as IEnumerable<Booking>;
            mock.VerifyAll();
            Assert.IsTrue(bookingsToReturnEmpty.SequenceEqual(bookings));
        }
        [TestMethod]
        public void TestGetByOk()
        {
            int id = 1;
            mock.Setup(m => m.GetBy(id)).Returns(bookingId1);

            var result = controller.GetBy(id);

            var okResult = result as OkObjectResult;
            var bookings = okResult.Value as Booking;
            mock.VerifyAll();
            Assert.IsTrue(bookings.Equals(bookingId1));
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
            mock.Setup(m => m.Add(bookingId1)).Returns(bookingId1);

            var result = controller.Post(bookingId1);

            var okResult = result as CreatedAtRouteResult;
            mock.VerifyAll();
            Assert.IsNotNull(okResult);
            Assert.AreEqual("GetBooking", okResult.RouteName);
            Assert.AreEqual(okResult.Value, bookingId1);
        }
        [TestMethod]
        public void TestPostFailSameBooking()
        {
            bookingId1 = bookingsToReturn.First();
            Exception exist = new AggregateException();
            mock.Setup(p => p.Add(bookingId1)).Throws(exist);

            var result = controller.Post(bookingId1);

            mock.VerifyAll();
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        [TestMethod]
        public void TestPostFailValidation()
        {
            bookingId1 = bookingsToReturn.First();
            Exception exist = new ArgumentException();
            mock.Setup(p => p.Add(bookingId1)).Throws(exist);

            var result = controller.Post(bookingId1);

            mock.VerifyAll();
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        [TestMethod]
        public void TestPostFailServer()
        {
            bookingId1 = bookingsToReturn.First();
            Exception exist = new Exception();
            mock.Setup(p => p.Add(bookingId1)).Throws(exist);

            var result = controller.Post(bookingId1);

            mock.VerifyAll();
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        [TestMethod]
        public void TestPutOk()
        {
            bookingId1 = bookingsToReturn.First();
            string newName = "New name booking";
            bookingId1.Name = newName;
            mock.Setup(m => m.Update(bookingId1.Id,bookingId1));

            var result = controller.Put(bookingId1.Id, bookingId1);

            var okResult = result as CreatedAtRouteResult;
            mock.VerifyAll();
            Assert.IsNotNull(okResult);
            Assert.AreEqual("GetBooking", okResult.RouteName);
            Assert.AreEqual(okResult.Value, bookingId1);
        }
        [TestMethod]
        public void TestPutFailValidate()
        {
            bookingId1 = bookingsToReturn.First();
            Exception exist = new ArgumentException();
            mock.Setup(p => p.Update(bookingId1.Id,bookingId1)).Throws(exist);

            var result = controller.Put(bookingId1.Id, bookingId1);

            mock.VerifyAll();
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        [TestMethod]
        public void TestPutFailServer()
        {
            bookingId1 = bookingsToReturn.First();
            Exception exist = new Exception();
            mock.Setup(p => p.Update(bookingId1.Id,bookingId1)).Throws(exist);

            var result = controller.Put(bookingId1.Id, bookingId1);

            mock.VerifyAll();
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        [TestMethod]
        public void TestDeleteWithId()
        {
            Booking booking = bookingsToReturn.First();
            mock.Setup(m => m.GetBy(booking.Id)).Returns(booking);
            mock.Setup(mock=> mock.Delete(booking.Id));

            var result = controller.Delete(booking.Id);

            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestDeleteWithIdNotFound()
        {
            Booking booking = bookingsToReturn.First();
            Booking bookingNull = null;
            mock.Setup(m => m.GetBy(booking.Id)).Returns(bookingNull);
            mock.Setup(mock=> mock.Delete(booking.Id));

            var result = controller.Delete(booking.Id);

            Assert.IsInstanceOfType(result,typeof(NotFoundResult));
        }

        [TestMethod]
        public void TestDelete()
        {
            mock.Setup(mock=> mock.Delete());

            var result = controller.Delete();
            
            Assert.IsNotNull(result);
        }
    }
}