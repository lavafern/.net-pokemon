using Microsoft.AspNetCore.Server.IIS.Core;

namespace pokemon.Models
{
    public class Element
    {
        public int Id { get; set; }


        public string Name { get; set; }

        public ICollection<ElementOnPokemon> ElementOnPokemons { get; set; } 
    }
}
