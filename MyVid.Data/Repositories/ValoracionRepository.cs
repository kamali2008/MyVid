using MyVid.Core.Models;
using MyVid.Core.Repositories;

namespace MyVid.Data.Repositories
{
    public class ValoracionRepository : Repository<Valoracion>, IValoracionRepository
    {
        ApplicationDbContext _context;
        public ValoracionRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
