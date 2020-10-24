using DataAccessInterface.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class ReportRepository : AccessData<Report> /*, IReportRepository*/
    {
        public readonly DbSet<Report> dbSet;
        public readonly DbContext context;
        public ReportRepository()
        {
        }
        protected override void Update(Report elementToUpdate, Report element)
        {
        }
        protected override void Validate(Report element)
        {
        }
    }
}