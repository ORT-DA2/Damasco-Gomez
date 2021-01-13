using System.Linq;
using BusinessLogicInterface;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Model.In;
using Model.Out;
using WebApi.Filters;

namespace WebApi.Controllers
{
    [Route("api/categories")]
    public class CategoryController : ControllerBaseApi
    {
        private readonly ICategoryLogic categoryLogic;
        public CategoryController(ICategoryLogic categoryLogic)
        {
            this.categoryLogic = categoryLogic;
        }
        /// <summary>
        /// Permite a un usuario obtener información de todas las categorias del sistema
        /// </summary>
        /// <response code="200">Se devuelve la información requerida</response>
        [HttpGet]
        public IActionResult Get()
        {
            var Categories = this.categoryLogic.GetAll().Select(m => new CategoryBasicInfoModel(m)).ToList();
            return Ok(Categories);
        }
        /// <summary>
        /// Permite a un ususario ver una categoria del sistema
        /// </summary>
        /// <param name="id">Este parámetro contiene el identificador de la categoria</param>
        /// <response code="200">Se devuelve la información requerida.</response>
        /// <response code="400">Categoria no existente con ese identificador</response>
        [HttpGet("{id}",Name="GetCategory")]
        public IActionResult GetBy([FromRoute]int id)
        {
            Category Category = this.categoryLogic.GetBy(id);
            return Ok(new CategoryDetailInfoModel(Category));
        }
        /// <summary>
        /// Permite a un administrador agregar una categoria
        /// </summary>
        /// <param name="categoryModel">Este modelo contiene la información de la categoria</param>
        /// <response code="200">Se devuelve la información requerida.</response>
        /// <response code="400">Categoria no existente con ese identificador</response>
        [HttpPost]
        [AuthorizationFilter]
        public IActionResult Post([FromBody]CategoryModel categoryModel)
        {
            Category categoryAdded = this.categoryLogic.Add(categoryModel.ToEntity());
            CategoryDetailInfoModel categoryInfoModel = new CategoryDetailInfoModel(categoryAdded);
            return CreatedAtRoute("GetCategory", new {Id = categoryInfoModel.Id} ,categoryInfoModel);
        }
        /// <summary>
        /// Permite a un administrador modificar una categoria
        /// </summary>
        /// <param name="id">Este parámetro contiene el identificador de la categoria</param>
        /// <param name="categoryModel">Este modelo contiene la información de la categoria</param>
        /// <response code="200">Se devuelve la información requerida.</response>
        /// <response code="400">Categoria no existente con ese identificador</response>
        [HttpPut("{id}")]
        [AuthorizationFilter]
        public IActionResult Put([FromRoute]int id,[FromBody]CategoryModel categoryModel)
        {
            Category newCategory = categoryModel.ToEntity();
            newCategory = this.categoryLogic.Update(id,newCategory);
            CategoryDetailInfoModel categoryInfoModel = new CategoryDetailInfoModel(newCategory);
            return CreatedAtRoute("GetCategory", new {Id = categoryInfoModel.Id} ,categoryInfoModel);
        }
        /// <summary>
        /// Permite a un administrador eliminar una categoria
        /// </summary>
        /// <param name="id">Este parámetro contiene el identificador de la categoria</param>
        /// <response code="200">Se devuelve la información requerida.</response>
        /// <response code="400">Categoria no existente con ese identificador</response>
        [HttpDelete("{id}")]
        [AuthorizationFilter]
        public IActionResult Delete([FromRoute]int id)
        {
            this.categoryLogic.Delete(id);
            return Ok();
        }
        /// <summary>
        /// Permite a un administrador eliminar todas las categorias
        /// </summary>
        /// <response code="200">Se devuelve la información requerida.</response>
        [HttpDelete]
        [AuthorizationFilter]
        public IActionResult Delete()
        {
            this.categoryLogic.Delete();
            return Ok();
        }
    }
}