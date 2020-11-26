using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{

    [EnableCors("AllowEverything")]
    [ApiController]
    public class ControllerBaseApi : ControllerBase
    {
    }
}