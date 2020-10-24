using Microsoft.AspNetCore.Mvc;
using Model.In;
using WebApi.Filters;

namespace WebApi.Controllers
{
    [Route("api/reports")]
    public class ReportController : VidlyControllerBase
    {
        [HttpGet]
        [AuthorizationFilter]
        public IActionResult GetHousesReportBy([FromQuery]int idTp, string dateFrom, string dateOn)
        {
            return Ok("ok");
        }
    }
}