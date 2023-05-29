using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReviewsAPI.Data;
using ReviewsAPI.Dto;
using ReviewsAPI.Models;
using ReviewsAPI.Services;
using System.Collections;

namespace ReviewsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewerController : ControllerBase
    {
        private readonly ReviewerServices _ReviewerServices;

        public ReviewerController(ReviewerServices reviewerServices)
        {
            _ReviewerServices = reviewerServices;
        }


        [HttpGet]  // Done
        public async Task<ActionResult<ReviewerDto>> GetAll()
        {
            return await _ReviewerServices.GetReviewers();
        }



        [HttpGet("id/{id}")]  // Done
        public async Task<ActionResult<ReviewerDto>> GetById(int id)
        {
            return await _ReviewerServices.GetById(id);
        }



        [HttpGet("id/reviews/{id}")]  // Done
        public async Task<ActionResult<ReviewerDto>> GetReviews(int id)
        {
            return await _ReviewerServices.GetReviews(id);
        }



        [HttpGet("fullname/{firstname},{lastname}")]  // Done
        public async Task<ActionResult<ReviewerDto>> GetByFullName(string firstname, string lastname)
        {
            return await _ReviewerServices.GetByFullName(firstname, lastname);
        }



        [HttpPost]  // Done
        public async Task<ActionResult<ReviewerDto>> CreateNewReviewer(ReviewerDtoAdd NewReviewer)
        {
            return await _ReviewerServices.AddReviewer(NewReviewer);
        }



        [HttpPut("edit/{id}")]  // Done
        public async Task<ActionResult<ReviewerDto>> EditReviewer(int id, ReviewerDtoAdd editReviewer)
        {
            return await _ReviewerServices.EditReviewer(id, editReviewer);
        }



        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<ReviewerDto>> DeleteReviewer(int id)
        {
            return await _ReviewerServices.DeleteReviewer(id);
        }
    }
}
