using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogicInterface;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Model.In;
using Model.Out;

namespace WebApi.Controllers
{
    [Route("api/persons")]
    public class PersonController : ControllerBaseApi
    {
        private readonly IPersonLogic personLogic;

        public PersonController(IPersonLogic personLogic)
        {
            this.personLogic = personLogic;
        }
        /// <summary>
        /// Permite a un usuario obtener información de todas las personas del sistema
        /// </summary>
        /// <response code="200">Se devuelve la información requerida</response>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Person> Persons = this.personLogic.GetAll();
            IEnumerable<PersonBasicModel> personBasicModels = Persons.Select(m => new PersonBasicModel(m));
            return Ok(personBasicModels);
        }

        /// <summary>
        /// Permite a un ususario ver una persona del sistema
        /// </summary>
        /// <param name="id">Este parámetro contiene el identificador de la persona</param>
        /// <response code="200">Se devuelve la información requerida.</response>
        /// <response code="400">Reserva no existente con ese identificador</response>
        [HttpGet("{id}",Name="GetPerson")]
        public IActionResult GetBy([FromRoute]int id)
        {
            Person elementPerson = this.personLogic.GetBy(id);
            PersonBasicModel personBasicModel = new PersonBasicModel(elementPerson);
            return Ok(personBasicModel);
        }

        /// <summary>
        /// Permite a un administrador realizar una persona
        /// </summary>
        /// <param name="personModel">Este modelo contiene la información de la persona</param>
        /// <response code="200">Se devuelve la información requerida.</response>
        /// <response code="400">Reserva no existente con ese identificador</response>
        [HttpPost]
        public IActionResult Post([FromBody]PersonModel personModel)
        {
            Person person = personModel.ToEntity();
            person = this.personLogic.Add(person);
            PersonBasicModel personBasicModel = new PersonBasicModel(person);
            return CreatedAtRoute("GetPerson", new {Id = personBasicModel.Id} , personBasicModel);
        }
        /// <summary>
        /// Permite a un administrador modificar una persona
        /// </summary>
        /// <param name="id">Este parámetro contiene el identificador de la persona</param>
        /// <param name="personModel">Este modelo contiene la información de la persona</param>
        /// <response code="200">Se devuelve la información requerida.</response>
        /// <response code="400">Reserva no existente con ese identificador</response>
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute]int id,[FromBody]PersonModel personModel)
        {
            Person person = personModel.ToEntity();
            person = this.personLogic.Update(id,person);
            PersonBasicModel personBasicModel = new PersonBasicModel(person);
            return CreatedAtRoute("GetPerson", new {Id = personBasicModel.Id} , personBasicModel);
        }
        /// <summary>
        /// Permite a un administrador eliminar una persona
        /// </summary>
        /// <param name="id">Este parámetro contiene el identificador de la persona</param>
        /// <response code="200">Se devuelve la información requerida.</response>
        /// <response code="400">Reserva no existente con ese identificador</response>
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute]int id)
        {
            this.personLogic.Delete(id);
            return Ok("Element was delete with id "+id);
        }
        /// <summary>
        /// Permite a un administrador eliminar todas las personas
        /// </summary>
        /// <response code="200">Se devuelve la información requerida.</response>
        [HttpDelete]
        public IActionResult Delete()
        {
            this.personLogic.Delete();
            return Ok("All data from Person was");
        }
    }
}