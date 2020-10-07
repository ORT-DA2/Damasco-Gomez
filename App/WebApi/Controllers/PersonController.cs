using System;
using BusinessLogicInterface;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Model.In;

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
        public IActionResult Get()
        {
            var elementPerson = this.personLogic.GetAll();
            return Ok(elementPerson);
        }

        [HttpGet("{id}",Name="GetPerson")]
        public IActionResult GetBy([FromRoute]int id)
        {
            try
            {
                var elementPerson = this.personLogic.GetBy(id);
                return Ok(elementPerson);
            }
            catch (ArgumentException)
            {
                return BadRequest("There is not a booking with that id");
            }
        }
        [HttpPost()]
        //The post should have PersonModel , but will leave it like this
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
        //The put should have PersonModel , but will leave it like this
        public IActionResult Put([FromRoute]int id,[FromBody]Person person)
        {
            try
            {
                this.personLogic.Update(id,person);
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