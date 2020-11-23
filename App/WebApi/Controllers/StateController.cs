using System.Collections.Generic;
using System.Linq;
using BusinessLogicInterface.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Model.Out;

namespace WebApi.Controllers
{
    [Route("api/states")]
    public class StateController : ControllerBase
    {
        private readonly IStateLogic stateLogic;

        public StateController(IStateLogic stateLogic)
        {
            this.stateLogic = stateLogic;
        }
        /// <summary>
        /// Permite a un usuario obtener información de todas los estdos del sistema
        /// </summary>
        /// <response code="200">Se devuelve la información requerida</response>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<State> states = this.stateLogic.GetAll();
            IEnumerable<StateBasicModel> statesBasic = states.Select(m => new StateBasicModel(m));
            return Ok(statesBasic);
        }
        /// <summary>
        /// Permite a un ususario ver un estado del sistema
        /// </summary>
        /// <param name="id">Este parámetro contiene el identificador de la state</param>
        /// <response code="200">Se devuelve la información requerida.</response>
        /// <response code="400">Categoria no existente con ese identificador</response>
        [HttpGet( "{id}" , Name="GetState" )]
        public IActionResult GetBy([FromRoute]int id)
        {
            var elementState = this.stateLogic.GetBy(id);
            StateBasicModel statesBasic = new StateBasicModel(elementState);
            return Ok(statesBasic);
        }
        
    }
}