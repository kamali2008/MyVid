using MyVid.Core.Models;
using MyVid.Core.Repositories;

namespace MyVid.Data.Repositories
{
    public class TemporadaRepository : Repository<Temporada>, ITemporadaRepository
    {
        ApplicationDbContext _context;
        public TemporadaRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
