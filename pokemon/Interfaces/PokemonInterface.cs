using pokemon.Models;
using pokemon.Models.dto;

namespace pokemon.Interfaces
{
    public interface PokemonInterface
    {
        ICollection<pokemonDto> GetPokemons();

        Pokemon GetPokemonById(int id);
        Pokemon GetPokemonByName(string name);

        bool PokemonIsExist(int id);

        Pokemon AddPokemon(Pokemon pokemon, int ownerId, IEnumerable<int> elementIds);

        bool Save();
    }
}
