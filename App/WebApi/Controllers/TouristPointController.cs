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
        public IActionResult Get()
        {
            var elementTouristPoint = this.touristPointLogic.GetAll();
            var model = elementTouristPoint.Select(m => new TouristPointBasicInfoModel(m)).ToList();
            return Ok(model);
        }
        [HttpGet("{id}",Name="GetTouristPoint")]
        public IActionResult GetBy([FromRoute]int id)
        {
            try
            {
                var elementTouristPoint = this.touristPointLogic.GetBy(id);
                var model = new TouristPointDetailInfoModel(elementTouristPoint);
                return Ok(model);
            }
            catch (ArgumentException)
            {
                return BadRequest("There is not a tourist point with that id");
            }
        }
        [HttpPost()]
        [AuthorizationFilter]
        public IActionResult Post([FromBody]TouristPointModel touristPoint)
        {
            try
            {
                var newTouristPoint = touristPoint.ToEntity();
                var touristPointAdded = this.touristPointLogic.Add(newTouristPoint);
                var touristPointModel = new TouristPointDetailInfoModel(touristPointAdded);
                var routePost = CreatedAtRoute("GetTouristPoint", new {Id = touristPointAdded.Id} , touristPointModel);
                return routePost;
            }
            catch (ArgumentException e)
            {
                return BadRequest("Error while validate : "+ e.Message.ToString());
            }
            catch (Exception)
            {
                return BadRequest("The server had an error");
            }
        }
        [HttpPut("{id}")]
        [AuthorizationFilter]
        public IActionResult Put([FromRoute]int id,[FromBody]TouristPointModel touristPointModel)
        {
            try
            {
                TouristPoint touristPoint = touristPointModel.ToEntity();
                touristPoint = this.touristPointLogic.Update(id,touristPoint);
                return CreatedAtRoute("GetTouristPoint", new {id =touristPoint.Id} ,new TouristPointDetailInfoModel(touristPoint));
            }
            catch(ArgumentException e )
            {
                return BadRequest("Error while validate : "+ e.Message.ToString());
            }
            catch (Exception)
            {
                return BadRequest("Internal server error");
            }
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
