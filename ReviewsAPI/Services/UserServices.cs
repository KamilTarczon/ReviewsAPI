using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using ReviewsAPI.Data;
using ReviewsAPI.Dto;
using ReviewsAPI.Models;

namespace ReviewsAPI.Services
{
    public class ReviewerServices : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ReviewerServices(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        async public Task<bool> UserExistById(int id)
        {
            return _context.Reviewers.Any(p => p.id == id);
        }

        async public Task<bool> UserExistByFullName(string firstname, string lastname)
        {
            return _context.Reviewers.Any(p => p.Firstname == firstname && p.Lastname == lastname);
        }

        async public Task<ActionResult<ReviewerDto>> GetReviewers()
        {
            return Ok(_mapper.Map<List<ReviewerDto>>(_context.Reviewers));
        }

        async public Task<ActionResult<ReviewerDto>> GetById(int id)
        {
            if (!await UserExistById(id))
                return NotFound("Nie istnieje recenzja o takim ID");

            return Ok(_mapper.Map<List<ReviewerDto>>(_context.Reviewers.Where(p => p.id == id)));
        }

        async public Task<ActionResult<ReviewerDto>> GetByFullName(string firstname, string lastname)
        {
            if (!await UserExistByFullName(firstname, lastname))
                return NotFound("Nie istnieje recenzja o takim ID");

            return Ok(_mapper.Map<List<ReviewerDto>>(_context.Reviewers.Where(p => p.Firstname == firstname && p.Lastname == lastname).FirstOrDefault()));
        }

        async public Task<ActionResult<ReviewerDto>> AddReviewer(ReviewerDtoAdd CreateDto)
        {
            User newReviewer = new(CreateDto.Firstname, CreateDto.Lastname);
            await _context.Reviewers.AddAsync(newReviewer);
            await _context.SaveChangesAsync();
            return await GetReviewers();
        }

        async public Task<ActionResult<ReviewerDto>> EditReviewer(int id, ReviewerDtoAdd request)
        {
            if (!await UserExistById(id))
                return NotFound("Nie istnieje recenzent z takim id");

            var reviewerToUpdate = _context.Reviewers.Find(id);
            reviewerToUpdate.Firstname = request.Firstname;
            reviewerToUpdate.Lastname = request.Lastname;
            await _context.SaveChangesAsync();

            return await GetReviewers();
        }

        async public Task<ActionResult<ReviewerDto>> DeleteReviewer(int id)
        {
            if (!await UserExistById(id))
                return NotFound("Nie istnieje recenzent z takim id");

            var reviewerToDelete = _context.Reviewers.Find(id);
            _context.Reviewers.Remove(reviewerToDelete);
            await _context.SaveChangesAsync();
            return await GetReviewers();
        }

        async public Task<ActionResult<ReviewerDto>> GetReviews(int id)
        {
            if (!await UserExistById(id))
                return NotFound();

            var reviewer = _context.Reviewers.Where(i => i.id == id).ToList();

            var reviewerDtos = reviewer.Select(d => new ReviewerReviewDto
            {
                id = d.id,
                Firstname = d.Firstname,
                Lastname = d.Lastname,
                Review = _context.Reviews.Where(s => s.ReviewerId == id).Select(s => new ReviewDto
                {
                    id = s.id,
                    Title = s.Title,
                    Text = s.Text,
                    Rating = s.Rating
                }).ToList()
            }).ToList();

            return Ok(reviewerDtos);
        }
    }
}
