using Microsoft.AspNetCore.Mvc;
using pokemon.Interfaces;
using pokemon.Models;
using pokemon.Models.dto;
using pokemon.Repository;

namespace pokemon.Controllers
{
    [Route("/v1/pet")]
    [ApiController]
    public class PokemonController : Controller
    {
        private readonly PokemonInterface _pokemonReposetory;
        public PokemonController(PokemonInterface pokemonRepository)
        {
            _pokemonReposetory = pokemonRepository;
        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<pokemonDto>))]
        public IActionResult GetPokemons()
        {
            var pokemons = _pokemonReposetory.GetPokemons();
            if (!ModelState.IsValid) return BadRequest(ModelState);

            SuccessDto<pokemonDto> result = new SuccessDto<pokemonDto>
            {
                Data = pokemons
            };

            return Ok(result);

        }

        [HttpGet("{pokeId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonById(int pokeId)
        {
            if (!_pokemonReposetory.PokemonIsExist(pokeId)) return NotFound();

            var pokemon = _pokemonReposetory.GetPokemonById(pokeId);

            if (!ModelState.IsValid) return BadRequest(ModelState);

            SuccessDto<Pokemon> result = new SuccessDto<Pokemon>
            {
                Data = pokemon
            };

            return Ok(result);
        }
        
    }
}
