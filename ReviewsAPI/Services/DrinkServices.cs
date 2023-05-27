using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReviewsAPI.Data;
using ReviewsAPI.Dto;
using ReviewsAPI.Models;

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

            return Ok(_context.Reviews.Where(p => p.DrinkId == id).ToList());
        }

    }
}
