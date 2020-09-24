using System.Linq;
using BusinessLogicInterface;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Model.Out;

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
            return Ok(this.categoryLogic.GetAll().Select(m=> new CategoryBasicInfoModel(m)));
        }

        [HttpGet("{id}")]
        public IActionResult GetBy([FromQuery]int id)
        {
            return Ok();
        }
        [HttpPost()]
        //The post should have CategoryModel , but will leave it like this
        public IActionResult Post([FromBody]Category category)
        {
            return Ok();
        }
        [HttpPut("{id}")]
        //The put should have CategoryModel , but will leave it like this

        public IActionResult Put([FromRoute]int id,[FromBody]Category category)
        {
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete([FromQuery]int id)
        {
            return Ok();
        }
        [HttpDelete()]
        public IActionResult Delete()
        {
            return Ok();
        }
    }
}