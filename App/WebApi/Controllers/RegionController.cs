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

    [Route("api/regions")]
    public class RegionController : ControllerBaseApi
    {
        private readonly IRegionLogic regionLogic;

        public RegionController(IRegionLogic regionLogic)
        {
            this.regionLogic = regionLogic;
        }
        /// <summary>
        /// Permite a un usuario obtener información de todas las regiones del sistema
        /// </summary>
        /// <response code="200">Se devuelve la información requerida</response>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Region> regions = this.regionLogic.GetAll();
            IEnumerable<RegionDetailModel> regionsBasic = regions.Select(m => new RegionDetailModel(m));
            return Ok(regionsBasic);
        }
        /// <summary>
        /// Permite a un ususario ver una region del sistema
        /// </summary>
        /// <param name="id">Este parámetro contiene el identificador de la region</param>
        /// <response code="200">Se devuelve la información requerida.</response>
        /// <response code="400">Categoria no existente con ese identificador</response>
        [HttpGet( "{id}" , Name="GetRegion" )]
        public IActionResult GetBy([FromRoute]int id)
        {
            var elementRegion = this.regionLogic.GetBy(id);
            RegionDetailModel regionsBasic = new RegionDetailModel(elementRegion);
            return Ok(regionsBasic);
        }
        /// <summary>
        /// Permite a un administrador agregar una region
        /// </summary>
        /// <param name="regionModel">Este modelo contiene la información de la region</param>
        /// <response code="200">Se devuelve la información requerida.</response>
        /// <response code="400">Categoria no existente con ese identificador</response>
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
        /// <summary>
        /// Permite a un administrador modificar una region
        /// </summary>
        /// <param name="id">Este parámetro contiene el identificador de la region</param>
        /// <param name="regionModel">Este modelo contiene la información de la region</param>
        /// <response code="200">Se devuelve la información requerida.</response>
        /// <response code="400">Categoria no existente con ese identificador</response>
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
        /// <summary>
        /// Permite a un administrador eliminar una region
        /// </summary>
        /// <param name="id">Este parámetro contiene el identificador de la region</param>
        /// <response code="200">Se devuelve la información requerida.</response>
        /// <response code="400">Categoria no existente con ese identificador</response>
        [HttpDelete("{id}")]
        [AuthorizationFilter]
        public IActionResult Delete([FromRoute]int id)
        {
            this.regionLogic.Delete(id);
            return Ok("Element was delete with id "+id);
        }
        /// <summary>
        /// Permite a un administrador eliminar todas las regiones
        /// </summary>
        /// <response code="200">Se devuelve la información requerida.</response>
        [HttpDelete]
        [AuthorizationFilter]
        public IActionResult Delete()
        {
            this.regionLogic.Delete();
            return Ok("All data from Region was");
        }
    }
}
