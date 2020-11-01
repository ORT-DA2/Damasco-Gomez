using BusinessLogicInterface.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/states")]
    public class StateController : VidlyControllerBase
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
        }
        
    }
}