using BusinessLogicInterface.Interfaces;
using BusinessLogicInterface.Utils;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/importers")]
    public class ImportController : VidlyControllerBase
    {
        private readonly IImporterLogic importLogic;

        public ImportController(IImporterLogic importLogic)
        {
            this.importLogic = importLogic;
        }
        
        /// <summary>
        /// Permite a un ususario ver los nombres de los import del sistema
        /// </summary>
        /// <response code="200">Se devuelve la información requerida.</response>
        /// <response code="400">Categoria no existente con ese identificador</response>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.importLogic.GetNames());
        }

        /// <summary>
        /// Permite a un administrador agregar un import
        /// </summary>
        /// <param name="importerModel">Este modelo contiene la información del import</param>
        /// <response code="200">Se devuelve la información requerida.</response>
        /// <response code="400">Categoria no existente con ese identificador</response>
        [HttpPost]
        public IActionResult Post([FromBody]ImportModel import)
        {
            this.importLogic.Import(import);
            return Ok();
        }
    }
}