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
    public class AnimaisController : ControllerBase
    {
        private readonly DataContext _context;

        public AnimaisController(DataContext context)
        {
            _context = context;
        }

        /* [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                Animal an = await _context.Animal
                    .Include(an => an.Id)
                    .Include(tp => tp.PetName)
                    .FirstOrDefaultAsync(pBusca => pBusca.Id == id);

                return Ok(cv);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } */

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Animal pRemover = await _context.Animal
                    .FirstOrDefaultAsync(an => an.Id == id);

                _context.Animal.Remove(pRemover);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            } 
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AdicionarAnimal(Animal animal)
        {
            try
            {
                await _context.Animal.AddAsync(animal);
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
                List<Animal> animals = await _context.Animal.ToListAsync(); 
                return Ok(animals);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Sexos")]
        public async Task<IActionResult> ListarSexos()
        {
            try
            {
                List<Sexos> sexos = await _context.Sexos.ToListAsync();
                return Ok(sexos);
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Especies")]
        public async Task<IActionResult> ListarEspecies()
        {
            try
            {
                List<Especie> especies = await _context.Especie.ToListAsync();
                return Ok(especies);
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Racas")]
        public async Task<IActionResult> ListarRacas()
        {
            try
            {
                List<Racas> racas = await _context.Racas.ToListAsync();
                return Ok(racas);
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}