using BusinessLogicInterface;
using BusinessLogicInterface.Interfaces;
using DataAccessInterface.Repositories;

namespace BusinessLogic.Logics
{
    public class ReportLogic : IReportLogic
    {
        private readonly IReportRepository reportRepository;
        public ReportLogic(IReportRepository reportRepository)
        {
            this.reportRepository = reportRepository;
        }
    }
}