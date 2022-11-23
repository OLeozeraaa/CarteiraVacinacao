using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using carteiravacina.Models;
using CarteiraVacinacao.Models;
using CarteiraVacina_BackEnd.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace carteiravacina.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class RGAController : ControllerBase
    {
        private readonly DataContext _context;

        public RGAController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AdicionarRGA(RGA rga)
        {
            try
            {
                /* string minDate = "01/01/1753 00:00:00 PM";
                if(rga.DataAdicao <= DateTime.Parse(minDate))
                    rga.DataAdicao.Equals(null); */
                await _context.RGA.AddAsync(rga);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /* [HttpPut("Editar")]
        public async Task<IActionResult> EditarCarteira(Animal animal)
        {
            try
            {
                _context.Animal.Update(animal);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } */

        [HttpGet("Listar")]
        public async Task<IActionResult> ListarAsync()
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

        /* [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                RGA rga = await _context.RGA
                    .Include(rga => rga.IdRGA)
                    .Include(ia => ia.IdAnimal)
                    .Include(nm => nm.Nome)
                    .Include(ie => ie.IdEspecie)
                    .Include(ir => ir.IdRaca)
                    .Include(ise => ise.IdSexo)
                    .Include(dt => dt.DtNascimento)
                    .Include(pl => pl.Pelagem)
                    .Include(ass => ass.Assinatura)
                    .Include(pt => pt.Pata)
                    .Include(ch => ch.Chip)
                    .Include(rg => rg.Rga)
                    .Include(ft => ft.Foto)
                    .FirstOrDefaultAsync(pBusca => pBusca.IdRGA == id);

                return Ok(rga);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        } */

        [HttpDelete("Remover")] 
        public async Task<IActionResult> DeleteAsync()
        {
            try
            {
              List<RGA>rga = await _context.RGA.ToListAsync();

              _context.RGA.RemoveRange(rga);
              await _context.SaveChangesAsync(); 

              return Ok("Informações Removidas!"); 
            }
            catch (System.Exception ex)
            {
              return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Remover/{id}")]
        public async Task<IActionResult> DeleteC(int id)
        {
            try
            {
                RGA pRemover = await _context.RGA
                    .FirstOrDefaultAsync(rga => rga.IdRGA == id);

                _context.RGA.Remove(pRemover);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            } 
        }

   }
}