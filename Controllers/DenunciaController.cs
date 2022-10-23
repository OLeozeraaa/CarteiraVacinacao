using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using carteiravacina.Models;
using CarteiraVacina_BackEnd.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace carteiravacina.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class DenunciaController : ControllerBase
    {
        private readonly DataContext _context;

        public DenunciaController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                CarteiraVacina cv = await _context.CarteiraVacina
                    .Include(cv => cv.IdCarteira)
                    .Include(tp => tp.TipoVacina)
                    .Include(dt => dt.dataVacina)
                    .Include(pv => pv.ProxVacina)
                    .FirstOrDefaultAsync(pBusca => pBusca.IdCarteira == id);

                return Ok(cv);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

         [HttpGet("Listar")]


        public async Task<IActionResult> ListarAsync()
        {
            try
            {
                List<CarteiraVacina> carteiravacinas = await _context.CarteiraVacina.ToListAsync(); 
                return Ok(carteiravacinas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}