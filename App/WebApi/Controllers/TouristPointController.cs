using System;
using System.Linq;
using BusinessLogicInterface;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Model.In;
using Model.Out;

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
            return Ok(elementTouristPoint.Select(m=> new TouristPointDetailInfoModel(m)).ToList());
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
        public IActionResult Post([FromBody]TouristPointModel touristPoint)
        {
            try
            {
                var touristPointAdded = this.touristPointLogic.Add(touristPoint.ToEntity());
                var routePost = CreatedAtRoute("GetTouristPoint", new {Id = touristPointAdded.Id} , new TouristPointDetailInfoModel(touristPointAdded));
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
        public IActionResult Put([FromRoute]int id,[FromBody]TouristPointModel touristPoint)
        {
            try
            {
                var touristPointAdded = touristPoint.ToEntity();
                this.touristPointLogic.Update(id,touristPointAdded);
                return CreatedAtRoute("GetTouristPoint", new {id =touristPointAdded.Id} ,new TouristPointDetailInfoModel(touristPointAdded));
                
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
        public IActionResult Delete()
        {
            this.touristPointLogic.Delete();
            return Ok();
        }
    }
}