using System;
using System.Linq;
using BusinessLogicInterface;
using Domain;
using Filters;
using Microsoft.AspNetCore.Mvc;
using Model.In;
using Model.Out;

namespace WebApi.Controllers
{   [ApiController]
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
            var model = elementTouristPoint.Select(m => new TouristPointDetailInfoModel(m)).ToList();
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
         [ServiceFilter(typeof(AuthorizationDIFilter))]
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
         [ServiceFilter(typeof(AuthorizationDIFilter))]
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
        [ServiceFilter(typeof(AuthorizationDIFilter))]
        public IActionResult Delete([FromRoute]int id)
        {
            if (this.touristPointLogic.GetBy(id) == null)
            {
                return NotFound();
            }
            this.touristPointLogic.Delete(id);
            return Ok();
        }
        [HttpDelete()]
        [ServiceFilter(typeof(AuthorizationDIFilter))]
        public IActionResult Delete()
        {
            this.touristPointLogic.Delete();
            return Ok();
        }
    }
}