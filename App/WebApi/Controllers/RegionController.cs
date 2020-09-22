using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/regions")]
    public class RegionController : VidlyControllerBase
    {
       private readonly IRegionLogic regionsLogic;

        public RegionController (IRegionLogic regionsLogic)
        {
            this.regionsLogic = regionsLogic;
        }
        [HttpGet]
        //api/regions
        public IActionResult Get()
        {
            return Ok(this.regionsLogic.getAll().select(m=>regionBasicModel(m)));
        }



    }
}