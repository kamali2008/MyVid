using MyVid.Core.Models;

namespace MyVid.Core.Repositories
{
    public interface IPeliculaRepository : IRepository<Pelicula>
    {
        Task<IEnumerable<Pelicula>> GetPeliculasByGeneroAsync(int generoId);
        Task<IEnumerable<Pelicula>> GetPeliculasByActorAsync(int actorId);
        Task<Pelicula> GetByIdAsync(int id);
        // Otros métodos específicos de Película
    }
}
