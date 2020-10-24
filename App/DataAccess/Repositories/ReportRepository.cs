using DataAccessInterface.Repositories;
using Domain.Entities;

namespace DataAccess.Repositories
{
    public class ReportRepository : AccessData<Report> /*, IReportRepository*/
    {
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