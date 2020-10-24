using Microsoft.AspNetCore.Mvc;
using Model.In;

namespace WebApi.Controllers
{
    [Route("api/reports")]
    public class ReportController : VidlyControllerBase
    {
        [HttpGet]
        [AuthorizationFilter]
        public IActionResult GetHousesReportBy([FromQuery]TourisPointReportModel touristPointReport)
        {
            IEnumerable<Report> varRet ;
            IEnumerable<HouseBookingReportBasicModel> basicModelHousesReport;

            if(bookingReportModel.NotNull())
            {
                bookingReportModel.CheckAllParameters();
                TourisPointReport touristPointReport = touristPointReport.ToEntity();
                varRet = this.reportLogic.GetHousesReportBy(touristPointReport);
                basicModelHousesReport = varRet.
                    Select(m => new HouseBookingReportBasicModel(m,report)).ToList();
            }
            else
            {
               
            }
            return Ok(basicModelHousesReport);
        }
    }
}