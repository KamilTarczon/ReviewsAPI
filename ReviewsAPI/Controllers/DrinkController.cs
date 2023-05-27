using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReviewsAPI.Data;
using ReviewsAPI.Dto;
using ReviewsAPI.Models;
using ReviewsAPI.Services;

namespace ReviewsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrinkController : ControllerBase
    {
        private readonly DrinkServices _drinkServices;

        public DrinkController(DrinkServices Services)
        {
            _drinkServices = Services;
        }



        [HttpGet]  // Done
        public async Task<ActionResult<DrinkDto>> GetAll()  
        {
            return await _drinkServices.GetDrinks();
        } // Nienawidze cie mati za to że kazałes mi się bawić w Services :c    



        [HttpGet("name/{name}")]  // Done
        public async Task<ActionResult<DrinkDto>> GetByName(string name)  
        {
            return await _drinkServices.GetByName(name);  
        }



        [HttpGet("id/{ID}")]  // Done
        public async Task<ActionResult<DrinkDto>> GetByID(int ID)  
        {
            return await _drinkServices.GetByID(ID);
        }



        [HttpPost]  // Done
        public async Task<ActionResult<DrinkDto>> AddDrink([FromBody] DrinkDtoAdd createDTO)
        {
            return await _drinkServices.AddNewDrink(createDTO);
        }  // Jednak te services jest wygodne, dzięki mati że kazałeś mi się w to bawić.



        [HttpPut("edit/{id}")]  // Done
        public async Task<ActionResult<DrinkDto>> UpdateDrink(DrinkDtoAdd request, int id)
        {
            return await _drinkServices.EditDrink(request, id);
        }



        [HttpDelete("delete/{id}")] // Done
        public async Task<ActionResult<DrinkDto>> Delete(int id)
        {
            return await _drinkServices.DeleteDrink(id);
        }



        [HttpGet("check")]
        public async Task<ActionResult<Drink>> GetFullDrink()
        {
            return await _drinkServices.GetDrinkFull();
        }
    }
}

