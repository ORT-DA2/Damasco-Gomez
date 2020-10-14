using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{

    [EnableCors("CorsPolicy")]
    [ApiController]
    public class VidlyControllerBase : ControllerBase
    {
        
    }
}