using pokemon.Models;
using pokemon.Models.dto;

namespace pokemon.Interfaces
{
    public interface PokemonInterface
    {
        ICollection<pokemonDto> GetPokemons();
    }
}
