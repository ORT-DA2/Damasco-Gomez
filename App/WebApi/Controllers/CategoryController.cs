using System;
using System.Linq;
using BusinessLogicInterface;
using Domain;
using Filters;
using Microsoft.AspNetCore.Mvc;
using Model.In;
using Model.Out;

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
            try
            {
                var elementCategory = this.categoryLogic.GetBy(id);
                return Ok(new CategoryDetailInfoModel(elementCategory));
            }
            catch (ArgumentException)
            {
                return BadRequest("There is not a category with that id");
            }
        }
        [HttpPost()]
        [ServiceFilter(typeof(AuthorizationDIFilter))]
        public IActionResult Post([FromBody]CategoryModel categoryModel)
        {
            try
            {
                Category categoryAdded = this.categoryLogic.Add(categoryModel.ToEntity());
                CategoryDetailInfoModel categoryDetailInfoModel = new CategoryDetailInfoModel(categoryAdded);
                return CreatedAtRoute("GetCategory", new {Id = categoryDetailInfoModel.Id} ,categoryDetailInfoModel);
            }
            catch (AggregateException)
            {
                return BadRequest("The category was already added");
            }
            catch (ArgumentException e)
            {
                return BadRequest("Error while validate : "+ e.Message.ToString());
            }
            catch (Exception)
            {
                return BadRequest("The server had an error");
            }
        }
        [HttpPut("{id}")]
        [ServiceFilter(typeof(AuthorizationDIFilter))]
        public IActionResult Put([FromRoute]int id,[FromBody]CategoryModel categoryModel)
        {
            try
            {
                var newCategory = categoryModel.ToEntity();
                this.categoryLogic.Update(id,newCategory);
                return CreatedAtRoute("GetCategory", new {Id = newCategory.Id} ,new CategoryDetailInfoModel(newCategory));

            }
            catch(ArgumentException e)
            {
                return BadRequest("Error while validate : "+ e.Message.ToString());
            }
            catch (Exception)
            {
                return BadRequest("Internal server error");
            }
        }
        [HttpDelete("{id}")]
        [ServiceFilter(typeof(AuthorizationDIFilter))]
        public IActionResult Delete([FromRoute]int id)
        {
            if (this.categoryLogic.GetBy(id) == null)
            {
                return NotFound();
            }
            this.categoryLogic.Delete(id);
            return Ok();
        }
        [HttpDelete()]
        [ServiceFilter(typeof(AuthorizationDIFilter))]
        public IActionResult Delete()
        {
            this.categoryLogic.Delete();
            return Ok();
        }
    }
}