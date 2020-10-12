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
            Person newPerson = personModel.ToEntity();
            this.sessionLogic.Login(newPerson);
            return Ok("User logged");
        }
    }
}