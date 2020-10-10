using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogicInterface;
using Domain;
using Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Model.In;
using Model.Out;
using WebApi.Filters;

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
            IEnumerable<Region> regions = this.regionLogic.GetAll();
            IEnumerable<RegionDetailModel> regionsBasic = regions.Select(m => new RegionDetailModel(m));
            return Ok(regionsBasic);
        }
        [HttpGet( "{id}" , Name="GetRegion" )]
        public IActionResult GetBy([FromRoute]int id)
        {
            try
            {
                var elementRegion = this.regionLogic.GetBy(id);
                RegionDetailModel regionsBasic = new RegionDetailModel(elementRegion);
                return Ok(regionsBasic);
            }
            catch (ArgumentException)
            {
                return BadRequest("There is not a booking with that id");
            }
        }
        [HttpPost()]
        [AuthorizationFilter]
        public IActionResult Post([FromBody]RegionModel regionModel)
        {
            try
            {
                Region region = regionModel.ToEntity();
                region = this.regionLogic.Add(region);
                RegionDetailModel regionsBasic = new RegionDetailModel(region);
                var creationRoute = CreatedAtRoute("GetRegion", new {Id = regionsBasic.Id} , regionsBasic);
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
        [AuthorizationFilter]
        public IActionResult Put([FromRoute]int id,[FromBody]RegionModel regionModel)
        {
            try
            {
                Region region = regionModel.ToEntity();
                region = this.regionLogic.Update(id,region);
                RegionDetailModel regionsBasic = new RegionDetailModel(region);
                var creationRoute = CreatedAtRoute("GetRegion", new {Id = regionsBasic.Id} , regionsBasic);
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
        [AuthorizationFilter]
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
        [AuthorizationFilter]
        public IActionResult Delete()
        {
            this.regionLogic.Delete();
            return Ok();
        }
    }
}
