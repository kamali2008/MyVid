using MyVid.Core.Models;
using MyVid.Core.Repositories;

namespace MyVid.Data.Repositories
{
    public class SerieRepository : Repository<Serie>, ISerieRepository
    {
        ApplicationDbContext _context;
        public SerieRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
