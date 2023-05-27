using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReviewsAPI.Dto;
using ReviewsAPI.Models;
using ReviewsAPI.Services;

namespace ReviewsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly ReviewServices _ReviewServices;

        public ReviewController(ReviewServices Services)
        {
            _ReviewServices = Services;
        }



        [HttpGet("check/{id}")]  // Done
        public async Task<ActionResult<List<Review>>> GetAll(int id)
        {
            return await _ReviewServices.CheckReview(id);
        }



        [HttpPost]  // Done
        public async Task<ActionResult<ReviewDto>> CreateReview(ReviewDtoAdd createDto)
        {
            return await _ReviewServices.AddReview(createDto);
        }


        
        [HttpPut("assign/{idReview},{idReviewer},{idDrink}")]  // Chyba done?
        public async Task<ActionResult<Review>> AssignReview(int idReview, int idReviewer, int idDrink)
        {
            return await _ReviewServices.AssingReview(idReview, idReviewer, idDrink);   
        }



        [HttpGet("test/{value}")]  // Test
        public async Task<ActionResult<List<ReviewDto>>> RatingEqualsTo(int value)
        {
            return await _ReviewServices.RatingEqualsTo(value);
        }

    }
}
