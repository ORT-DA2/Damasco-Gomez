using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Context;
using DataAccess.Repositories;
using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataAccess.Tests.Test
{
    [TestClass]
    public class ReportRepositoryTest
    {
        private List<Report> reportsToReturn;
        private List<House> HouseList;
        private  List<Report>  emptyReports;
        private  List<Report>  reportsToReturn2 ;
        private  List<Report> reportsToReturn3;
        private DbContext context;
        private DbContextOptions options;
        private ReportRepository repositoryReport;
        private State stateId1 ;
        private State stateId2;
        private State stateId3 ;
        private State stateId4 ;
        private State stateId5 ;
        private Booking booking1;
        private Booking booking2;
        private Booking booking3;
        private Booking booking5;
        private Booking booking6;

        [TestInitialize]
        public void Setup()
        {
            this.options = new DbContextOptionsBuilder<VidlyContext>().UseInMemoryDatabase(databaseName: "VidlyDBtest").Options;
            this.context = new VidlyContext(this.options);
            emptyReports = new List<Report>();
            stateId1 = new State(){Id=1, Name="Creada"};
            stateId2 = new State(){Id=2, Name="Pendiente Pago"};
            stateId3 = new State(){Id=3, Name="Aceptada"};
            stateId4 = new State(){Id=4, Name="Rechazada"};
            stateId5 = new State(){Id=5, Name="Expirada"};
            booking6 = new Booking()
                        {
                            Id = 6,
                            HouseId = 2,
                            Name = "Booking 6",
                            Email = "lopezzmariano@mail.com",
                            House = new House(){Avaible=true},
                            StateId = 5,
                            State = stateId5,
                            Price = 100,
                            CheckIn = new DateTime(2020, 12, 02),
                            CheckOut= new DateTime(2020, 12, 30),
                        };
            booking5 = new Booking()
                        {
                            HouseId = 1,
                            Id = 5,
                            Name = "Booking 5",
                            Email = "lolitalatorre@mail.com",
                            House = new House(){Avaible=true},
                            StateId = 4,
                            State = stateId4,
                            Price = 100,
                            CheckIn = new DateTime(2020, 11, 30),
                            CheckOut= new DateTime(2020, 12, 31),
                        };
            booking1 =  new Booking()
                        {
                            Id = 1,
                            HouseId = 1,
                            Name = "Booking 1",
                            Email = "mail1@mail.com",
                            House = new House(){Avaible=true},
                            StateId = 3,
                            State = stateId3,
                            Price = 100,
                            CheckIn = new DateTime(2020, 12, 05),
                            CheckOut= new DateTime(2020, 12, 31),
                        };
            booking2 =  new Booking()
                        {
                            Id = 2,
                            HouseId = 1,
                            Name = "Booking 2",
                            Email = "mail2@mail.com",
                            House = new House(){Avaible=true},
                            StateId = 3,
                            State = stateId3,
                            Price = 100,
                            CheckIn = new DateTime(2020, 12, 01),
                            CheckOut= new DateTime(2020, 12, 31),
                        };
            booking3 = new Booking()
                        {
                            Id = 3,
                            HouseId = 2,
                            Name = "Booking 3",
                            Email = "daniel@mail.com",
                            House = new House(){Avaible=true},
                            StateId = 3,
                            State = stateId3,
                            Price = 100,
                            CheckIn = new DateTime(2020, 12, 01),
                            CheckOut= new DateTime(2020, 12, 28),
                        };
            reportsToReturn = new List<Report>()
            {
                new Report()
                {
                    CantBookings = 2,
                    NameHouse = "Hotel L’Auberge",
                },
                new Report()
                {
                    CantBookings = 1,
                    NameHouse = "The Grand Hotel",
                },
            };
            HouseList= new List<House>()
            {
                new House()
                {
                    Id= 1,
                    Name= "Hotel L’Auberge",
                    TouristPointId =1,
                    Bookings= new List<Booking>()
                    { 
                        booking1 , booking2, booking5
                    },
                },
                new House()
                {
                    Id= 2,
                    Name= "The Grand Hotel",
                    TouristPointId=1,
                    Bookings= new List<Booking>()
                    {
                      booking6, booking3
                    },
                }, 
            };

            HouseList.ForEach(m => this.context.Add(m));
            this.context.SaveChanges();
            repositoryReport = new ReportRepository(context);
        }
        [TestCleanup]
        public void TestCleanup()
        {
            this.context.Database.EnsureDeleted();
        }
        [TestMethod]
        public void TestFilterDatesInTheMiddleOk()
        {
            int idTP = 1;
            DateTime dateFrom = new DateTime(2020, 12, 03);
            DateTime dateOut = new DateTime(2020, 12, 20);

            var result = repositoryReport.FilterCantBookigsByHouse(dateFrom,dateOut, idTP);

            Assert.IsTrue(reportsToReturn.SequenceEqual(result));
        }
        [TestMethod]
        public void TestFilterDatesLeftEdgeCaseDatesOk() 
        {
            int idTP = 1;
            DateTime dateFrom = new DateTime(2020, 11, 29);
            DateTime dateOut = new DateTime(2020, 12, 20);

            var result = repositoryReport.FilterCantBookigsByHouse(dateFrom,dateOut, idTP);

            Assert.IsTrue(reportsToReturn.SequenceEqual(result));
        }
        [TestMethod]
        public void TestFilterDateOffEqualToChekIn() 
        {
            int idTP = 1;
            DateTime dateFrom = new DateTime(2020, 10, 14);
            DateTime dateOut = new DateTime(2020, 12, 01);
             reportsToReturn3 = new List<Report>()
            {
                new Report()
                {
                    CantBookings = 1,
                    NameHouse = "Hotel L’Auberge",
                },
                new Report()
                {
                    CantBookings = 1,
                    NameHouse = "The Grand Hotel",
                },
            };
            var result = repositoryReport.FilterCantBookigsByHouse(dateFrom,dateOut, idTP);

            Assert.IsTrue(reportsToReturn3.SequenceEqual(result));
        }
        [TestMethod]
        public void TestFilterDatesRightEdgeCaseDatesOk() 
        {
            int idTP = 1;
            DateTime dateFrom = new DateTime(2020, 12, 15);
            DateTime dateOut = new DateTime(2021, 01, 10);

            var result = repositoryReport.FilterCantBookigsByHouse(dateFrom,dateOut, idTP);

            Assert.IsTrue(reportsToReturn.SequenceEqual(result));
        }
        [TestMethod]
        public void TestFilterDateOnEqualToChekOut() 
        {
            int idTP = 1;
            DateTime dateFrom = new DateTime(2020, 12, 31);
            DateTime dateOut = new DateTime(2021, 01, 29);
            reportsToReturn2 = new List<Report>()
            {
                new Report()
                {
                    CantBookings = 2,
                    NameHouse = "Hotel L’Auberge",
                },
            
            };
            var result = repositoryReport.FilterCantBookigsByHouse(dateFrom,dateOut, idTP);

            Assert.IsTrue(reportsToReturn2.SequenceEqual(result));
        }
        [TestMethod]
        public void TestFilterDateOkInRango() 
        {
            int idTP = 1;
            DateTime dateFrom = new DateTime(2020, 10, 14);
            DateTime dateOut = new DateTime(2021, 01, 3);

            var result = repositoryReport.FilterCantBookigsByHouse(dateFrom,dateOut, idTP);

            Assert.IsTrue(reportsToReturn.SequenceEqual(result));
        }
        [TestMethod]
        public void TestFilterDatesNotOk2() 
        {
            int idTP = 1;
            DateTime dateFrom = new DateTime(2021, 01, 01);
            DateTime dateOut = new DateTime(2021, 01, 15);

            var result = repositoryReport.FilterCantBookigsByHouse(dateFrom,dateOut, idTP);

            Assert.IsTrue(emptyReports.SequenceEqual(result));
        }
        [TestMethod]
        public void TestFilterDatesNotOk() 
        {
            int idTP = 1;
            DateTime dateFrom = new DateTime(2020, 10, 15);
            DateTime dateOut = new DateTime(2020, 11, 15);

            var result = repositoryReport.FilterCantBookigsByHouse(dateFrom,dateOut, idTP);

            Assert.IsTrue(emptyReports.SequenceEqual(result));
        }
        [TestMethod]
        public void TestFilterSatateNotOk() 
        {
            //not count booking with state= "rechazada"
            int idTP = 1;
            DateTime dateFrom = new DateTime(2020, 12, 03);
            DateTime dateOut = new DateTime(2020, 12, 20);

            var result = repositoryReport.FilterCantBookigsByHouse(dateFrom,dateOut, idTP);

            Assert.IsTrue(reportsToReturn.SequenceEqual(result));
        }
        [TestMethod]
        public void TestFilterSatateNotOk2() 
        {
           //not count booking with state= "expirada"
            int idTP = 1;
            DateTime dateFrom = new DateTime(2020, 12, 03);
            DateTime dateOut = new DateTime(2020, 12, 20);

            var result = repositoryReport.FilterCantBookigsByHouse(dateFrom,dateOut, idTP);

            Assert.IsTrue(reportsToReturn.SequenceEqual(result));
        }
         [TestMethod]
        public void TestFilterNotMatchTouristPoint() 
        {
            int idTP = 3;
            DateTime dateFrom = new DateTime(2020, 12, 03);
            DateTime dateOut = new DateTime(2020, 12, 20);
            var result = repositoryReport.FilterCantBookigsByHouse(dateFrom,dateOut, idTP);
            Assert.IsTrue(emptyReports.SequenceEqual(result));
        }
    }
}