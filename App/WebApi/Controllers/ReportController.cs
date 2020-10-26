using System.Collections.Generic;
using BusinessLogic.Logics;
using BusinessLogicInterface.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Model.In;
using WebApi.Filters;

namespace WebApi.Controllers
{
    [Route("api/reports")]
    public class ReportController : VidlyControllerBase
    {
        private IReportLogic reportLogic;
         public ReportController(IReportLogic reportLogic)
        {
            this.reportLogic = reportLogic;
        }
        [HttpGet]
        [AuthorizationFilter]
        public IActionResult GetHousesReportBy([FromQuery]int idTp, string dateFrom, string dateOn)
        {
            IEnumerable <Report> reportsToReturn;

            return Ok("reportsToReturn");
        }
    }
}