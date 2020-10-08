using System;
using System.Collections.Generic;
using BusinessLogicInterface;
using Domain;
using Filters;
using Microsoft.AspNetCore.Mvc;
using Model.In;

namespace WebApi.Controllers
{
    [ApiController]
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
        [ServiceFilter(typeof(AuthorizationDIFilter))]
        public IActionResult Post([FromBody]RegionModel regionModel)
        {
            try
            {
                Region region = regionModel.ToEntity();
                region = this.regionLogic.Add(region);
                var creationRoute = CreatedAtRoute("GetRegion", new {Id = region.Id} , region);
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
        [ServiceFilter(typeof(AuthorizationDIFilter))]
        public IActionResult Put([FromRoute]int id,[FromBody]RegionModel regionModel)
        {
            try
            {
                Region region = regionModel.ToEntity();
                region = this.regionLogic.Update(id,region);
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
        [ServiceFilter(typeof(AuthorizationDIFilter))]
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
        [ServiceFilter(typeof(AuthorizationDIFilter))]
        public IActionResult Delete()
        {
            this.regionLogic.Delete();
            return Ok();
        }
    }
}
