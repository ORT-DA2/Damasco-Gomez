using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogicInterface;
using Domain;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Moq;
using WebApi.Controllers;

namespace WebApi.Tests
{
    [TestClass]
    public class BookingControllerTest
    {
        private List<Booking> bookingsToReturn;
        private List<Booking> bookingsToReturnEmpty;
        private Booking bookingWithId1;
        private Mock<IBookingLogic> mockBookingLogic;
        private BookingController controllerBooking ;
        [TestInitialize]
        public void InitVariables()
        {
            bookingsToReturn = new List<Booking>()
            {
                new Booking()
                {
                    Id = 1,
                    Name = "New booking",
                    Email = "mail1@mail.com",
                    HouseId = 1,
                    House = new House(){ Id=1, Name="house in booking"},
                    State = new State(){Id=1},
                    StateId = 1,
                    Price = 100,
                    CheckIn = new System.DateTime(),
                    CheckOut= new System.DateTime(),
                },
                new Booking()
                {
                    Id = 2,
                    Name = "Other booking",
                    Email = "mail2@mail.com",
                    HouseId = 1,
                    House = new House(){Id=1,Name="house in booking"},
                    State = new State(){Id=1},
                    StateId = 1,
                    Price = 200,
                    CheckIn = new System.DateTime(),
                    CheckOut= new System.DateTime(),
                },
                new Booking()
                {
                    Id = 3,
                    Name = "And other booking",
                    Email = "mail3@mail.com",
                    HouseId = 1,
                    House = new House(){Id=1,Name="house in booking"},
                    StateId = 1,
                    Price = 300,
                    CheckIn = new System.DateTime(),
                    CheckOut= new System.DateTime(),
                },
                new Booking()
                {
                    Id = 4,
                    Name = "And one more booking",
                    Email = "mail4@mail.com",
                    HouseId = 1,
                    House = new House(){Id=1,Name="house in booking"},
                    StateId = 3,
                    Price = 400,
                    CheckIn = new System.DateTime(),
                    CheckOut= new System.DateTime(),
                }
            };
            bookingsToReturnEmpty = new List<Booking>();
            bookingWithId1 = bookingsToReturn.First();
            mockBookingLogic = new Mock<IBookingLogic>(MockBehavior.Strict);
            controllerBooking = new BookingController(mockBookingLogic.Object);
        }
        [TestMethod]
        public void TestGetAllBookingsOk()
        {
            mockBookingLogic.Setup(m => m.GetAll()).Returns(bookingsToReturn);
            IEnumerable<BookingBasicModel> bookingModels = bookingsToReturn.Select(m => new BookingBasicModel(m));

            var result = controllerBooking.Get();

            var okResult = result as OkObjectResult;
            var bookings = okResult.Value as IEnumerable<BookingBasicModel>;
            mockBookingLogic.VerifyAll();
            Assert.IsTrue(bookingModels.SequenceEqual(bookings));
        }

