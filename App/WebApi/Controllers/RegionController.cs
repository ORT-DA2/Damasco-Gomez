using System;
using BusinessLogicInterface;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/regions")]
    public class RegionController : VidlyControllerBase
    {
       private readonly IRegionLogic regionLogic;

        public RegionController(IRegionLogic regionLogic)
        {
            this.regionLogic = regionLogic;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.regionLogic.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult GetBy([FromQuery]int id)
        {
            var elementRegion = this.regionLogic.GetBy(id);
            return Ok(elementRegion);
        }
        [HttpPost()]
        public IActionResult Post([FromBody]Region region)
        {
            try
            {
                this.regionLogic.Add(region);
                return CreatedAtRoute("Api", region.Id, region);
            }
            catch (AggregateException)
            {
                return BadRequest("The region was already added");
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
        public IActionResult Put([FromRoute]int id,[FromBody]Region region)
        {
            try
            {
                this.regionLogic.Update(region);
                return CreatedAtRoute("Api", region.Id, region);
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
        public IActionResult Delete([FromQuery]int id)
        {
            if (this.regionLogic.GetBy(id) == null)
            {
                return NotFound();
            }
            this.regionLogic.Delete(id);
            return Ok();
        }
        [HttpDelete()]
        public IActionResult Delete()
        {
            this.regionLogic.Delete();
            return Ok();
        }
    }
}