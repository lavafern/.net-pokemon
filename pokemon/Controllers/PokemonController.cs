using Microsoft.AspNetCore.Mvc;
using pokemon.Interfaces;
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
        [ProducesResponseType(200)]
        public IActionResult GetPokemons()
        {
            var pokemons = _pokemonReposetory.GetPokemons();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(pokemons);

        }

        [HttpGet("{pokeId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonById(int pokeId)
        {
            if (!_pokemonReposetory.PokemonIsExist(pokeId)) return NotFound("awawwa");

            var pokemon = _pokemonReposetory.GetPokemonById(pokeId);

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(pokemon);
        }

        //[HttpGet]
        //[ProducesResponseType(200)]
        //public ActionResult GetPokemons() {

        //    var pokemons = _pokemonReposetory.GetPokemons();

        //    if (!ModelState.IsValid) return BadRequest(ModelState);

        //    return Ok(pokemons);
        //}
    }
}
