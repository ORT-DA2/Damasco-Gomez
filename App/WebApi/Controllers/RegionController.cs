using System.Collections.Generic;
using System.Linq;
using BusinessLogicInterface;
using Domain;
using Microsoft.AspNetCore.Mvc;
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
            var elementRegion = this.regionLogic.GetBy(id);
            RegionDetailModel regionsBasic = new RegionDetailModel(elementRegion);
            return Ok(regionsBasic);
        }
        [HttpPost]
        [AuthorizationFilter]
        public IActionResult Post([FromBody]RegionModel regionModel)
        {
            Region region = regionModel.ToEntity();
            region = this.regionLogic.Add(region);
            RegionDetailModel regionsBasic = new RegionDetailModel(region);
            var creationRoute = CreatedAtRoute("GetRegion", new {Id = regionsBasic.Id} , regionsBasic);
            return creationRoute;
        }
        [HttpPut("{id}")]
        [AuthorizationFilter]
        public IActionResult Put([FromRoute]int id,[FromBody]RegionModel regionModel)
        {
            Region region = regionModel.ToEntity();
            region = this.regionLogic.Update(id,region);
            RegionDetailModel regionsBasic = new RegionDetailModel(region);
            var creationRoute = CreatedAtRoute("GetRegion", new {Id = regionsBasic.Id} , regionsBasic);
            return creationRoute;
        }
        [HttpDelete("{id}")]
        [AuthorizationFilter]
        public IActionResult Delete([FromRoute]int id)
        {
            this.regionLogic.Delete(id);
            return Ok("Element was delete with id "+id);
        }
        [HttpDelete]
        [AuthorizationFilter]
        public IActionResult Delete()
        {
            this.regionLogic.Delete();
            return Ok("All data from Region was");
        }
    }
}
