namespace pokemon.Models
{
    public class ElementOnPokemon
    {
        public int PokemonId { get; set; }
        public  Pokemon Pokemon { get; set; }
        public int ElementId { get; set; }
        public Element Element { get; set; }

    }
}
