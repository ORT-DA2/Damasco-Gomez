using System;
using BusinessLogicInterface;
using Domain;
using Microsoft.AspNetCore.Mvc;

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
            return Ok(elementTouristPoint);
        }

        [HttpGet("{id}",Name="GetTouristPoint")]
        public IActionResult GetBy([FromRoute]int id)
        {
            var elementTouristPoint = this.touristPointLogic.GetBy(id);
            return Ok(elementTouristPoint);
        }
        [HttpPost()]
        //The post should have TouristPointModel , but will leave it like this
        public IActionResult Post([FromBody]TouristPoint touristPoint)
        {
            try
            {
                var touristPointAdded = this.touristPointLogic.Add(touristPoint);
                var routePost = CreatedAtRoute("GetTouristPoint", touristPoint.Id, touristPoint);
                return routePost;
            }
            catch (AggregateException)
            {
                return BadRequest("The touristPoint was already added");
            }
            catch (ArgumentException)
            {
                return BadRequest("Error while validate ");
            }
            catch (Exception)
            {
                return BadRequest("The server had an error");
            }
        }
        [HttpPut("{id}")]
        //The put should have TouristPointModel , but will leave it like this
        public IActionResult Put([FromRoute]int id,[FromBody]TouristPoint touristPoint)
        {
            try
            {
                this.touristPointLogic.Update(id,touristPoint);
                return CreatedAtRoute("GetTouristPoint", new { Id = touristPoint.Id }, touristPoint);
            }
            catch(ArgumentException)
            {
                return BadRequest("Error while validate");
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