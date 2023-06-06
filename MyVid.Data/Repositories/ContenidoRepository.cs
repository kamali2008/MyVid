using Microsoft.EntityFrameworkCore;
using MyVid.Core.Models;
using MyVid.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVid.Data.Repositories
{
    public class ContenidoRepository : Repository<Contenido>, IContenidoRepository
    {
        ApplicationDbContext _context;
        public ContenidoRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Contenido>> GetContenidosByTipoAsync(string tipo)
        {
            return await _context.Contenidos.Where(c => c.Tipo == tipo).ToListAsync();
        }

        public async Task<IEnumerable<Contenido>> GetContenidosByGeneroAsync(int generoId)
        {
            return await _context.Contenidos
                .Where(c => c.ContenidoGeneros.Any(cg => cg.GeneroID == generoId))
                .ToListAsync();
        }
    }
}
