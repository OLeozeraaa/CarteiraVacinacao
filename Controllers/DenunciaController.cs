using System;
using CarteiraVacinacao.Data;
using Microsoft.AspNetCore.Mvc;

namespace carteiravacina.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DenunciaController : ControllerBase
    {
        /*public DenunciaController(IRepository repo)
        {
            
        }*/
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok("");
            }
            catch(Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
            
        }
    }
}