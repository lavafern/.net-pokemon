using pokemon.Data;
using pokemon.Interfaces;

namespace pokemon.Repository
{
    public class OwnerRepository : OwnerInterface
    {
        private readonly ApiDbContext _context;
        public OwnerRepository(ApiDbContext context)
        {
            _context = context;
        }

        public bool IsOwnerExist(int  ownerId)
        {
            return _context.Owners.Any(o => o.Id == ownerId);
        }
    }
}
