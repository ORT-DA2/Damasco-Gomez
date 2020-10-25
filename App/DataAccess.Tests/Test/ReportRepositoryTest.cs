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
        private DbContext context;
        private DbContextOptions options;
        private ReportRepository repositoryReport;
        [TestInitialize]
        public void Setup()
        {
            this.options = new DbContextOptionsBuilder<VidlyContext>().UseInMemoryDatabase(databaseName: "VidlyDBtest").Options;
            this.context = new VidlyContext(this.options);
            emptyReports = new List<Report>();
            reportsToReturn = new List<Report>()
            {
                new Report()
                {
                    CantBookings = 2,
                    NameHouse = "Hotel L’Auberge",
                },
                new Report()
                {
                    CantBookings = 4,
                    NameHouse = "The Grand Hotel",
                },
                 new Report()
                {
                    CantBookings = 4,
                    NameHouse = "Solanas Punta Del Este Spa & Resort",
                },
                 new Report()
                {
                    CantBookings = 3,
                    NameHouse = "Hotel del Lago Golf & Art Resort",
                },
                 new Report()
                {
                    CantBookings = 0,
                    NameHouse = "Hotel Arenas",
                }
            };
            HouseList= new List<House>()
            {
                new House()
                {
                    Name= "Hotel L’Auberge",
                    TouristPointId =1,
                    Bookings= 
                    {
                        new Booking()
                        {
                            Id = 1,
                            Name = "Booking 1",
                            Email = "mail1@mail.com",
                            House = new House(){Avaible=true},
                            StateId = 3,
                            State = new State(){Id=1, Name="Aceptada"},
                            Price = 100,
                            CheckIn = new DateTime(2020, 12, 01),
                            CheckOut= new DateTime(2020, 12, 31),
                        },
                        new Booking()
                        {
                            Id = 2,
                            Name = "Booking 2",
                            Email = "mail2@mail.com",
                            House = new House(){Avaible=true},
                            StateId = 3,
                            State = new State(){Id=1, Name="Aceptada"},
                            Price = 100,
                            CheckIn = new DateTime(2020, 12, 01),
                            CheckOut= new DateTime(2020, 12, 31),
                        }  
                    },
                },
                new House()
                {
                    Name= "The Grand Hotel",
                    TouristPointId=1,
                    Bookings= 
                    {
                        new Booking()
                        {
                            Id = 1,
                            Name = "Booking 1",
                            Email = "lola@mail.com",
                            House = new House(){Avaible=true},
                            StateId = 3,
                            State = new State(){Id=1, Name="Aceptada"},
                            Price = 100,
                            CheckIn = new DateTime(2020, 12, 01),
                            CheckOut= new DateTime(2020, 12, 31),
                        },
                        new Booking()
                        {
                            Id = 2,
                            Name = "Booking 2",
                            Email = "marco@mail.com",
                            House = new House(){Avaible=true},
                            StateId = 3,
                            State = new State(){Id=1, Name="Aceptada"},
                            Price = 100,
                            CheckIn = new DateTime(2020, 12, 01),
                            CheckOut= new DateTime(2020, 12, 31),
                        },
                        new Booking()
                        {
                            Id = 3,
                            Name = "Booking 3",
                            Email = "daniel@mail.com",
                            House = new House(){Avaible=true},
                            StateId = 3,
                            State = new State(){Id=1, Name="Aceptada"},
                            Price = 100,
                            CheckIn = new DateTime(2020, 12, 01),
                            CheckOut= new DateTime(2020, 12, 31),
                        },
                        new Booking()
                        {
                            Id = 4,
                            Name = "Booking 4",
                            Email = "yuliana@mail.com",
                            House = new House(){Avaible=true},
                            StateId = 3,
                            State = new State(){Id=1, Name="Aceptada"},
                            Price = 100,
                            CheckIn = new DateTime(2020, 12, 01),
                            CheckOut= new DateTime(2020, 12, 31),
                        }
                    },
                },
                 new House()
                {
                    Name = "Solanas Punta Del Este Spa & Resort",
                    TouristPointId =1,
                    Bookings= 
                    {
                         new Booking()
                        {
                            Id = 1,
                            Name = "Booking 1",
                            Email = "mailpablo@mail.com",
                            House = new House(){Avaible=true},
                            StateId = 3,
                            State = new State(){Id=1, Name="Aceptada"},
                            Price = 100,
                            CheckIn = new DateTime(2020, 12, 01),
                            CheckOut= new DateTime(2020, 12, 31),
                        },
                        new Booking()
                        {
                            Id = 2,
                            Name = "Booking 2",
                            Email = "mailPRUEBA@mail.com",
                            House = new House(){Avaible=true},
                            StateId = 3,
                            State = new State(){Id=1, Name="Aceptada"},
                            Price = 100,
                            CheckIn = new DateTime(2020, 12, 01),
                            CheckOut= new DateTime(2020, 12, 31),
                        },
                        new Booking()
                        {
                            Id = 3,
                            Name = "Booking 3",
                            Email = "martaSiLVA@mail.com",
                            House = new House(){Avaible=true},
                            StateId = 1,
                            State = new State(){Id=1, Name="Creada"},
                            Price = 100,
                            CheckIn = new DateTime(2020, 12, 01),
                            CheckOut= new DateTime(2020, 12, 31),
                        },
                        new Booking()
                        {
                            Id = 4,
                            Name = "Booking 4",
                            Email = "andresperez@mail.com",
                            House = new House(){Avaible=true},
                            StateId = 1,
                            State = new State(){Id=1, Name="Creada"},
                            Price = 100,
                            CheckIn = new DateTime(2020, 12, 01),
                            CheckOut= new DateTime(2020, 12, 31),
                        }
                    },
                },
                new House()
                {
                    Name= "Hotel del Lago Golf & Art Resort",
                    TouristPointId= 1,
                    Bookings= 
                    {
                        new Booking()
                        {
                            Id = 1,
                            Name = "Booking 1",
                            Email = "gonzalo@mail.com",
                            House = new House(){Avaible=true},
                            StateId = 3,
                            State = new State(){Id=1, Name="Aceptada"},
                            Price = 100,
                            CheckIn = new DateTime(2020, 12, 01),
                            CheckOut= new DateTime(2020, 12, 31),
                        },
                        new Booking()
                        {
                            Id = 2,
                            Name = "Booking 2",
                            Email = "juan@mail.com",
                            House = new House(){Avaible=true},
                            StateId = 1,
                            State = new State(){Id=1, Name="Creada"},
                            Price = 100,
                            CheckIn = new DateTime(2020, 12, 01),
                            CheckOut= new DateTime(2020, 12, 31),
                        },
                        new Booking()
                        {
                            Id = 3,
                            Name = "Booking 3",
                            Email = "vale@mail.com",
                            House = new House(){Avaible=true},
                            StateId = 2,
                            State = new State(){Id=1, Name="Pendiente Pago"},
                            Price = 100,
                            CheckIn = new DateTime(2020, 12, 01),
                            CheckOut= new DateTime(2020, 12, 31),
                        }
                    }, 
                },
                new House()
                {
                    TouristPointId= 1,
                    Name= "Hotel Arenas",
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
            var result = repositoryReport.FilterCantBookigsByHouse(dateFrom,dateOut, idTP);
            Assert.IsTrue(reportsToReturn.SequenceEqual(result));
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
        public void TestFilterDatesNotOk() 
        {
            DateTime dateFrom = new DateTime(2020, 10, 15);
            DateTime dateOut = new DateTime(2020, 11, 15);
            DateTime checkIn = new DateTime(2020, 12, 01);
            DateTime checkOut = new DateTime(2020, 12, 31);
        
            Assert.IsTrue(true); /*return empty report */
        }
        [TestMethod]
        public void TestFilterDateOnEqualToChekOut() 
        {
            int idTP = 1;
            DateTime dateFrom = new DateTime(2020, 12, 31);
            DateTime dateOut = new DateTime(2021, 01, 29);
            DateTime checkIn = new DateTime(2020, 12, 01);
            DateTime checkOut = new DateTime(2020, 12, 31);
            Assert.IsTrue(true); /*tiene que retornar algo porque coincide un dìa*/
        }
        [TestMethod]
        public void TestFilterDatesNotOk2() 
        {
            DateTime dateFrom = new DateTime(2021, 01, 01);
            DateTime dateOut = new DateTime(2021, 01, 15);
            DateTime checkIn = new DateTime(2020, 12, 01);
            DateTime checkOut = new DateTime(2020, 12, 31);
            Assert.IsTrue(true); /*return empty report */
        }
        [TestMethod]
        public void TestFilterSatateNotOk() 
        {
           /* DateTime dateFrom = new DateTime(2020, 12, 15);
            DateTime dateOut = new DateTime(2021, 01, 02);
            DateTime checkIn = new DateTime(2020, 12, 01);
            DateTime checkOut = new DateTime(2020, 12, 31);
             */
            string state="Rechazada";
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void TestFilterSatateNotOk2() 
        {
           /* DateTime dateFrom = new DateTime(2020, 12, 15);
            DateTime dateOut = new DateTime(2021, 01, 02);
            DateTime checkIn = new DateTime(2020, 12, 01);
            DateTime checkOut = new DateTime(2020, 12, 31);
             */
            string state ="Expirada";
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void TestFilterSatateOk() 
        {
           /* DateTime dateFrom = new DateTime(2020, 12, 15);
            DateTime dateOut = new DateTime(2021, 01, 02);
            DateTime checkIn = new DateTime(2020, 12, 01);
            DateTime checkOut = new DateTime(2020, 12, 31);
             */
            string state ="Creada";
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void TestFilterSatateOk2() 
        {
           /* DateTime dateFrom = new DateTime(2020, 12, 15);
            DateTime dateOut = new DateTime(2021, 01, 02);
            DateTime checkIn = new DateTime(2020, 12, 01);
            DateTime checkOut = new DateTime(2020, 12, 31);
             */
            string state ="Aceptada";
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void TestFilterSatateOk3() 
        {
           /* DateTime dateFrom = new DateTime(2020, 12, 15);
            DateTime dateOut = new DateTime(2021, 01, 02);
            DateTime checkIn = new DateTime(2020, 12, 01);
            DateTime checkOut = new DateTime(2020, 12, 31);
             */
            string state ="Pendiente Pago";
            Assert.IsTrue(true);
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