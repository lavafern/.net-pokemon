namespace pokemon.Models
{
    public class ReviewOnPokemon
    {
        public int Id { get; set; }
        public int Rate { get; set; }
        public string Content { get; set; }
        public int ReviewerId { get; set; }
        public Reviewer Reviewer { get; set; }
        public int PokemonId { get; set; }
        public Pokemon Pokemon { get; set; }



    }
}
