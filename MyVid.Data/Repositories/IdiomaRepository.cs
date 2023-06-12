using MyVid.Core.Models;
using MyVid.Core.Repositories;

namespace MyVid.Data.Repositories
{
    public class IdiomaRepository : Repository<Idioma>, IIdiomaRepository
    {
        ApplicationDbContext _context;
        public IdiomaRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
