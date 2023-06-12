using MyVid.Core.Models;
using MyVid.Core.Repositories;

namespace MyVid.Data.Repositories
{
    public class ActorRepository : Repository<Actor>, IActorRepository
    {
        ApplicationDbContext _context;
        public ActorRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
