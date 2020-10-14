using System;
using System.Linq;
using BusinessLogicInterface;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Model.In;
using Model.Out;
using WebApi.Filters;

namespace WebApi.Controllers
{   
    [Route("api/touristpoints")]
    public class TouristPointController : VidlyControllerBase
    {
        private readonly ITouristPointLogic touristPointLogic;
        public TouristPointController(ITouristPointLogic touristPointLogic)
        {
            this.touristPointLogic = touristPointLogic;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var elementTouristPoint = this.touristPointLogic.GetAll();
            var model = elementTouristPoint.Select(m => new TouristPointBasicInfoModel(m)).ToList();
            return Ok(model);
        }
        [HttpGet("{id}",Name="GetTouristPoint")]
        public IActionResult GetBy([FromRoute]int id)
        {
            var elementTouristPoint = this.touristPointLogic.GetBy(id);
            var model = new TouristPointDetailInfoModel(elementTouristPoint);
            return Ok(model);
        }
        [HttpPost]
        [AuthorizationFilter]
        public IActionResult Post([FromBody]TouristPointModel touristPoint)
        {
            var newTouristPoint = touristPoint.ToEntity();
            var touristPointAdded = this.touristPointLogic.Add(newTouristPoint);
            var touristPointModel = new TouristPointBasicInfoModel(touristPointAdded);
            var routePost = CreatedAtRoute("GetTouristPoint", new {Id = touristPointAdded.Id} , touristPointModel);
            return routePost;
        }
        [HttpPut("{id}")]
        [AuthorizationFilter]
        public IActionResult Put([FromRoute]int id,[FromBody]TouristPointModel touristPointModel)
        {
            TouristPoint touristPoint = touristPointModel.ToEntity();
            touristPoint = this.touristPointLogic.Update(id,touristPoint);
            TouristPointBasicInfoModel basicModel = new TouristPointBasicInfoModel(touristPoint);
            return CreatedAtRoute("GetTouristPoint", new {id =basicModel.Id} ,basicModel);
        }
        [HttpDelete("{id}")]
        [AuthorizationFilter]
        public IActionResult Delete([FromRoute]int id)
        {
            this.touristPointLogic.Delete(id);
            return Ok("Element was delete with id "+id);
        }
        [HttpDelete]
        [AuthorizationFilter]
        public IActionResult Delete()
        {
            this.touristPointLogic.Delete();
            return Ok("All data from TouristPoint was");
        }
    }
}
