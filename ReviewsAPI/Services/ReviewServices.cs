﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReviewsAPI.Data;
using ReviewsAPI.Dto;
using ReviewsAPI.Models;

namespace ReviewsAPI.Services
{
    public class ReviewServices : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly DrinkServices _drinksServices;
        private readonly ReviewerServices _reviewerServices;

        public ReviewServices(DataContext context, IMapper mapper, DrinkServices drinkServices, ReviewerServices reviewerServices)
        {
            _context = context;
            _mapper = mapper;
            _reviewerServices = reviewerServices;
            _drinksServices = drinkServices;
        }

        async public Task<ActionResult<ReviewDto>> GetReviews()
        {
            return Ok(_mapper.Map<List<ReviewDto>>(_context.Reviews));
        }

        async public Task<ActionResult<ReviewDto>> AddReview(ReviewDtoAdd request)
        {
            Review newReview = new(request.Title, request.Text, request.Rating);
            await _context.Reviews.AddAsync(newReview);
            await _context.SaveChangesAsync();
            return await GetReviews();
        }

        async public Task<bool> ReviewExistByID(int id)
        {
            return _context.Reviews.Any(p => p.id == id);
        }

        async public Task<ActionResult<Review>> AssingReview(int idReview, int idReviewer, int idDrink)
        {
            if (!await ReviewExistByID(idReview))
                return BadRequest("Nie istnieje recenzja o takim Id!");

            if (!await _reviewerServices.ReviewerExistById(idReviewer))
                return BadRequest("Nie istnieje recenzant o takim Id!");

            if (!await _drinksServices.DrinkExistByID(idDrink))
                return BadRequest("Nie istnieje napój o takim Id!");

            Reviewer reviewer = _context.Reviewers.Where(p => p.id == idReviewer).FirstOrDefault(); // d
            Drink drink = _context.Drinks.Where(d => d.id == idDrink).FirstOrDefault(); // d
            Review review = _context.Reviews.Where(r => r.id == idReview).FirstOrDefault();

            review.Reviewer = reviewer;
            review.Drink = drink;
            _context.SaveChanges();

            return Ok("git jest");
        }

        async public Task<ActionResult<List<Review>>> CheckReview(int id)
        {
            Review review = await _context.Reviews.FindAsync(id);
            return Ok(review);
        }

    }
}
