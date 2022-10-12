using System.Linq;
using System.Threading.Tasks;
using carteiravacina.Models;
using CarteiraVacina_BackEnd.Data;
using Microsoft.EntityFrameworkCore;

namespace CarteiraVacinacao.Data
{
    public class Repository : IRepository
    {
       private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

    }
}