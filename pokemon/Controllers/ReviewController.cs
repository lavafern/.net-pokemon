using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pokemon.Interfaces;
using pokemon.Models;
using pokemon.Models.dto;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace pokemon.Controllers
{
    [Route("/v1/review")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly ReviewInterface _reviewInterface;

        public ReviewController(ReviewInterface reviewInterface)
        {
            _reviewInterface = reviewInterface;
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(string))]

        public IActionResult AddReview([FromBody] AddReviewDto reviewData)
        {
            ReviewOnPokemon newReview = _reviewInterface.AddReview(reviewData);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            
            SuccessDto<string> result = new SuccessDto<string>()
            {
                Data = JsonSerializer.Serialize(new
                {
                    rate = newReview.Rate,
                    content = newReview.Content,
                    reviewer = newReview.Reviewer.Name,
                    pokemon = newReview.PokemonId
                })
            };

            return Ok(result);
        }
    }
}
