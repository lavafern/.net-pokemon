namespace pokemon.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<OwnerOnPokemon> ownerOnPokemons {get; set;}
    }
}
