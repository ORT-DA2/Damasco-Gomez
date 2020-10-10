using System;
using Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Post([FromBody]string userName , string password)
        {
            try
            {
                this.sessionLogic.Login(userName,password);
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