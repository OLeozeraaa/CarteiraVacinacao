using Microsoft.AspNetCore.Mvc;

namespace carteiravacina.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RGAController : ControllerBase
    {
         [HttpGet]
        public IActionResult Get()
        {
            return Ok("cinco");
        }
    }
}