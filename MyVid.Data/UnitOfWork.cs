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
        private IActorRepository _actorRepository;
        private IComentarioRepository _comentarioRepository;
        private IEpisodioRepository _episodioRepository;
        private IGeneroRepository _generoRepository;
        private IIdiomaRepository _idiomaRepository;
        private ISerieRepository _serieRepository;
        private ITemporadaRepository _temporadaRepository;
        private IUsuarioRepository _usuarioRepository;
        private IValoracionRepository _valoracionRepository;


        // Otros repositorios

        public IPeliculaRepository PeliculaRepository => _peliculaRepository ??= new PeliculaRepository(_context);
        public IContenidoRepository ContenidoRepository => _contenidoRepository ??= new ContenidoRepository(_context);
        public IActorRepository ActorRepository => _actorRepository ??= new ActorRepository(_context);  
        public IComentarioRepository ComentarioRepository => _comentarioRepository ??= new ComentarioRepository(_context);
        public IEpisodioRepository EpisodioRepository => _episodioRepository ??= new EpisodioRepository(_context);
        public IGeneroRepository GeneroRepository => _generoRepository ??= new GeneroRepository(_context);
        public IIdiomaRepository IdiomaRepository => _idiomaRepository ??= new IdiomaRepository(_context);
        public ISerieRepository SerieRepository => _serieRepository ??= new SerieRepository(_context);
        public ITemporadaRepository TemporadaRepository => _temporadaRepository ??= new TemporadaRepository(_context);
        public IUsuarioRepository UsuarioRepository =>_usuarioRepository ??= new UsuarioRepository(_context);
        public IValoracionRepository ValoracionRepository => _valoracionRepository ??= new ValoracionRepository(_context);
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


