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
    public class PersonController : VidlyControllerBase
    {
        private readonly IPersonLogic personLogic;

        public PersonController(IPersonLogic personLogic)
        {
            this.personLogic = personLogic;
        }
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Person> elementPerson = this.personLogic.GetAll();
            IEnumerable<PersonBasicModel> personBasicModels = elementPerson.Select(m => new PersonBasicModel(m));
            return Ok(personBasicModels);
        }

        [HttpGet("{id}",Name="GetPerson")]
        public IActionResult GetBy([FromRoute]int id)
        {
            Person elementPerson = this.personLogic.GetBy(id);
            PersonBasicModel personBasicModel = new PersonBasicModel(elementPerson);
            return Ok(personBasicModel);
        }
        [HttpPost]
        public IActionResult Post([FromBody]PersonModel personModel)
        {
            Person person = personModel.ToEntity();
            person = this.personLogic.Add(person);
            PersonBasicModel personBasicModel = new PersonBasicModel(person);
            return CreatedAtRoute("GetPerson", new {Id = personBasicModel.Id} , personBasicModel);
        }
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute]int id,[FromBody]PersonModel personModel)
        {
            Person person = personModel.ToEntity();
            person = this.personLogic.Update(id,person);
            PersonBasicModel personBasicModel = new PersonBasicModel(person);
            return CreatedAtRoute("GetPerson", new {Id = personBasicModel.Id} , personBasicModel);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute]int id)
        {
            this.personLogic.Delete(id);
            return Ok("Element was delete with id "+id);
        }
        [HttpDelete]
        public IActionResult Delete()
        {
            this.personLogic.Delete();
            return Ok("All data from Person was");
        }
    }
}