using Microsoft.AspNetCore.Mvc;
using pokemon.Interfaces;
using pokemon.Models;
using pokemon.Models.dto;
using pokemon.Repository;

namespace pokemon.Controllers
{
    [Route("/v1/pokemons")]
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
            ICollection<pokemonDto> pokemons = _pokemonReposetory.GetPokemons();
            if (!ModelState.IsValid) return BadRequest(ModelState);

            SuccessDto<ICollection<pokemonDto>> result = new SuccessDto<ICollection<pokemonDto>>
            {
                Data = pokemons
            };

            return Ok(result);

        }

        [HttpGet("{pokeId}")]
        [ProducesResponseType(200, Type = typeof(SuccessDto<Pokemon>))]
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

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(SuccessDto<Pokemon>))]
        public IActionResult AddPokemon([FromQuery] int ownerId, [FromBody] AddPokemonDto pokemonData)
        {
            Pokemon newPokemon = _pokemonReposetory.AddPokemon(pokemonData, ownerId, pokemonData.elementIds);

            if (!ModelState.IsValid) return BadRequest(ModelState);

            SuccessDto<Pokemon> result = new SuccessDto<Pokemon>
            {
                Data = newPokemon
            };


            return Ok("good");

        }
        
    }
}
