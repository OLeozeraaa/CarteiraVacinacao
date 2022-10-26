using Microsoft.AspNetCore.Mvc;

namespace carteiravacina.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GeoPetzController : ControllerBase
    {
         [HttpGet]
        public IActionResult Get()
        {
            return Ok("quatro");
        }
    }
}