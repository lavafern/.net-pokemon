using System.Text.Json.Serialization;

namespace pokemon.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime BirthDate { get; set; }
        public int Power {  get; set; }
        [JsonIgnore]
        public ICollection<OwnerOnPokemon> OwnerOnPokemons { get; set; }
        [JsonIgnore]
        public ICollection<ElementOnPokemon> ElementOnPokemons { get; set; }
        [JsonIgnore]
        public ICollection<ReviewOnPokemon> ReviewOnPokemons { get; set; }

        
    }
}
