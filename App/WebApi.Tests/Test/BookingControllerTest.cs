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
            bookingId1 = bookingsToReturn.First();
            mock = new Mock<IBookingLogic>(MockBehavior.Strict);
            controller = new BookingController(mock.Object);
        }
        [TestMethod]
        public void TestGetAllBookingsOk()
        {
            mock.Setup(m => m.GetAll()).Returns(bookingsToReturn);
            IEnumerable<BookingBasicModel> bookingModels = bookingsToReturn.Select(m => new BookingBasicModel(m));

            var result = controller.Get();

            var okResult = result as OkObjectResult;
            var bookings = okResult.Value as IEnumerable<BookingBasicModel>;
            mock.VerifyAll();
            Assert.IsTrue(bookingModels.SequenceEqual(bookings));
        }

        [TestMethod]
        public void TestGetAllBookingsVacia()
        {
            IEnumerable<BookingBasicModel> basicModelList = new List<BookingBasicModel>(){};
            mock.Setup(m => m.GetAll()).Returns(bookingsToReturnEmpty);

            var result = controller.Get();

            var okResult = result as OkObjectResult;
            var bookings = okResult.Value as IEnumerable<BookingBasicModel>;
            mock.VerifyAll();
            Assert.IsTrue(basicModelList.SequenceEqual(bookings));
        }
        [TestMethod]
        public void TestGetByOk()
        {
            int id = 1;
            mock.Setup(m => m.GetBy(id)).Returns(bookingId1);
            BookingDetailModel bookingDetailModel = new BookingDetailModel(bookingId1);

            var result = controller.GetBy(id);

            var okResult = result as OkObjectResult;
            var bookings = okResult.Value as BookingDetailModel;
            mock.VerifyAll();
            Assert.IsTrue(bookings.Equals(bookingDetailModel));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGetByNotFound()
        {
            int id = 4;
            ArgumentException exist = new ArgumentException();
            mock.Setup(m => m.GetBy(id)).Throws(exist);

            var result = controller.GetBy(id);

            mock.VerifyAll();
        }
        [TestMethod]
        public void TestPostOk()
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
            Booking booking = bookingModel.ToEntity();
            mock.Setup(m => m.Add(bookingModel.ToEntity(true))).Returns(bookingModel.ToEntity());
            BookingBasicModel bookingBasic = new BookingBasicModel(booking);

            var result = controller.Post(bookingModel);

            var okResult = result as CreatedAtRouteResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual("GetBooking", okResult.RouteName);
            Assert.AreEqual(okResult.Value,bookingBasic);
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
            mock.Setup(p => p.Add(bookingModel.ToEntity(true))).Throws(exist);

            var result = controller.Post(bookingModel);
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
            mock.Setup(p => p.Add(bookingModel.ToEntity(true))).Throws(exist);

            var result = controller.Post(bookingModel);
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
            mock.Setup(p => p.Add(bookingModel.ToEntity(true))).Throws(exist);

            var result = controller.Post(bookingModel);
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
            mock.Setup(m => m.Update(booking.Id,booking)).Returns(booking);
            BookingBasicModel bookingBasic = new BookingBasicModel(booking);

            var result = controller.Put(booking.Id, bookingModel);

            var okResult = result as CreatedAtRouteResult;
            Assert.IsNotNull(okResult.Value);
            Assert.AreEqual("GetBooking", okResult.RouteName);
            Assert.AreEqual(okResult.Value, bookingBasic);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPutFailValidate()
        {
            BookingModel bookingModel = new BookingModel();
            Booking booking = bookingModel.ToEntity(false);
            Exception exist = new ArgumentException();
            mock.Setup(p => p.Update(booking.Id,booking)).Throws(exist);

            var result = controller.Put(booking.Id, bookingModel);

            mock.VerifyAll();
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
            mock.Setup(p => p.Update(booking.Id,booking)).Throws(exist);

            var result = controller.Put(booking.Id,bookingModel);
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