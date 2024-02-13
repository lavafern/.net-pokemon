using pokemon.Data;
using pokemon.Interfaces;
using pokemon.Models;
using pokemon.Models.dto;

namespace pokemon.Repository
{
    public class ReviewRepository : ReviewInterface
    {
        private readonly ApiDbContext _context;
        private readonly ReviewerInterface _reviewerRepository;
        public ReviewRepository(ApiDbContext context,ReviewerInterface reviewerRepository)
        {
            _context = context;
            _reviewerRepository = reviewerRepository;
        }

        public ReviewOnPokemon AddReview(AddReviewDto reviewData)
        {
            try
            {

                ReviewOnPokemon newReview = new ReviewOnPokemon
                {
                    Rate = reviewData.Rate,
                    Content = reviewData.Content,
                    Reviewer = new Reviewer
                    {
                        Name = reviewData.ReviewerName
                    },
                    PokemonId = reviewData.PokemonId
                };

                _context.Reviews.Add(newReview);
                _context.SaveChanges();

                return newReview;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

                throw new Exception();
            }
        }

    }
}
