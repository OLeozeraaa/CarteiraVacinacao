using System;
using System.Security.Claims;
using System.Threading.Tasks;
using carteiravacina.Models;
using CarteiraVacina_BackEnd.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace carteiravacina.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RGAController : ControllerBase
    {
        private readonly DataContext _context;

        public RGAController(DataContext context)
        {
            _context = context;
        }

    }
}