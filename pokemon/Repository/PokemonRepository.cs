using Microsoft.EntityFrameworkCore;
using pokemon.Data;
using pokemon.Interfaces;
using pokemon.Models;
using pokemon.Models.dto;

namespace pokemon.Repository
{
    public class PokemonRepository : PokemonInterface
    {
        private readonly ApiDbContext _context;
        public PokemonRepository(ApiDbContext context)
        {
            _context = context;   
        }

        public ICollection<pokemonDto> GetPokemons()
        {
            return _context.Pokemons.Select(p => new pokemonDto { }).ToList();
           
        }
    }
}
