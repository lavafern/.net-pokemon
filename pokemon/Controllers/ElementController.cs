using Microsoft.AspNetCore.Mvc;
using pokemon.Models.dto;
using pokemon.Repository;
using pokemon.Interfaces;

namespace pokemon.Controllers
{
    [Route("/v1/elements")]
    [ApiController]
    public class ElementController : Controller
    {
        private readonly ElementInterface _elementRepository;

        public ElementController(ElementInterface elementRepository) {
            _elementRepository = elementRepository;
        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<ElementDto>))]
        public IActionResult GetAllElements()
        {
            var elemets = _elementRepository.GetAllElements();

            if (!ModelState.IsValid)
            {
                Console.WriteLine("model state not valid");

                return BadRequest();
            }

            return Ok(elemets);
        }

        [HttpGet("{elementId}")]
        [ProducesResponseType(200)]
        public IActionResult GetPokemonByElement(int elementId)
        {
            var pokemons = _elementRepository.GetPokemonByElements(elementId);

            if (!ModelState.IsValid)
            {
                Console.WriteLine("model state not valid");

                return BadRequest();
            }

            return Ok(pokemons);
        }

        
    }
}
