using Microsoft.AspNetCore.Mvc;
using pokemon.Interfaces;
using pokemon.Repository;

namespace pokemon.Controllers
{
    [Route("/")]
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

        //[HttpGet]
        //[ProducesResponseType(200)]
        //public ActionResult GetPokemons() {

        //    var pokemons = _pokemonReposetory.GetPokemons();

        //    if (!ModelState.IsValid) return BadRequest(ModelState);

        //    return Ok(pokemons);
        //}
    }
}
