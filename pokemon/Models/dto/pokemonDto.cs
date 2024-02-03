namespace pokemon.Models.dto
{
    public class pokemonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime BirthDate { get; set; }
        public int Power { get; set; }
        public ICollection<OwnerOnPokemon> OwnerOnPokemons { get; set; }
        public ICollection<ElementOnPokemon> ElementOnPokemons { get; set; }
        public ICollection<ReviewOnPokemon> ReviewOnPokemons { get; set; }
    }
}
