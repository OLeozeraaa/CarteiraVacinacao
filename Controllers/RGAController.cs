using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using carteiravacina.Models;
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

        /* [HttpPost("Add")]
        public async Task<IActionResult> AdicionarCarteira(Animal animal)
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
        } */

        public async Task<IActionResult> ListarAsync()
        {
            try
            {
                List<Animal> animal = await _context.Animal.ToListAsync(); 
                return Ok(animal);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                Animal al = await _context.Animal
                    .Include(ia => ia.IdAnimal)
                    .Include(nm => nm.Nome)
                    .Include(dt => dt.dtNascimento)
                    .Include(pl => pl.Pelagem)
                    .Include(rga => rga.IdRGA)
                    .Include(ps => ps.peso)
                    .FirstOrDefaultAsync(pBusca => pBusca.IdAnimal == id);

                return Ok(al);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

   }
}