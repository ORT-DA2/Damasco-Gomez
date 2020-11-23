using System.Collections.Generic;
using System.Linq;
using BusinessLogicInterface;
using Domain;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.In;
using WebApi.Filters;

namespace WebApi.Controllers
{
    [Route("api/houses")]
    public class HouseController : ControllerBase
    {
        private readonly IHouseLogic houseLogic;
        public HouseController(IHouseLogic houseLogic)
        {
            this.houseLogic = houseLogic;
        }
        //..api/houses
        //..api/house?idTP=1
        /// <summary>
        /// Permite a un usuario obtener información de todas los hosepdajes del sistema, tiene la opcion
        /// de buscar en base a ciertos parametros, que le permiten filtrar por punto turistico
        /// dentro de ciertas fechas, con cantidad de personas y le devuelve ademas de los
        /// hospedajes, un precio para dicho hospedaje segun las noches
        /// </summary>
        /// <response code="200">Se devuelve la información requerida</response>
        [HttpGet]
        public IActionResult GetHousesBy([FromQuery]HouseSearchModel houseSearchModel)
        {
            IEnumerable<House> varRet ;
            IEnumerable<HouseBasicModel> basicModels;
            if(houseSearchModel.NotNull())
            {
                houseSearchModel.CheckAllParameters();
                HouseSearch houseSearch = houseSearchModel.ToEntity();
                // Get houses by tourist point
                varRet = this.houseLogic.GetHousesBy(houseSearch);
                basicModels = varRet.
                    Select(m => new HouseBasicModel(m,houseSearch)).ToList();
            }
            else
            {
                //Get ALL houses
                varRet = this.houseLogic.GetAll();
                basicModels = varRet.Select( m => new HouseBasicModel(m));
            }
            return Ok(basicModels);
        }
        //...api/houses/{id}
        /// <summary>
        /// Permite a un ususario ver un hospedaje del sistema
        /// </summary>
        /// <param name="id">Este parámetro contiene el identificador del hospedaje</param>
        /// <response code="200">Se devuelve la información requerida.</response>
        /// <response code="400">Reserva no existente con ese identificador</response>
        [HttpGet("{id}",Name="GetHouse")]
        public IActionResult GetBy([FromRoute]int id)
        {
            House elementHouse = this.houseLogic.GetBy(id);
            HouseDetailModel modelHouse = new HouseDetailModel(elementHouse);
            return Ok(modelHouse);
        }
        /// <summary>
        /// Permite a un administrador realizar un hospedajes
        /// </summary>
        /// <param name="houseModel">Este modelo contiene la información del hospedaje</param>
        /// <response code="200">Se devuelve la información requerida.</response>
        /// <response code="400">Reserva no existente con ese identificador</response>
        [HttpPost]
        [AuthorizationFilter]
        public IActionResult Post([FromBody]HouseModel houseModel)
        {
            House house = houseModel.ToEntity();
            house = this.houseLogic.Add(house);
            HouseBasicModel basicModel = new HouseBasicModel(house);
            return CreatedAtRoute("GetHouse", new {Id = basicModel.Id}, basicModel);
        }
        /// <summary>
        /// Permite a un administrador modificar un hospedaje
        /// </summary>
        /// <param name="id">Este parámetro contiene el identificador del hospedaje</param>
        /// <param name="houseModel">Este modelo contiene la información del hospedaje</param>
        /// <response code="200">Se devuelve la información requerida.</response>
        /// <response code="400">Reserva no existente con ese identificador</response>
        [HttpPut("{id}")]
        [AuthorizationFilter]
        public IActionResult Put([FromRoute]int id,[FromBody]HouseModel houseModel)
        {
            House house = houseModel.ToEntity(false);
            house = this.houseLogic.Update(id,house);
            HouseBasicModel basicModel = new HouseBasicModel(house);
            return CreatedAtRoute("GetHouse", new {Id = basicModel.Id} , basicModel);
        }
        /// <summary>
        /// Permite a un administrador eliminar un hospedajes
        /// </summary>
        /// <param name="id">Este parámetro contiene el identificador del hospedaje</param>
        /// <response code="200">Se devuelve la información requerida.</response>
        /// <response code="400">Reserva no existente con ese identificador</response>
        [HttpDelete("{id}")]
        [AuthorizationFilter]
        public IActionResult Delete([FromRoute]int id)
        {
            this.houseLogic.Delete(id);
            return Ok("Element was delete with id "+id);
        }
        /// <summary>
        /// Permite a un administrador eliminar todos los hospedajes
        /// </summary>
        /// <response code="200">Se devuelve la información requerida.</response>
        [HttpDelete]
        [AuthorizationFilter]
        public IActionResult Delete()
        {
            this.houseLogic.Delete();
            return Ok("All data from House was");
        }
    }
}
