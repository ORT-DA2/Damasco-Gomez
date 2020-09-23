using System.Linq;
using BusinessLogicInterface;
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
    }
}