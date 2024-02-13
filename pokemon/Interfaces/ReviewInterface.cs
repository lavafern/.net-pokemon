using pokemon.Models;
using pokemon.Models.dto;

namespace pokemon.Interfaces
{
    public interface ReviewInterface
    {
        ReviewOnPokemon AddReview(AddReviewDto reviewData); 
    }
}
