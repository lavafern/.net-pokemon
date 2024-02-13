using System.ComponentModel.DataAnnotations;

namespace pokemon.Models.dto
{
    public class AddReviewDto
    {
        [Range(1, 5)]
        public int Rate { get; set; }
        public string Content { get; set; }
        public string ReviewerName { get; set; }
        public int PokemonId { get; set; }
    }

}
