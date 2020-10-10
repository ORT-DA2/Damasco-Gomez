using System;
using Contracts;
using Domain;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Model.In;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/sessions")]
    public class SessionController : VidlyControllerBase
    {
        private readonly ISessionLogic sessionLogic;

        public SessionController(ISessionLogic sessionLogic)
        {
            this.sessionLogic = sessionLogic;
        }
        [HttpPost()]
        public IActionResult Post([FromBody] PersonModel personModel)
        {
            try
            {
                Person newPerson = personModel.ToEntity();
                this.sessionLogic.Login(newPerson);
                return Ok();
            }
            catch (AggregateException)
            {
                return BadRequest("The session was already added");
            }
            catch (ArgumentException e )
            {
                return BadRequest("Error while validate : "+ e.Message.ToString());
            }
            catch (Exception)
            {
                return BadRequest("The server had an error");
            }
        }
    }
}