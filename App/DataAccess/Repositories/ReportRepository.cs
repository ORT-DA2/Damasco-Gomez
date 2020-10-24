using System;
using System.Collections.Generic;
using DataAccessInterface.Repositories;
using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class ReportRepository : IReportRepository 
    {
        public readonly DbSet<House> dbSet;
        public readonly DbContext context;
        public ReportRepository(DbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<House>();

        }

        public List<Report> FilterCantBookigsByHouse (DateTime dateFrom, DateTime dateOn,int  idTp)
        {
           /* List <Report> housesAndCantBookings = Select count(*) as CantBooking , h.Name, h.Id 
                                                from Booking b, House h , State s
                                                where (h.Id= b.HouseId) and (b.CheckIn > = dateFrom) and (b.CheckOut <= dateOn) and (b.StateId <> ) and (b.StateId<> ) 
                                                and (s.Id = b.StateId) and (s.Name <> "Expirada") and s.Name <> ("Rechazada") */

            List <Report> housesAndCantBookings = new  List <Report>();
            return housesAndCantBookings;
        }
    }
}