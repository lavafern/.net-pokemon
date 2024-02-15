using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

            Console.WriteLine("poks :");
            Console.WriteLine(newReview.ToString());

            SuccessDto<ReviewOnPokemon> result = new SuccessDto<ReviewOnPokemon>()
            {
                Data = newReview
            };

            //var res = JsonConvert.SerializeObject(result, Formatting.Indented,
            //            new JsonSerializerSettings
            //            {
            //                PreserveReferencesHandling = PreserveReferencesHandling.Objects
            //            });



            return Ok(result);
        }
    }
}
