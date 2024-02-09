using pokemon.Data;
using pokemon.Interfaces;
using pokemon.Models;
using pokemon.Models.dto;

namespace pokemon.Repository
{
    public class ElementRepository : ElementInterface
    {
        private readonly ApiDbContext _context;
        public ElementRepository(ApiDbContext context)
        {
            _context = context;
        }

        public ICollection<ElementDto> GetAllElements()
        {
            return _context
                .Elements
                .Select(e => new ElementDto
                {
                    Id = e.Id,
                    Name = e.Name
                })
                .OrderByDescending(e => e.Id)
                .ToList();
        }

        public bool IsElementExist(int id)
        {
            return _context.Elements.Any(e => e.Id == id);
        }

        public ICollection<ElementOnPokemonDto> GetPokemonByElements(int elementId) {


            return _context.ElementOnPokemons
                .Where(e => e.ElementId == elementId)
                .Join(_context.Pokemons,
                 e => e.PokemonId,
                 p => p.Id,
                 (e, p) => new 
                 {
                     Id = p.Id,
                     Name = p.Name,
                     elementId = e.ElementId

                 })
                .Join(_context.Elements,
                et => et.elementId,
                ep => ep.Id,
                (et,ep) => new ElementOnPokemonDto
                {
                    Id = et.Id,
                    Name = et.Name,
                    elementId = et.elementId,
                    elementName = ep.Name
                })
                .ToList();
        }
    }
}
