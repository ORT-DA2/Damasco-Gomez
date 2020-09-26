using System.Collections.Generic;
using System.Linq;
using DataAccess.Context;
using DataAccess.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataAccess.Tests.Test
{
    [TestClass]
    public class BookingRepositoryTest
    {
        private List<Booking> bookingsToReturn;
        private List<Booking> bookingsToReturnEmpty;
        private RepositoryMaster masterRepository;
        private VidlyContext context;
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
                    House = null,
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
                    House = null,
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
                    House = null,
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
                    House = null,
                    State = "Init",
                    Price = 400,
                    CheckIn = new System.DateTime(),
                    CheckOut= new System.DateTime(),
                }
            };
            var options = new DbContextOptionsBuilder<VidlyContext>()
                .UseInMemoryDatabase(databaseName: "VidlyDb").Options;
            context = new VidlyContext(options);
            masterRepository = new RepositoryMaster(context);
        }
        [TestMethod]
        public void TestGetAllBookingsOk()
        {
            bookingsToReturn.ForEach(m => masterRepository.Bookings.AddInContext(m));
            List<Booking> result = this.masterRepository.Bookings.GetElementsInContext();
            Assert.IsTrue(bookingsToReturn.SequenceEqual(result));
        }
        // [TestMethod]
        // public void TestGetAllBookingsNull()
        // {
        //     List<Booking> emptyBooking = new List<Booking>();
        //     emptyBooking.ForEach(m => masterRepository.Bookings.AddInContext(m));
        //     List<Booking> result = this.masterRepository.Bookings.GetElementsInContext();
        //     Assert.IsTrue(emptyBooking.SequenceEqual(result));
        // }
    }
}