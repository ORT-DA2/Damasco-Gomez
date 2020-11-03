using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [EnableCors("AllowEverything")]
    public class VidlyControllerBase : ControllerBase
    {
        
    }
}