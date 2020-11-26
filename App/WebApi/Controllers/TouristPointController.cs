using System;
using System.Linq;
using BusinessLogicInterface;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Model.In;
using Model.Out;
using WebApi.Filters;

namespace WebApi.Controllers
{   
    [Route("api/touristpoints")]
    public class TouristPointController : ControllerBaseApi
    {
        private readonly ITouristPointLogic touristPointLogic;
        public TouristPointController(ITouristPointLogic touristPointLogic)
        {
            this.touristPointLogic = touristPointLogic;
        }
        /// <summary>
        /// Permite a un usuario obtener información de todas los puntos turisticos del sistema
        /// </summary>
        /// <response code="200">Se devuelve la información requerida</response>
        [HttpGet]
        public IActionResult Get()
        {
            var touristPoints = this.touristPointLogic.GetAll();
            var modelTouristPoint = touristPoints.Select(m => new TouristPointBasicInfoModel(m)).ToList();
            return Ok(modelTouristPoint);
        }
        /// <summary>
        /// Permite a un ususario ver un punto turistico del sistema
        /// </summary>
        /// <param name="id">Este parámetro contiene el identificador del punto turistico</param>
        /// <response code="200">Se devuelve la información requerida.</response>
        /// <response code="400">Reserva no existente con ese identificador</response>
        [HttpGet("{id}",Name="GetTouristPoint")]
        public IActionResult GetBy([FromRoute]int id)
        {
            var elementTouristPoint = this.touristPointLogic.GetBy(id);
            var modelTouristPoint = new TouristPointDetailInfoModel(elementTouristPoint);
            return Ok(modelTouristPoint);
        }
        /// <summary>
        /// Permite a un administrador realizar un punto turisticos
        /// </summary>
        /// <param name="touristPointModel">Este modelo contiene la información del punto turistico</param>
        /// <response code="200">Se devuelve la información requerida.</response>
        /// <response code="400">Reserva no existente con ese identificador</response>
        [HttpPost]
        [AuthorizationFilter]
        public IActionResult Post([FromBody]TouristPointModel touristPointModel)
        {
            var newTouristPoint = touristPointModel.ToEntity();
            var touristPointAdded = this.touristPointLogic.Add(newTouristPoint);
            var touristPointModelOut = new TouristPointDetailInfoModel(touristPointAdded);
            var routePost = CreatedAtRoute("GetTouristPoint", new {Id = touristPointAdded.Id} , touristPointModelOut);
            return routePost;
        }
        /// <summary>
        /// Permite a un administrador modificar un punto turistico
        /// </summary>
        /// <param name="id">Este parámetro contiene el identificador del punto turistico</param>
        /// <param name="touristPointModel">Este modelo contiene la información del punto turistico</param>
        /// <response code="200">Se devuelve la información requerida.</response>
        /// <response code="400">Reserva no existente con ese identificador</response>
        [HttpPut("{id}")]
        [AuthorizationFilter]
        public IActionResult Put([FromRoute]int id,[FromBody]TouristPointModel touristPointModel)
        {
            TouristPoint touristPoint = touristPointModel.ToEntity();
            touristPoint = this.touristPointLogic.Update(id,touristPoint);
            TouristPointDetailInfoModel basicModel = new TouristPointDetailInfoModel(touristPoint);
            return CreatedAtRoute("GetTouristPoint", new {id =basicModel.Id} ,basicModel);
        }
        /// <summary>
        /// Permite a un administrador eliminar un punto turistico
        /// </summary>
        /// <param name="id">Este parámetro contiene el identificador del punto turistico</param>
        /// <response code="200">Se devuelve la información requerida.</response>
        /// <response code="400">Reserva no existente con ese identificador</response>
        [HttpDelete("{id}")]
        [AuthorizationFilter]
        public IActionResult Delete([FromRoute]int id)
        {
            this.touristPointLogic.Delete(id);
            return Ok("Element was delete with id "+id);
        }
        /// <summary>
        /// Permite a un administrador eliminar todos los punto turisticos
        /// </summary>
        /// <response code="200">Se devuelve la información requerida.</response>
        [HttpDelete]
        [AuthorizationFilter]
        public IActionResult Delete()
        {
            this.touristPointLogic.Delete();
            return Ok("All data from TouristPoint was");
        }
    }
}
