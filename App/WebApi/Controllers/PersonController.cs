using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogicInterface;
using Domain;
using Filters;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.In;
using Model.Out;
namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/persons")]
    [ServiceFilter(typeof(AuthorizationDIFilter))]
    public class PersonController : VidlyControllerBase
    {
        private readonly IPersonLogic personLogic;

        public PersonController(IPersonLogic personLogic)
        {
            this.personLogic = personLogic; 
        }
        public IActionResult Get()
        {
            IEnumerable<Person> elementPerson = this.personLogic.GetAll();
            IEnumerable<PersonBasicModel> personBasicModels = elementPerson.Select(m => new PersonBasicModel(m));
            return Ok(personBasicModels);
        }

        [HttpGet("{id}",Name="GetPerson")]
        public IActionResult GetBy([FromRoute]int id)
        {
            try
            {
                Person elementPerson = this.personLogic.GetBy(id);
                PersonBasicModel personBasicModel = new PersonBasicModel(elementPerson);
                return Ok(personBasicModel);
            }
            catch (ArgumentException)
            {
                return BadRequest("There is not a booking with that id");
            }
        }
        [HttpPost()]
        public IActionResult Post([FromBody]PersonModel personModel)
        {
            try
            {
                Person person = personModel.ToEntity();
                person = this.personLogic.Add(person);
                return CreatedAtRoute("GetPerson", new {Id = person.Id} , person);
            }
            catch (AggregateException)
            {
                return BadRequest("The person was already added");
            }
            catch (ArgumentException e)
            {
                return BadRequest("Error while validate : "+ e.Message.ToString());
            }
            catch (Exception)
            {
                return BadRequest("The server had an error");
            }
        }
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute]int id,[FromBody]PersonModel personModel)
        {
            try
            {
                Person person = personModel.ToEntity();
                person = this.personLogic.Update(id,person);
                return CreatedAtRoute("GetPerson", new {Id = person.Id} , person);
            }
            catch(ArgumentException e)
            {
                return BadRequest("Error while validate : "+ e.Message.ToString());
            }
            catch (Exception)
            {
                return BadRequest("Internal server error");
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute]int id)
        {
            if (this.personLogic.GetBy(id) == null)
            {
                return NotFound();
            }
            this.personLogic.Delete(id);
            return Ok();
        }
        [HttpDelete()]
        public IActionResult Delete()
        {
            this.personLogic.Delete();
            return Ok();
        }
    }
}