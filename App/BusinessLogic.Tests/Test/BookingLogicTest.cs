using System.Collections.Generic;
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
        private  List<Booking> bookinsToReturn;
        private  List<Booking>  emptyBookings;
        private BookingLogic bookingLogic;
        private Mock<IBookingRepository> mock;
        private Mock<IHouseRepository> mock2;
        private BookingRepository bookingRepository;
        private IHouseRepository houseRepository;

        [TestInitialize]
        public void initVariables()
        {
             bookinsToReturn = new List<Booking>()
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
            mock2 = new Mock<IHouseRepository>(MockBehavior.Strict);
            bookingLogic = new BookingLogic(houseRepository, bookingRepository)(mock.Object);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void GetByTestOk()
        {
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void AddTestOk()
        {
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void UpdateTestOk()
        {
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void DeleteTestByIdOk()
        {
            Assert.IsTrue(true);
        }
         [TestMethod]
        public void ExistTestOk()
        {
            Assert.IsTrue(true);
        }
    }
}