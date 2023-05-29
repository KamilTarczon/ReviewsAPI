using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReviewsAPI.Data;
using ReviewsAPI.Dto;
using ReviewsAPI.Models;
using System.Reflection;

namespace ReviewsAPI.Services
{
    public class DrinkServices : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public DrinkServices(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        async public Task<bool> DrinkExistByID(int id)
        {
            return _context.Drinks.Any(p => p.id == id);
        }

        async public Task<bool> DrinkExistByName(string name)
        {
            return _context.Drinks.Any(p => p.Name == name);
        }

        async public Task<ActionResult<DrinkDto>> GetDrinks()
        {
            return Ok(_mapper.Map<List<DrinkDto>>(_context.Drinks));
        }

        async public Task<ActionResult<Drink>> GetDrinkFull()
        {
            return Ok(_context.Drinks.ToArray());
        }

        async public Task<ActionResult<DrinkDto>> GetByName(string name)
        {
            if (!await DrinkExistByName(name))
                return NotFound("Nie istnieje napój o takiej nazwie");

            return Ok(_mapper.Map<List<DrinkDto>>(_context.Drinks.Where(p => p.Name == name).FirstOrDefault()));
        }
        async public Task<ActionResult<DrinkDto>> GetByID(int id)
        {
            if (!await DrinkExistByID(id))
                return NotFound("Nie istnieje napój o takim id");

            return Ok(_mapper.Map<List<DrinkDto>>(_context.Drinks.Where(p => p.id == id)));
        }

        async public Task<ActionResult<DrinkDto>> AddNewDrink(DrinkDtoAdd CreateDto)
        {
            Drink newDrink = new(CreateDto.Name);
            await _context.Drinks.AddAsync(newDrink);
            await _context.SaveChangesAsync();
            return await GetDrinks();
        }

        async public Task<ActionResult<DrinkDto>> EditDrink(DrinkDtoAdd request, int id)
        {
            if (!await DrinkExistByID(id))
                return NotFound("Nie istnieje drink z takim id");

            var drinkToUpdate = _context.Drinks.Find(id);
            drinkToUpdate.Name = request.Name;
            await _context.SaveChangesAsync();

            return await GetDrinks();
        }

        async public Task<ActionResult<DrinkDto>> DeleteDrink(int id)
        {
            if (!await DrinkExistByID(id))
                return NotFound("Nie istnieje drink z takim id");

            var drinkToUpdate = _context.Drinks.Find(id);
            _context.Drinks.Remove(drinkToUpdate);
            await _context.SaveChangesAsync();
            return await GetDrinks();
        }

        async public Task<ActionResult<List<ReviewDto>>> GetReviewOnDrink(int id)
        {
            if (!await DrinkExistByID(id))
                return NotFound();

            var drinks = _context.Drinks.Where(i => i.id == id).Include(d => d.Review).ToList();

            var drinkReviewDtos = drinks.Select(d => new DrinkReviewDto
            {
                id = d.id,
                Name = d.Name,
                Review = d.Review.Select(r => new ReviewDto
                {
                    id = r.id,
                    Title = r.Title,
                    Text = r.Text,
                    Rating = r.Rating
                }).ToList()
            }).ToList();

            return Ok(drinkReviewDtos);
        }
    }
}
