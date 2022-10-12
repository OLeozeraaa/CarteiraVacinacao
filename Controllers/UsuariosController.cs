using System.Threading.Tasks;
using carteiravacina.Models;
using CarteiraVacina_BackEnd.Data;
using CarteiraVacinacao.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CarteiraVacinacao.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[Controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly  DataContext _context;

        private readonly IConfiguration _configuration;

        

        public UsuariosController(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

         // Método para verificar se um usuário já existe no banco de dados
        public async Task<bool> UsuarioExistente(string username)
        {
            if(await _context.Login.AnyAsync(x => x.username.ToLower() == username.ToLower()))
            {
                return true;
            }
            return false;
        }

        // Método para registrar um usuário, caso o username não exista no banco de dados
        [AllowAnonymous]
        [HttpPost("Registrar")]
        public async Task<IActionResult> RegistrarUsuario(Login user)
        {
            try
            {
                if(await UsuarioExistente(user.username))
                    throw new System.Exception("Nome de usuário já existente");
                
                Criptografia.CriarPasswordHash(user.PasswordString, out byte[] hash, out byte[] salt);
                user.PasswordString = string.Empty;
                user.PasswordHash = hash;
                user.PasswordSalt = salt;
                await _context.Login.AddAsync(user);
                await _context.SaveChangesAsync();

                return Ok(user.Id);
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Método para registrar um usuário, caso o username não exista no banco de dados
        /*[AllowAnonymous]
        [HttpPost("Registrar")]
        public async Task<IActionResult>RegistrarUsuario(Login user)
        {
            try
            {
                if(await UsuarioExistente(user.username))
                    throw new System.Exception("Nome de usuário já existente");
                
                Criptografia.CriarPasswordHash(user.PasswordString, out byte[] hash, out byte[] salt);
                user.PasswordString = string.Empty;
                user.PasswordHash = hash;
                user.PasswordSalt = salt;
                await _context.Login.AddAsync(user);
                await _context.SaveChangesAsync();

                return Ok(user.Id);
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }*/

        // Método para autenticar usuário por senha
        [AllowAnonymous]
        [HttpPost("Autenticar")]
        public async Task<IActionResult> AutenticarUsuario(Login credenciais)
        {
            try
            {
                Login usuario = await _context.Login
                    .FirstOrDefaultAsync(x => x.username.ToLower().Equals(credenciais.username.ToLower()));

                if (usuario == null)
                {
                    throw new System.Exception("Usuário não encontrado.");
                }
                else if(!Criptografia
                    .VerificarPasswordHash(credenciais.PasswordString, usuario.PasswordHash, usuario.PasswordSalt))
                {
                    throw new System.Exception("Senha incorreta.");
                }
                else
                {
                    _context.Login.Update(usuario);
                    await _context.SaveChangesAsync();
                    return Ok(usuario.Id);
                }
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("AlterarSenha")]
        public async Task<IActionResult> AlterarSenha(Login credenciais)
        {
            try
            {
                Login usuario = await _context.Login //Busca o usuário no banco através do login
                    .FirstOrDefaultAsync(x => x.username.ToLower().Equals(credenciais.username.ToLower()));

                if(usuario == null) //Se não achar nenhum usuário pelo login, retorna mensagem.
                    throw new System.Exception("Usuário não encontrado.");
                
                Criptografia.CriarPasswordHash(credenciais.PasswordString, out byte[] hash, out byte[] salt);
                usuario.PasswordHash = hash;
                usuario.PasswordSalt = salt;

                _context.Login.Update(usuario);
                int linhasAfetadas = await _context.SaveChangesAsync();
                return Ok(linhasAfetadas);

            }
            catch(System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Método para deletar usuários por ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Login uRemover = await _context.Login
                    .FirstOrDefaultAsync(u => u.Id == id);
                
                _context.Login.Remove(uRemover);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}