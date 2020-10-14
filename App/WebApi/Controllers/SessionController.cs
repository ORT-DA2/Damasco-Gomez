using System;
using Contracts;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Model.In;
using Model.Out;

namespace WebApi.Controllers
{
    [Route("api/sessions")]
    public class SessionController : VidlyControllerBase
    {
        private readonly ISessionLogic sessionLogic;

        public SessionController(ISessionLogic sessionLogic)
        {
            this.sessionLogic = sessionLogic;
        }
        /// <summary>
        /// Permite a un ususario logguearse al sistema
        /// </summary>
        /// <param name="personModel">Este modelo contiene la información del usuario</param>
        /// <response code="200">Se devuelve la información requerida</response>
        /// <response code="400">Reserva no existente con ese identificador</response>
        [HttpPost]
        public IActionResult Post([FromBody] PersonModel personModel)
        {
            Person newPerson = personModel.ToEntity();
            Guid token =this.sessionLogic.Login(newPerson);
            SessionBasicModel sessionModel = new SessionBasicModel(token);
            return Ok(sessionModel);
        }
    }
}