using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bazzar.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get() => Ok("Hello from Bazzar.Api! Look for bugs work on fixes");
    }
}
