using Microsoft.EntityFrameworkCore;
using MyVid.Core.Models;
using MyVid.Core.Repositories;

namespace MyVid.Data.Repositories
{
    public class PeliculaRepository : Repository<Pelicula>, IPeliculaRepository
    {
        ApplicationDbContext _context;
        public PeliculaRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pelicula>> GetPeliculasByGeneroAsync(int generoId)
        {
            return await _context.Peliculas
                .Where(p => p.Contenido.ContenidoGeneros.Any(cg => cg.GeneroID == generoId))
                .ToListAsync();
        }

        public async Task<IEnumerable<Pelicula>> GetPeliculasByActorAsync(int actorId)
        {
            return await _context.Peliculas
                .Where(p => p.Contenido.ContenidoActores.Any(ca => ca.ActorID == actorId))
                .ToListAsync();
        }

        public async Task<Pelicula> GetByIdAsync(int id)
        {
            return await _context.Peliculas
                .Include(p => p.Contenido)
                .FirstOrDefaultAsync(p => p.ID == id);
        }
        // Implementación de otros metodos especificos de Pelicula
    }
}
