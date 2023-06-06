using MyVid.Core.Repositories;

namespace MyVid.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IPeliculaRepository PeliculaRepository { get; }
        IContenidoRepository ContenidoRepository { get; }
        // Otros repositorios

        Task<int> SaveChangesAsync();
    }

}
