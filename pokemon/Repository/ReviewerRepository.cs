using Microsoft.EntityFrameworkCore.ChangeTracking;
using pokemon.Data;
using pokemon.Interfaces;
using pokemon.Models;

namespace pokemon.Repository
{
    public class ReviewerRepository : ReviewerInterface
    {
        private readonly ApiDbContext _context;
        public ReviewerRepository(ApiDbContext context)
        {
            _context = context;
        }

        public Reviewer AddReviewer(string name)
        {
            try
            {
                Reviewer reviewer = new Reviewer()
                {
                    Name = name
                };

                return reviewer;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception(ex.Message);
            }
        }
    }
}
