using DataAccessInterface.Repositories;
using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class ReportRepository : IReportRepository 
    {
        public readonly DbSet<Booking> dbSet;
        public readonly DbContext context;
        public ReportRepository(DbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<Booking>();

        }
        
    }
}