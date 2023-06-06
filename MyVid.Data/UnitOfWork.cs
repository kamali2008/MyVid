using MyVid.Core;
using MyVid.Core.Repositories;
using MyVid.Data.Repositories;

namespace MyVid.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IPeliculaRepository _peliculaRepository;
        private IContenidoRepository _contenidoRepository;

        // Otros repositorios

        public IPeliculaRepository PeliculaRepository => _peliculaRepository ??= new PeliculaRepository(_context);
        public IContenidoRepository ContenidoRepository => _contenidoRepository ??= new ContenidoRepository(_context);
        // Propiedades para otros repositorios

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}


