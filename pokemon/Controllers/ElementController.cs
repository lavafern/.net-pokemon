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

            SuccessDto<ICollection<ElementDto>> result = new SuccessDto<ICollection<ElementDto>>
            {
                Data = elemets
            };

            return Ok(result);
        }

        [HttpGet("{elementId}")]
        [ProducesResponseType(200)]
        public IActionResult GetPokemonByElement(int elementId)
        {
            var checkElement = _elementRepository.IsElementExist(elementId);


            var pokemons = _elementRepository.GetPokemonByElements(elementId);

            if (!checkElement) return NotFound();


            if (!ModelState.IsValid)
            {
                Console.WriteLine("model state not valid");

                return BadRequest();
            }

            SuccessDto<ICollection<ElementOnPokemonDto>> result = new SuccessDto<ICollection<ElementOnPokemonDto>>
            {
                Data = pokemons
            };

            if (pokemons.ToList().Count < 1) return BadRequest();

            return Ok(result);
        }

        
    }
}
