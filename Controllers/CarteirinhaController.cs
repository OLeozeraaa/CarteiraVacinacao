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
    [Route("[controller]")]
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
                Carteira cv = await _context.Carteira
                    .Include(cv => cv.Id)
                    .Include(tp => tp.PetName)
                    .FirstOrDefaultAsync(pBusca => pBusca.Id == id);

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
              List<Vacina> vacinas = await _context.Vacina.ToListAsync();

              _context.Vacina.RemoveRange(vacinas);
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
                Vacina pRemover = await _context.Vacina
                    .FirstOrDefaultAsync(cv => cv.IdVacina == id);

                _context.Vacina.Remove(pRemover);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            } 
        }

        /*[HttpPost("Add")]
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
        }*/

        [HttpPost("Add")]
        public async Task<IActionResult> Add(Vacina vacina)
        {
            try
            {
                Vacina vacinaC = await _context.Vacina
                    .FirstOrDefaultAsync(p => p.IdVacina == vacina.IdVacina);

                if (vacina == null)
                    throw new System.Exception("Informação invalida!.");

                Vacina vacinA = await _context.Vacina
                    .FirstOrDefaultAsync(a => a.IdVacina ==  vacina.IdVacina);

                if (vacinA != null)
                    throw new System.Exception("Vacina selecionada já contida na carteira");
                
                await _context.Vacina.AddAsync(vacina);
                await _context.SaveChangesAsync();

                return Ok(vacina.IdVacina);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddV")]
        public async Task<IActionResult> AdicionarVacina(Vacina vacina)
        {
            try
            {
                await _context.Vacina.AddAsync(vacina);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddC")]
        public async Task<IActionResult> AdicionarCarteirinha(Carteira carteira)
        {
            try
            {
                await _context.Carteira.AddAsync(carteira);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteC/{id}")]
        public async Task<IActionResult> DeleteC(int id)
        {
            try
            {
                Carteira pRemover = await _context.Carteira
                    .FirstOrDefaultAsync(cv => cv.Id == id);

                _context.Carteira.Remove(pRemover);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            } 
        }

        /* [HttpPut("Editar")]
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
 */

        [HttpGet("Listar")]


        public async Task<IActionResult> ListarAsync()
        {
            try
            {
                List<Vacina> vacinas = await _context.Vacina.ToListAsync(); 
                return Ok(vacinas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Card/Listar")]
        public async Task<IActionResult> ListarCarteiras()
        {
            try
            {
                List<Carteira> carteiras = await _context.Carteira.ToListAsync();
                return Ok(carteiras);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}