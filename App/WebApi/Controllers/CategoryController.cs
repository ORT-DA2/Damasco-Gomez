using System;
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
            var elementCategory = this.categoryLogic.GetAll().Select(m => new CategoryBasicInfoModel(m));
            return Ok(elementCategory);
        }

        [HttpGet("{id}")]
        public IActionResult GetBy([FromQuery]int id)
        {
            var elementCategory = this.categoryLogic.GetBy(id);
            return Ok(elementCategory);
        }
        [HttpPost()]
        //The post should have CategoryModel , but will leave it like this
        public IActionResult Post([FromBody]Category category)
        {
            try
            {
                this.categoryLogic.Add(category);
                return CreatedAtRoute("Api", category.Id, category);
            }
            catch (AggregateException)
            {
                return BadRequest("The category was already added");
            }
            catch (ArgumentException)
            {
                return BadRequest("Error while validate ");
            }
            catch (Exception)
            {
                return BadRequest("The server had an error");
            }
        }
        [HttpPut("{id}")]
        //The put should have CategoryModel , but will leave it like this
        public IActionResult Put([FromRoute]int id,[FromBody]Category category)
        {
            try
            {
                this.categoryLogic.Update(category);
                return CreatedAtRoute("Api", category.Id, category);
                //return Ok(category);
            }
            catch(ArgumentException)
            {
                return BadRequest("Error while validate");
            }
            catch (Exception)
            {
                return BadRequest("Internal server error");
            }
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