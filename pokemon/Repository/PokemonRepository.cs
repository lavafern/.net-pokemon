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
            return _context.Pokemons.Select(p => new pokemonDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                BirthDate = p.BirthDate,
                Power = p.Power,

            }).ToList();
           
        }

        public Pokemon GetPokemonById(int id)
        {
                return _context.Pokemons.Where(p => p.Id == id).First();
        }

        public Pokemon GetPokemonByName(string name)
        {
            return _context.Pokemons.Where(p => p.Name == name).First();
        }

        public bool PokemonIsExist(int id) 
        {
            return _context.Pokemons.Any(p => p.Id == id);
        }
    }
}
