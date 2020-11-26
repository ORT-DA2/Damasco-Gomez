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

        public List<Report> FilterCantBookigsByHouse(DateTime dateFrom, DateTime dateOut, int idTp)
        {
            List<Report> housesAndCantBookings = houses
            .Where(h => h.TouristPointId == idTp).OrderBy(h => h.CreatedOn)
                .Select
                (
                    h => new Report()
                    {
                        NameHouse = h.Name,
                        CantBookings = h.Bookings
                        .Where(b =>
                            (b.StateId != 4) &&
                            (b.StateId != 5) &&
                            (
                                (b.CheckIn <= dateFrom && b.CheckOut > dateFrom) ||
                                (b.CheckOut >= dateOut && b.CheckIn < dateOut) ||
                                (b.CheckIn >= dateFrom && b.CheckOut <= dateOut)
                            )
                        ).Count()
                    }
                ).Where(r => r.CantBookings > 0).ToList();
            List<Report> reportToReturn = housesAndCantBookings.OrderByDescending(r => r.CantBookings).ToList();
            return reportToReturn;
        }
    }
}