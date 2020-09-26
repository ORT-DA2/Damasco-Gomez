using BusinessLogicInterface;
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

    }
}