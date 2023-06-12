using MyVid.Core.Models;
using MyVid.Core.Repositories;

namespace MyVid.Data.Repositories
{
    public class ComentarioRepository : Repository<Comentario>, IComentarioRepository
    {
        ApplicationDbContext _context;
        public ComentarioRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
