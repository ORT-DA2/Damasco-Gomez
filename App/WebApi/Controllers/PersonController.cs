using BusinessLogicInterface;
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
    }
}