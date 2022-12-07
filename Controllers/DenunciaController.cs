using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using carteiravacina.Models;
using CarteiraVacina_BackEnd.Data;
using CarteiraVacinacao.Models;
using CarteiraVacinaca.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace carteiravacina.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DenunciaController : ControllerBase
    {
        private readonly DataContext _context;

        public DenunciaController(DataContext context)
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

        [HttpGet("ListarC")]


        public async Task<IActionResult> ListarAsyncC()
        {
            try
            {
                List<Animal> animais = await _context.Animal.ToListAsync(); 
                return Ok(animais);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ListarT")]
        public async Task<IActionResult> ListarAsyncT()
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

        [HttpPost("Salvar")]
        public async Task<IActionResult> Salvar(Desaparecido desaparecido)
        {
            try
            {
                await _context.Desaparecido.AddAsync(desaparecido);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ListarD")]
        public async Task<IActionResult> ListarAsyncD()
        {
            try
            {
                List<Desaparecido> desaparecido = await _context.Desaparecido.ToListAsync(); 
                return Ok(desaparecido);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddNoRegister")]
        public async Task<IActionResult> AdicionarNaoRegistrado(DesaparecidoSemRegistro desaparecido)
        {
            try
            {
                await _context.DesaparecidoSemRegistro.AddAsync(desaparecido);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("ListarDSR")]
        public async Task<IActionResult> ListarAsyncDSR()
        {
            try
            {
                List<DesaparecidoSemRegistro> desaparecido = await _context.DesaparecidoSemRegistro.ToListAsync(); 
                return Ok(desaparecido);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
  }