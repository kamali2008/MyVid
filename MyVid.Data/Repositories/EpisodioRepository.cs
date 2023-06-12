using MyVid.Core.Models;
using MyVid.Core.Repositories;

namespace MyVid.Data.Repositories
{
    public class EpisodioRepository : Repository<Episodio>, IEpisodioRepository
    {
        ApplicationDbContext _context;
        public EpisodioRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
