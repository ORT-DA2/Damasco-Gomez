using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic.Logics;
using DataAccessInterface.Repositories;
using Domain;
using Domain.Entities;
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
        private Mock<IBookingRepository> mockBookingRepository;
        private Mock<IHouseRepository> mockHouseRepository;
        private Mock<IStateRepository> mockStateRepository;
        private House houseId1;

        [TestInitialize]
        public void InitVariables()
        {
            bookingsToReturn = new List<Booking>()
            {
                new Booking()
                {
                    Id = 1,
                    Name = "Booking 1",
                    HouseId = 1,
                    State = new State() {Id = 1},
                    StateId = 1,
                },
                new Booking()
                {
                    Id = 2,
                    Name = "Booking 2",
                    HouseId = 1,
                    State = new State() {Id = 1},
                    StateId = 1,
                }
            };
            houseId1 = new House() {Id = 1, Avaible=true};
            emptyBookings = new List<Booking>();
            mockBookingRepository = new Mock<IBookingRepository>(MockBehavior.Strict);
            mockHouseRepository = new Mock<IHouseRepository>(MockBehavior.Strict);
            mockStateRepository = new Mock<IStateRepository>(MockBehavior.Strict);
            mockHouseRepository.Setup(c => c.Find(houseId1.Id)).Returns(houseId1);
            bookingLogic = new BookingLogic(mockBookingRepository.Object,mockHouseRepository.Object,mockStateRepository.Object);
        }
        [TestMethod]
        public void TestDeleteById()
        {
            int lengthTouristPoint = bookingsToReturn.Count;
            mockBookingRepository.Setup(m => m.Delete(bookingsToReturn.First().Id));

            bookingLogic.Delete(bookingsToReturn.First().Id);

            mockBookingRepository.VerifyAll();
        }

        [TestMethod]
        public void TestDelete()
        {
            int lengthRegions = bookingsToReturn.Count;
            mockBookingRepository.Setup(m => m.GetElements()).Returns(bookingsToReturn);
            foreach (Booking t in bookingsToReturn)
            {
                mockBookingRepository.Setup(m => m.Delete(t.Id));
            }

            bookingLogic.Delete();

            mockBookingRepository.VerifyAll();
        }
        [TestMethod]
        public void TestDeleteEmpty()
        {
            mockBookingRepository.Setup(m => m.GetElements()).Returns(emptyBookings);

            bookingLogic.Delete();

            mockBookingRepository.VerifyAll();
        }
        [TestMethod]
        public void GetAll()
        {
            mockBookingRepository.Setup(m => m.GetElements()).Returns(bookingsToReturn);

            var result = bookingLogic.GetAll();

            Assert.IsTrue(result.SequenceEqual(bookingsToReturn));
        }
        [TestMethod]
        public void GetByTestOk()
        {
            Booking booking = bookingsToReturn.First();
            mockBookingRepository.Setup(m => m.Find(booking.Id)).Returns(booking);

            var result = bookingLogic.GetBy(booking.Id);

            Assert.AreEqual(result,booking);
        }
        [TestMethod]
        public void TestGetByFail()
        {
            Booking booking = bookingsToReturn.First();
            Booking empty = null;
            mockBookingRepository.Setup(m => m.Find(booking.Id)).Returns(empty);

            var result = bookingLogic.GetBy(booking.Id);

            Assert.IsNull(result);
        }
        [TestMethod]
        public void TestAddOk()
        {
            BookingModel bookingModel = new BookingModel()
            {
                Name = "nombre",
                HouseId = 1,
                StateId = 1
            };
            Booking booking = bookingModel.ToEntity();
            mockBookingRepository.Setup(m => m.Add(booking)).Returns(booking);
            mockHouseRepository.Setup(m => m.ExistElement(booking.HouseId)).Returns(true);
            mockStateRepository.Setup(m => m.ExistElement(booking.StateId)).Returns(true);
            mockStateRepository.Setup(m => m.Find(booking.StateId)).Returns(booking.State);

            Booking result = bookingLogic.Add(booking);

            Assert.AreEqual(booking, result);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddNullHouseId()
        {
            BookingModel bookingModel = new BookingModel()
            {
                Name = "nombre",
                HouseId = 10
            };
            Booking booking = bookingModel.ToEntity();
            mockHouseRepository.Setup(m => m.ExistElement(booking.HouseId)).Returns(false);

            var result = bookingLogic.Add(booking);

            mockBookingRepository.VerifyAll();
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
            mockBookingRepository.Setup(m => m.Update(booking.Id,booking));
            mockBookingRepository.Setup(m => m.Find(booking.Id)).Returns(booking);
            mockHouseRepository.Setup(m => m.ExistElement(booking.HouseId)).Returns(true);
            mockStateRepository.Setup(m => m.ExistElement(booking.StateId)).Returns(true);
            mockStateRepository.Setup(m => m.Find(booking.StateId)).Returns(booking.State);
            mockHouseRepository.Setup(m => m.Find(booking.HouseId)).Returns(houseId1);

            Booking result = bookingLogic.Update(id, booking);

            Assert.AreEqual(result, booking);
        }
        [TestMethod]
        public void TestUpdateOkNoHouseId ()
        {
            BookingModel bookingModel = new BookingModel()
            {
                Name = "new name",
                HouseId = 0,
                StateId = 1,
            };
            Booking booking = bookingModel.ToEntity();
            int id  = booking.Id;
            mockBookingRepository.Setup(m => m.Update(booking.Id,booking));
            mockBookingRepository.Setup(m => m.Find(booking.Id)).Returns(booking);
            mockHouseRepository.Setup(m => m.ExistElement(booking.HouseId)).Returns(true);
            mockStateRepository.Setup(m => m.ExistElement(booking.StateId)).Returns(true);
            mockStateRepository.Setup(m => m.Find(booking.StateId)).Returns(booking.State);
            mockHouseRepository.Setup(m => m.Find(booking.HouseId)).Returns(houseId1);

            Booking result = bookingLogic.Update(id, booking);

            Assert.AreEqual(result, booking);
        }
        [TestMethod]
        public void TestUpdateOkStateId ()
        {
            BookingModel bookingModel = new BookingModel()
            {
                Name = "new name",
                HouseId = 1,
                StateId = 0,
            };
            Booking booking = bookingModel.ToEntity();
            int id  = booking.Id;
            mockBookingRepository.Setup(m => m.Update(booking.Id,booking));
            mockBookingRepository.Setup(m => m.Find(booking.Id)).Returns(booking);
            mockHouseRepository.Setup(m => m.ExistElement(booking.HouseId)).Returns(true);
            mockStateRepository.Setup(m => m.ExistElement(booking.StateId)).Returns(true);
            mockStateRepository.Setup(m => m.Find(booking.StateId)).Returns(booking.State);
            mockHouseRepository.Setup(m => m.Find(booking.HouseId)).Returns(houseId1);

            Booking result = bookingLogic.Update(id, booking);

            Assert.AreEqual(result, booking);
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
            mockHouseRepository.Setup(m => m.ExistElement(booking.HouseId)).Returns(false);

            bookingLogic.Update(booking.Id,booking);

            mockBookingRepository.VerifyAll();
        }
        [TestMethod]
        public void TestExistOk()
        {
            Booking booking = bookingsToReturn.First();
            mockBookingRepository.Setup(m => m.ExistElement(booking)).Returns(true);

            var result = bookingLogic.Exist(booking);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestNotExistOk()
        {
            Booking booking = bookingsToReturn.First();
            mockBookingRepository.Setup(m => m.ExistElement(booking)).Returns(false);

            var result = bookingLogic.Exist(booking);

            Assert.IsFalse(result);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestValidateState()
        {
            Booking booking = bookingsToReturn.First();
            ArgumentException exception = new ArgumentException();
            mockStateRepository.Setup(m => m.ExistElement(booking.StateId)).Returns(false);
            mockHouseRepository.Setup(m => m.ExistElement(booking.HouseId)).Returns(true);

            var result = bookingLogic.Update(booking.Id,booking);
        }
        [TestMethod]
        public void TestValidateStateOk()
        {
            Booking booking = bookingsToReturn.First();
            mockHouseRepository.Setup(m => m.ExistElement(booking.HouseId)).Returns(true);
            mockHouseRepository.Setup(m => m.Find(booking.HouseId)).Returns(houseId1);
            mockStateRepository.Setup(m => m.Find(booking.StateId)).Returns(booking.State);
            mockStateRepository.Setup(m => m.ExistElement(booking.StateId)).Returns(true);
            mockBookingRepository.Setup(m => m.Update(booking.Id,booking));
            mockBookingRepository.Setup(m => m.Find(booking.Id)).Returns(booking);

            var result = bookingLogic.Update(booking.Id, booking);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestValidateHouseNotAvailable ()
        {
            BookingModel bookingModel = new BookingModel()
            {
                Name = "new name",
                HouseId = 1,
                StateId = 1,
            };
            Booking booking = bookingModel.ToEntity();
            House house = new House(){Id=1 , Avaible=false};
            int id  = booking.Id;
            mockBookingRepository.Setup(m => m.Update(booking.Id,booking));
            mockBookingRepository.Setup(m => m.Find(booking.Id)).Returns(booking);
            mockHouseRepository.Setup(m => m.ExistElement(booking.HouseId)).Returns(true);
            mockHouseRepository.Setup(m => m.Find(booking.HouseId)).Returns(house);

            Booking result = bookingLogic.Update(id, booking);
        }
    }
}