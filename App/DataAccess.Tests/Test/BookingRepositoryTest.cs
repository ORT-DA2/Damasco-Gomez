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
        private VidlyDbSet<Booking> mockSet;
        private Mock<DbContext> mockDbContext;
        private BookingRepository repository;
        private List<Booking> emptyBooking;
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
                    House = new House(){Avaible=true},
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
            emptyBooking = new List<Booking>();
            mockSet = new VidlyDbSet<Booking>();
            mockDbContext = new Mock<DbContext>(MockBehavior.Strict);
        }
        [TestMethod]
        public void TestAdd()
        {
            Booking booking = new Booking(){Id = 123, Name="name new", House = new House(){Avaible=true}, CheckIn = DateTime.Today, CheckOut= DateTime.Today};
            mockDbContext.Setup(d => d.Set<Booking>()).Returns(mockSet.GetMockDbSet(bookingsToReturn).Object);
            mockDbContext.Setup(d => d.SaveChanges()).Returns(booking.Id);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new BookingRepository(repositoryMaster);

            var result = repository.Add(booking);

            Assert.AreEqual(booking, result);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        //This method should throw an error while validate 
        public void TestAddFailValidate()
        {
            Booking booking = new Booking(){Id = 123, Name="name new"};
            mockDbContext.Setup(d => d.Set<Booking>()).Returns(mockSet.GetMockDbSet(bookingsToReturn).Object);
            mockDbContext.Setup(d => d.SaveChanges()).Returns(booking.Id);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new BookingRepository(repositoryMaster);

            repository.Add(booking);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddFailExist()
        {
            Booking booking = bookingsToReturn.First();
            ArgumentException exception = new ArgumentException();
            var _mockSet = mockSet.GetMockDbSet(bookingsToReturn);
            _mockSet.Setup(d => d.Find(It.IsAny<Booking>())).Throws(exception);
            mockDbContext.Setup(d => d.Set<Booking>()).Returns(_mockSet.Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new BookingRepository(repositoryMaster);

            repository.Add(booking);
        }
        [TestMethod]
        public void TestGetAllBookingsOk()
        {
            mockDbContext.Setup(d => d.Set<Booking>()).Returns(mockSet.GetMockDbSet(bookingsToReturn).Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new BookingRepository(repositoryMaster);

            var result = repository.GetElements();

            Assert.IsTrue(bookingsToReturn.SequenceEqual(result));
        }
        [TestMethod]
        public void TestGetAllBookingsNull()
        {
            List<Booking> emptyBooking = new List<Booking>();
            mockDbContext.Setup(d => d.Set<Booking>()).Returns(mockSet.GetMockDbSet(emptyBooking).Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new BookingRepository(repositoryMaster);

            var result = repository.GetElements();

            Assert.IsTrue(emptyBooking.SequenceEqual(result));
        }
        [TestMethod]
        public void TestExistElement()
        {
            Booking booking = bookingsToReturn.First();
            mockDbContext.Setup(d => d.Set<Booking>()).Returns(mockSet.GetMockDbSet(bookingsToReturn).Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new BookingRepository(repositoryMaster);

            bool result = repository.ExistElement(booking);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestExistElementFail()
        {
            Booking booking = bookingsToReturn.First();
            mockDbContext.Setup(d => d.Set<Booking>()).Returns(mockSet.GetMockDbSet(emptyBooking).Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new BookingRepository(repositoryMaster);

            bool result = repository.ExistElement(booking);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestExistWithIdFail()
        {
            int bookingId = bookingsToReturn.First().Id;
            mockDbContext.Setup(d => d.Set<Booking>()).Returns(mockSet.GetMockDbSet(bookingsToReturn).Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new BookingRepository(repositoryMaster);

            bool result = repository.ExistElement(bookingId);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestExistById()
        {
            Booking booking = bookingsToReturn.First();
            var _mockSet = mockSet.GetMockDbSet(bookingsToReturn);
            _mockSet.Setup(d => d.Find(It.IsAny<object[]>())).Returns(booking);
            mockDbContext.Setup(d => d.Set<Booking>()).Returns(_mockSet.Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new BookingRepository(repositoryMaster);

            bool result = repository.ExistElement(booking.Id);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestExistByIdFail()
        {
            Booking booking = new Booking(){Id=123423};
            mockDbContext.Setup(d => d.Set<Booking>()).Returns(mockSet.GetMockDbSet(bookingsToReturn).Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new BookingRepository(repositoryMaster);

            bool result = repository.ExistElement(booking.Id);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestFind()
        {
            Booking booking = bookingsToReturn.First();
            var _mockSet = mockSet.GetMockDbSet(bookingsToReturn);
            _mockSet.Setup(d => d.Find(It.IsAny<object[]>())).Returns(booking);
            mockDbContext.Setup(d => d.Set<Booking>()).Returns(_mockSet.Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new BookingRepository(repositoryMaster);

            Booking result = repository.Find(booking.Id);

            Assert.AreEqual(result,booking);
        }

        [TestMethod]
        public void TestFindFail()
        {
            Booking booking = new Booking(){Id=232323};
            Booking bookingNull = null;
            var _mockSet = mockSet.GetMockDbSet(bookingsToReturn);
            ArgumentException exception = new ArgumentException();
            _mockSet.Setup(d => d.Find(It.IsAny<object[]>())).Returns(bookingNull);
            mockDbContext.Setup(d => d.Set<Booking>()).Returns(_mockSet.Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new BookingRepository(repositoryMaster);

            Booking result = repository.Find(booking.Id);

            Assert.IsNull(result);
        }
        [TestMethod]
        public void TestUpdate()
        {
            Booking booking = bookingsToReturn.First();
            booking.CheckIn = DateTime.Today;
            booking.CheckOut = DateTime.Today;
            booking.Name = "New name of booking";
            string newName = booking.Name;
            mockDbContext.Setup(d => d.Set<Booking>()).Returns(mockSet.GetMockDbSet(bookingsToReturn).Object);
            mockDbContext.Setup(d => d.SaveChanges()).Returns(booking.Id);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new BookingRepository(repositoryMaster);

            repository.Update(booking);

            Assert.AreEqual(booking.Name,newName);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestUpdateFail()
        {
            Booking booking = new Booking(){Id = 13000};
            string newName = booking.Name;
            // Exception exception = new ArgumentException();
            mockDbContext.Setup(d => d.Set<Booking>()).Returns(mockSet.GetMockDbSet(bookingsToReturn).Object);
            mockDbContext.Setup(d => d.SaveChanges()).Returns(bookingsToReturn.First().Id);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new BookingRepository(repositoryMaster);

            repository.Update(booking);

            // Assert.IsInstanceOfType(result, typeof(Exception));
        }
        [TestMethod]
        public void TestDelete()
        {
            Booking booking = bookingsToReturn.First();
            mockDbContext.Setup(d => d.Set<Booking>()).Returns(mockSet.GetMockDbSet(bookingsToReturn).Object);
            mockDbContext.Setup(d => d.SaveChanges()).Returns(booking.Id);
            mockDbContext.Setup(d => d.Remove(booking));
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new BookingRepository(repositoryMaster);

            repository.Delete(booking);
            
            //mockDbContext.VerifyAll();
        }
        [TestMethod]
        public void TestDeleteFailExist()
        {
            Booking booking = bookingsToReturn.First();
            mockDbContext.Setup(d => d.Set<Booking>()).Returns(mockSet.GetMockDbSet(bookingsToReturn).Object);
            mockDbContext.Setup(d => d.SaveChanges()).Returns(booking.Id);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new BookingRepository(repositoryMaster);

            repository.Delete(booking);

            //mockDbContext.VerifyAll();
        }
        [TestMethod]
        public void TestDeleteById()
        {
            Booking booking = bookingsToReturn.First();
            var _mockSet = mockSet.GetMockDbSet(bookingsToReturn);
            _mockSet.Setup(d => d.Find(It.IsAny<object[]>())).Returns(booking);
            mockDbContext.Setup(d => d.Set<Booking>()).Returns(_mockSet.Object);
            mockDbContext.Setup(d => d.SaveChanges()).Returns(booking.Id);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new BookingRepository(repositoryMaster);

            repository.Delete(booking.Id);

            //mockDbContext.VerifyAll();
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestDeleteByIdFailExist()
        {
            Booking booking = bookingsToReturn.First();
            Booking bookingNull = null;
            var _mockSet = mockSet.GetMockDbSet(bookingsToReturn);
            _mockSet.Setup(d => d.Find(It.IsAny<object[]>())).Returns(bookingNull);
            mockDbContext.Setup(d => d.Set<Booking>()).Returns(_mockSet.Object);
            mockDbContext.Setup(d => d.SaveChanges()).Returns(booking.Id);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new BookingRepository(repositoryMaster);

            repository.Delete(booking.Id);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestValidateFailAvailable()
        {
            Booking booking = bookingsToReturn.Last();
            mockDbContext.Setup(d => d.Set<Booking>()).Returns(mockSet.GetMockDbSet(bookingsToReturn).Object);
            mockDbContext.Setup(d => d.SaveChanges()).Returns(booking.Id);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new BookingRepository(repositoryMaster);

            repository.Add(booking);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        //This method should throw an error while validate 
        public void TestValidateCheckDates()
        {
            Booking booking = new Booking(){House = new House(){Avaible = true}};
            mockDbContext.Setup(d => d.Set<Booking>()).Returns(mockSet.GetMockDbSet(bookingsToReturn).Object);
            mockDbContext.Setup(d => d.SaveChanges()).Returns(booking.Id);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new BookingRepository(repositoryMaster);

            repository.Add(booking);
        }
    }
}