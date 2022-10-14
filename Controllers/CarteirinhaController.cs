using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using carteiravacina.Models;
using CarteiraVacina_BackEnd.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace carteiravacina.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarteirinhaController : ControllerBase
    {
        private readonly DataContext _context;

        public CarteirinhaController(DataContext context)
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
        
        [HttpDelete("ApagarVacinas")] 
        public async Task<IActionResult> DeleteAsync()
        {
            try
            {
              List<CarteiraVacina> carteiravacinas = await _context.CarteiraVacina.ToListAsync();

              _context.CarteiraVacina.RemoveRange(carteiravacinas);
              await _context.SaveChangesAsync(); 

              return Ok("Informações Removidas!"); 
            }
            catch (System.Exception ex)
            {
              return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                CarteiraVacina pRemover = await _context.CarteiraVacina
                    .FirstOrDefaultAsync(cv => cv.IdCarteira == id);

                _context.CarteiraVacina.Remove(pRemover);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            } 
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AdicionarCarteira(CarteiraVacina carteiraVacina)
        {
            try
            {
                await _context.CarteiraVacina.AddAsync(carteiraVacina);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Editar")]
        public async Task<IActionResult> EditarCarteira(CarteiraVacina carteiraVacina)
        {
            try
            {
                _context.CarteiraVacina.Update(carteiraVacina);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch(System.Exception ex)
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