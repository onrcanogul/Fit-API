using Fit.Application.Abstractions.Services;
using Fit.Application.DTOs.Drink;
using Fit.Application.DTOs.Food;
using Fit.Application.DTOs.Requests.Food;
using Fit.Persistance.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrinksController : ControllerBase
    {
        private readonly IDrinkService _drinkService;

        public DrinksController(IDrinkService drinkService)
        {
            _drinkService = drinkService;
        }

        [HttpGet]
        public async Task<IActionResult> GetFoods([FromQuery] GetFoodsRequest request)
        {
            ListDrinksDto drinks = await _drinkService.GetDrinksAsync(request.Page, request.Size);
            return Ok(drinks);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFoodById(string id)
        {
            DrinkDto drink = await _drinkService.GetDrinkByIdAsync(id);
            return Ok(drink);
        }
        [HttpPost]
        public async Task<IActionResult> CreateFood([FromBody] DrinkDto request)
        {
            await _drinkService.CreateDrinkAsync(request);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFood(UpdateDrinkDto request)
        {
            await _drinkService.UpdateDrinkAsync(request);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteFood(string id)
        {
            await _drinkService.RemoveDrinkAsync(id);
            return Ok();
        }
    }
}
