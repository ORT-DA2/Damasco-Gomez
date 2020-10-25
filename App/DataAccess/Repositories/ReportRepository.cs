using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessInterface.Repositories;
using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class ReportRepository : IReportRepository 
    {
        private readonly DbSet<House> houses;
        private readonly DbContext context;
        public ReportRepository(DbContext context)
        {
            this.context = context;
            this.houses = context.Set<House>();

        }

        public List<Report> FilterCantBookigsByHouse (DateTime dateFrom, DateTime dateOut,int  idTp)
        {
            List <Report> housesAndCantBookings   = houses
            .Where(h => h.TouristPointId == idTp).OrderByDescending(h=>h.CreatedOn)
                .Select(
                    h => new Report(){ 
                        NameHouse = h.Name, 
                        CantBookings = h.Booking
                        .Where(b => 
                            b.State.Name!="Rechazada" && 
                            b.State.Name!="Expirada" && 
                            ((b.CheckIn <= dateFrom && b.CheckOut>=dateOut)|| (b.CheckIn > dateFrom && b.CheckOut>=dateOut) || (b.CheckIn <=dateFrom && b.CheckOut< dateOut) ))
                            .Count()}).ToList();
           
            return housesAndCantBookings;
        }
    }
}