using System;
using System.Collections.Generic;
using BusinessLogicInterface;
using Domain;
using Filters;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/regions")]
    [ServiceFilter(typeof(AuthorizationDIFilter))]
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
        [HttpGet( "{id}" , Name="GetRegion" )]
        public IActionResult GetBy([FromRoute]int id)
        {
            try
            {
                var elementRegion = this.regionLogic.GetBy(id);
                return Ok(elementRegion);
            }
            catch (ArgumentException)
            {
                return BadRequest("There is not a booking with that id");
            }
        }
        [HttpPost()]
        public IActionResult Post([FromBody]Region region)
        {
            try
            {
                var addedRegion = this.regionLogic.Add(region);
                var creationRoute = CreatedAtRoute("GetRegion", new {Id = addedRegion.Id} , addedRegion);
                return creationRoute;
            }
            catch (AggregateException)
            {
                return BadRequest("The region was already added");
            }
            catch (ArgumentException e)
            {
                return BadRequest("Error while validate : "+ e.Message.ToString());
            }
            catch (Exception e)
            {
                return BadRequest("The server had an error : "+ e.Message.ToString());
            }
        }
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute]int id,[FromBody]Region region)
        {
            try
            {
                this.regionLogic.Update(id,region);
                var creationRoute = CreatedAtRoute("GetRegion", new {Id = region.Id} , region);
                return creationRoute;
            }
            catch(ArgumentException e)
            {
                return BadRequest("Error while validate :"+ e.Message.ToString());
            }
            catch (Exception e)
            {
                return BadRequest("Internal server error : "+ e.Message.ToString());
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute]int id)
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