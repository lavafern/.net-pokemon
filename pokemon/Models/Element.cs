using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;

namespace pokemon.Models
{
    [Index(nameof(Name), IsUnique =true)]
    public class Element
    {
        public int Id { get; set; }


        public string Name { get; set; }

        public ICollection<ElementOnPokemon> ElementOnPokemons { get; set; } 
    }
}
