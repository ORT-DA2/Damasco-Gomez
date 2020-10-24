using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
     [Route("api/reports")]
    public class ReportController : VidlyControllerBase
    {
        [HttpGet]
        public IActionResult GetHousesReportBy([FromQuery]int idTp, string dateFrom, string DateTo)
        {
            return Ok("devolver modelo hospedaje reserva");
        }
    }
}