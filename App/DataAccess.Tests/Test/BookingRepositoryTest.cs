using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Context;
using DataAccess.Repositories;
using DataAccess.Tests.Utils;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DataAccess.Tests.Test
{
    [TestClass]
    public class BookingRepositoryTest
    {
        private List<Booking> bookingsToReturn;
        private RepositoryMaster repositoryMaster;
        private DbContext context;
        private DbContextOptions options;
        private BookingRepository repository;
        [TestInitialize]
        public void Setup()
        {
            this.options = new DbContextOptionsBuilder<VidlyContext>().UseInMemoryDatabase(databaseName: "VidlyDBtest").Options;
            this.context = new VidlyContext(this.options);
            bookingsToReturn = new List<Booking>()
            {
                new Booking()
                {
                    Id = 1,
                    Name = "Booking 1",
                    Email = "mail1@mail.com",
                    House = new House(){Avaible=true},
                    State = "Init",
                    Price = 100,
                    CheckIn = new System.DateTime(),
                    CheckOut= new System.DateTime(),
                },
                new Booking()
                {
                    Id = 2,
                    Name = "Booking 2",
                }
            };

            bookingsToReturn.ForEach(m => this.context.Add(m));
            this.context.SaveChanges();
            repositoryMaster = new RepositoryMaster(context);
            repository = new BookingRepository(repositoryMaster);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.context.Database.EnsureDeleted();
        }
        [TestMethod]
        public void TestAdd()
        {
            Booking booking = new Booking(){Id = 123, Name="name new", House = new House(){Avaible=true}, CheckIn = DateTime.Today, CheckOut= DateTime.Today};
            BookingRepository repo = new BookingRepository(this.repositoryMaster);
            int cantRepo = this.repository.GetElements().Count();

            repo.Add(booking);

            Assert.AreEqual(repo.GetElements().Count(),cantRepo+1);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddFailValidate()
        {
            Booking booking = new Booking(){Id = 123, Name="name new", House = new House(), CheckIn = DateTime.Today, CheckOut= DateTime.Today};

            repository.Add(booking);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddFailValidate2()
        {
            Booking booking = new Booking(){Id = 123, Name="name new", House = new House(){Avaible=true}, CheckIn = DateTime.Today};

            repository.Add(booking);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddFailValidate3()
        {
            Booking booking = new Booking(){Id = 123, Name="name new", House = new House(){Avaible=true}, CheckOut= DateTime.Today};

            repository.Add(booking);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddFailExist()
        {
            Booking booking = bookingsToReturn.First();
            ArgumentException exception = new ArgumentException();

            repository.Add(booking);
        }
        [TestMethod]
        public void TestGetAllBookingsOk()
        {
            var result = repository.GetElements();

            Assert.IsTrue(bookingsToReturn.SequenceEqual(result));
        }
        [TestMethod]
        public void TestExistElement()
        {
            Booking booking = bookingsToReturn.First();

            bool result = repository.ExistElement(booking);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestExistElementFail()
        {
            Booking booking = new Booking(){Id = 223 , Name="name"};

            bool result = repository.ExistElement(booking);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestExistWithIdFail()
        {
            int bookingId = 234234234;

            bool result = repository.ExistElement(bookingId);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestExistById()
        {
            Booking booking = bookingsToReturn.First();

            bool result = repository.ExistElement(booking.Id);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestExistByIdFail()
        {
            Booking booking = new Booking(){Id=123423};

            bool result = repository.ExistElement(booking.Id);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestFind()
        {
            Booking booking = bookingsToReturn.First();

            Booking result = repository.Find(booking.Id);

            Assert.AreEqual(result,booking);
        }

        [TestMethod]
        public void TestFindFail()
        {
            Booking booking = new Booking(){Id=232323};

            Booking result = repository.Find(booking.Id);

            Assert.IsNull(result);
        }
        [TestMethod]
        public void TestUpdate()
        {
            // Booking booking = bookingsToReturn.First();
            // booking.Name = "New name of booking";
            // string newName = booking.Name;

            // repository.Update(booking);

            // Assert.AreEqual(booking.Name,newName);
        }
        [TestMethod]
        //[ExpectedException(typeof(ArgumentException))]
        public void TestUpdateFail()
        {
            // Booking booking = new Booking(){Id = 13000};
            // string newName = booking.Name;

            //repository.Update(booking);
        }
        [TestMethod]
        public void TestDelete()
        {
            Booking booking = bookingsToReturn.First();
            int repoCount = this.repository.GetElements().Count();

            repository.Delete(booking);

            Assert.AreEqual(repoCount - 1 , repository.GetElements().Count());
        }
        [TestMethod]
        public void TestDeleteFailExist()
        {
            Booking booking = bookingsToReturn.First();
            int lengthBookings = bookingsToReturn.Count();

            repository.Delete(booking);
        }
        [TestMethod]
        public void TestDeleteById()
        {
            Booking booking = bookingsToReturn.First();
            int repoCount = this.repository.GetElements().Count();

            repository.Delete(booking.Id);

            Assert.AreEqual(repoCount - 1 , repository.GetElements().Count());
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestDeleteByIdFailExist()
        {
            int id = 23123123;

            repository.Delete(id);
        }
    }
}