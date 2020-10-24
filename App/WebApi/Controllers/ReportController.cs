using System.Collections.Generic;
using Domain.Entities;
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
            IEnumerable <Report> reportsToReturn;
            return Ok("reportsToReturn");
        }
    }
}