        [TestMethod]
        public void TestGetAllBookingsVacia()
        {
            IEnumerable<BookingBasicModel> basicModelList = new List<BookingBasicModel>(){};
            mockBookingLogic.Setup(m => m.GetAll()).Returns(bookingsToReturnEmpty);

            var result = controllerBooking.Get();

            var okResult = result as OkObjectResult;
            var bookings = okResult.Value as IEnumerable<BookingBasicModel>;
            mockBookingLogic.VerifyAll();
            Assert.IsTrue(basicModelList.SequenceEqual(bookings));
        }
        [TestMethod]
        public void TestGetByOk()
        {
            int id = 1;
            mockBookingLogic.Setup(m => m.GetBy(id)).Returns(bookingWithId1);
            BookingDetailModel bookingDetailModel = new BookingDetailModel(bookingWithId1);

            var result = controllerBooking.GetBy(id);

            var okResult = result as OkObjectResult;
            var bookings = okResult.Value as BookingDetailModel;
            mockBookingLogic.VerifyAll();
            Assert.IsTrue(bookings.Equals(bookingDetailModel));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGetByNotFound()
        {
            int id = 4;
            ArgumentException exist = new ArgumentException();
            mockBookingLogic.Setup(m => m.GetBy(id)).Throws(exist);

            var result = controllerBooking.GetBy(id);

            mockBookingLogic.VerifyAll();
        }
        [TestMethod]
        public void TestPostOk()
        {
            BookingModel bookingModel = new BookingModel()
            {
                Name = "Name Booking",
                Email = "Email ",
                HouseId = 1,
                Price = 100,
                CheckIn = DateTime.Today,
                CheckOut = DateTime.Today
            };
            Booking booking = bookingModel.ToEntity();
            booking.State = new State() {Id = 1};
            booking.House = new House() {Id = 1};
            mockBookingLogic.Setup(m => m.Add(bookingModel.ToEntity(true))).Returns(booking);

            var result = controllerBooking.Post(bookingModel);

            var okResult = result as CreatedAtRouteResult;
            Assert.IsNotNull(okResult);
        }
        [TestMethod]
        [ExpectedException(typeof(AggregateException))]
        public void TestPostFailSameBooking()
        {
            Exception exist = new AggregateException();
            BookingModel bookingModel = new BookingModel()
            {
                Name = "Name Booking",
                Email = "Email ",
                HouseId = 1,
                StateId = 1,
                Price = 100,
                CheckIn = DateTime.Today,
                CheckOut = DateTime.Today
            };
            mockBookingLogic.Setup(p => p.Add(bookingModel.ToEntity(true))).Throws(exist);

            var result = controllerBooking.Post(bookingModel);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPostFailValidation()
        {
            Exception exist = new ArgumentException();
            BookingModel bookingModel = new BookingModel()
            {
                Name = "Name Booking",
                Email = "Email ",
                HouseId = 1,
                StateId = 1,
                Price = 100,
                CheckIn = DateTime.Today,
                CheckOut = DateTime.Today
            };
            mockBookingLogic.Setup(p => p.Add(bookingModel.ToEntity(true))).Throws(exist);

            var result = controllerBooking.Post(bookingModel);
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestPostFailServer()
        {
            Exception exist = new Exception();
            BookingModel bookingModel = new BookingModel()
            {
                Name = "Name Booking",
                Email = "Email ",
                HouseId = 1,
                StateId = 1,
                Price = 100,
                CheckIn = DateTime.Today,
                CheckOut = DateTime.Today
            };
            mockBookingLogic.Setup(p => p.Add(bookingModel.ToEntity(true))).Throws(exist);

            var result = controllerBooking.Post(bookingModel);
        }
        [TestMethod]
        public void TestPutOk()
        {
            BookingModel bookingModel = new BookingModel()
            {
                Name = "Name Booking",
                Email = "Email ",
                HouseId = 1,
                StateId = 1,
                Price = 100,
                CheckIn = DateTime.Today,
                CheckOut = DateTime.Today
            };
            Booking booking = bookingModel.ToEntity(false);
            booking.House = new House() {Id = 1};
            booking.State = new State(){Id = 1};
            mockBookingLogic.Setup(m => m.Update(booking.Id,booking)).Returns(booking);

            var result = controllerBooking.Put(booking.Id, bookingModel);

            var okResult = result as CreatedAtRouteResult;
            Assert.IsNotNull(okResult.Value);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPutFailValidate()
        {
            BookingModel bookingModel = new BookingModel();
            Booking booking = bookingModel.ToEntity(false);
            Exception exist = new ArgumentException();
            mockBookingLogic.Setup(p => p.Update(booking.Id,booking)).Throws(exist);

            var result = controllerBooking.Put(booking.Id, bookingModel);

            mockBookingLogic.VerifyAll();
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestPutFailServer()
        {
            Exception exist = new Exception();
            BookingModel bookingModel = new BookingModel()
            {
                Name = "Name Booking",
                Email = "Email ",
                HouseId = 1,
                StateId = 1,
                Price = 100,
                CheckIn = DateTime.Today,
                CheckOut = DateTime.Today
            };
            Booking booking = bookingModel.ToEntity(false);
            mockBookingLogic.Setup(p => p.Update(booking.Id,booking)).Throws(exist);

            var result = controllerBooking.Put(booking.Id,bookingModel);
        }
        [TestMethod]
        public void TestDeleteWithId()
        {
            Booking booking = bookingsToReturn.First();
            mockBookingLogic.Setup(m => m.GetBy(booking.Id)).Returns(booking);
            mockBookingLogic.Setup(mockBookingLogic=> mockBookingLogic.Delete(booking.Id));

            var result = controllerBooking.Delete(booking.Id);

            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestDeleteWithIdNotFound()
        {
            Booking booking = bookingsToReturn.First();
            Booking bookingNull = null;
            mockBookingLogic.Setup(m => m.GetBy(booking.Id)).Returns(bookingNull);
            mockBookingLogic.Setup(mockBookingLogic=> mockBookingLogic.Delete(booking.Id));

            var result = controllerBooking.Delete(booking.Id);
        }

        [TestMethod]
        public void TestDelete()
        {
            mockBookingLogic.Setup(mockBookingLogic=> mockBookingLogic.Delete());

            var result = controllerBooking.Delete();

            Assert.IsNotNull(result);
        }
    }
}