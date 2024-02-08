namespace pokemon.Models
{
    public class Reviewer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ReviewOnPokemon> ReviewOnPokemons { get; set;}
    }
}
