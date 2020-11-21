using System.Collections.Generic;
using System.Linq;
using BusinessLogic.Logics;
using BusinessLogicInterface.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Model.In;
using Model.Out;
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
        public IActionResult GetHousesReportBy([FromQuery]ReportTouristPointModel touristPointReportModel)
        {
            IEnumerable<Report> varRet ;
            IEnumerable<ReportHousesBasicModel> basicModelsToReturn = new List<ReportHousesBasicModel> () ;
            if(touristPointReportModel.NotNull())
            {
               touristPointReportModel.CheckAllParameters();
                ReportTouristPoint reportTouristPoint = touristPointReportModel.ToEntity();
                varRet = this.reportLogic.GetHousesReportBy(reportTouristPoint);
                basicModelsToReturn = varRet.
                    Select(m => new ReportHousesBasicModel(m)).ToList();
            }
            return Ok(basicModelsToReturn);
        }
    }
}