using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{

    [EnableCors("CorsPolicy")]
    //[EnableCors("AllowMyOrigin")]
    [ApiController]
    public class VidlyControllerBase : ControllerBase
    {
    }
}