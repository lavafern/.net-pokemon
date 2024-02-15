using Microsoft.AspNetCore.Mvc;
using pokemon.Interfaces;
using pokemon.Models;
using pokemon.Models.dto;
using pokemon.Repository;
using System.Text.Json;

namespace pokemon.Controllers
{
    [Route("/v1/pokemons")]
    [ApiController]
    public class PokemonController : ControllerBase
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
            ICollection<pokemonGetAllDto> pokemons = _pokemonReposetory.GetPokemons();
            if (!ModelState.IsValid) return BadRequest(ModelState);

            SuccessDto<ICollection<pokemonGetAllDto>> result = new SuccessDto<ICollection<pokemonGetAllDto>>
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

        [HttpPut("{pokeId}/{ownerId}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult EditPokemon(int pokeId,int ownerId, [FromBody] AddPokemonDto pokemonData)
        {
            if (pokemonData == null) return BadRequest();
            if (pokeId == null) return BadRequest();

            Pokemon editedPokemon = _pokemonReposetory.EditPokemon(pokeId, pokemonData, ownerId,pokemonData.elementIds);

            SuccessDto<Pokemon> result = new SuccessDto<Pokemon>
            {
                Data = editedPokemon
            };

            Console.WriteLine("Console loggin object :");
            Console.WriteLine(JsonSerializer.Serialize(editedPokemon));

            return Ok(result);
        }


        [HttpDelete("{pokeId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult deletePokemon(int pokeId)
        {
            _pokemonReposetory.DeletePokemon(pokeId);

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok();
        }


    }
}
