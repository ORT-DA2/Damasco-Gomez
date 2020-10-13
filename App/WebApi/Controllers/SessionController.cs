using Contracts;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Model.In;

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
        [HttpPost()]
        public IActionResult Post([FromBody] PersonModel personModel)
        {
            Person newPerson = personModel.ToEntity();
            Guid token =this.sessionLogic.Login(newPerson);
            return Ok(token);
        }
    }
}