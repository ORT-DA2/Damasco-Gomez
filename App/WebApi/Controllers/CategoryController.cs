using System;
using System.Linq;
using BusinessLogicInterface;
using Domain;
using Filters;
using Microsoft.AspNetCore.Mvc;
using Model.In;
using Model.Out;
using WebApi.Filters;

namespace WebApi.Controllers
{
    [ApiController]
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
            var elementCategory = this.categoryLogic.GetAll().Select(m => new CategoryBasicInfoModel(m)).ToList();
            return Ok(elementCategory);
        }

        [HttpGet("{id}",Name="GetCategory")]
        public IActionResult GetBy([FromRoute]int id)
        {
            Category elementCategory = this.categoryLogic.GetBy(id);
            return Ok(new CategoryDetailInfoModel(elementCategory));
        }
        [HttpPost()]
        [AuthorizationFilter]
        public IActionResult Post([FromBody]CategoryModel categoryModel)
        {
            Category categoryAdded = this.categoryLogic.Add(categoryModel.ToEntity());
            CategoryBasicInfoModel categoryInfoModel = new CategoryBasicInfoModel(categoryAdded);
            return CreatedAtRoute("GetCategory", new {Id = categoryInfoModel.Id} ,categoryInfoModel);
        }
        [HttpPut("{id}")]
        [AuthorizationFilter]
        public IActionResult Put([FromRoute]int id,[FromBody]CategoryModel categoryModel)
        {
            Category newCategory = categoryModel.ToEntity();
            newCategory = this.categoryLogic.Update(id,newCategory);
            CategoryBasicInfoModel categoryInfoModel = new CategoryBasicInfoModel(newCategory);
            return CreatedAtRoute("GetCategory", new {Id = categoryInfoModel.Id} ,categoryInfoModel);
        }
        [HttpDelete("{id}")]
        [AuthorizationFilter]
        public IActionResult Delete([FromRoute]int id)
        {
            this.categoryLogic.Delete(id);
            return Ok("Element was delete with id "+id);
        }
        [HttpDelete]
        [AuthorizationFilter]
        public IActionResult Delete()
        {
            this.categoryLogic.Delete();
            return Ok("All data from Category was");
        }
    }
}