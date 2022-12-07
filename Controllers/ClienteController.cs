using System.Collections.Generic;
using System.Threading.Tasks;
using carteiravacina.Models;
using CarteiraVacina_BackEnd.Data;
using CarteiraVacinacao.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace carteiravacina.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly DataContext _context;

        public ClienteController(DataContext context)
        {
            _context = context;
        }
        

        [HttpGet("ListarR")]
        public async Task<IActionResult> ListarAsyncV()
        {
            try
            {
                List<RGA> rga = await _context.RGA.ToListAsync(); 
                return Ok(rga);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ListarT")]
        public async Task<IActionResult> ListarAsynct()
        {
            try
            {
                List<Tutor> tutor = await _context.Tutor.ToListAsync(); 
                return Ok(tutor);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
    }
