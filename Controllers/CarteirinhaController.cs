using Microsoft.AspNetCore.Mvc;

namespace carteiravacina.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarteirinhaController : ControllerBase
    {
       [HttpGet]
        public IActionResult Get()
        {
            return Ok("dois");
        }  
    }
}