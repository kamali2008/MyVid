using MyVid.Core.Models;
using MyVid.Core.Repositories;

namespace MyVid.Data.Repositories
{
    public class GeneroRepository : Repository<Genero>, IGeneroRepository
    {
        ApplicationDbContext _context;
        public GeneroRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
