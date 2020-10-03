using System;
using BusinessLogicInterface;
using Domain;
using Microsoft.AspNetCore.Mvc;

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
            var elementPerson = this.personLogic.GetBy(id);
            return Ok(elementPerson);
        }
        [HttpPost()]
        //The post should have PersonModel , but will leave it like this
        public IActionResult Post([FromBody]Person person)
        {
            try
            {
                this.personLogic.Add(person);
                return CreatedAtRoute("GetPerson", person.Id, person);
            }
            catch (AggregateException)
            {
                return BadRequest("The person was already added");
            }
            catch (ArgumentException)
            {
                return BadRequest("Error while validate ");
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
                return CreatedAtRoute("GetPerson", person.Id, person);
            }
            catch(ArgumentException)
            {
                return BadRequest("Error while validate");
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