using BusinessLogicInterface;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/categories")]
    public class CategoryController : VidlyControllerBase
    {
        private readonly ICategoryLogic categoryLogic;
        public CategoryController(ICategoryLogic categoryLogic)
        {
            this.categoryLogic = categoryLogic;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.categoryLogic.GetAll());
        }

        [HttpGet]
        public IActionResult GetBy([FromQuery]int id)
        {
            return Ok();
        }
    }
}