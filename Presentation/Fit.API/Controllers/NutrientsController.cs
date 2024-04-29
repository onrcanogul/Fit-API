using Fit.Application.Abstractions.Services;
using Fit.Application.DTOs.Food;
using Fit.Application.DTOs.Requests.Food;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NutrientsController : ControllerBase
    {
        private readonly INutrientService _nutrientService;

        public NutrientsController(INutrientService nutrientService)
        {
            _nutrientService = nutrientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetFoodsForCategory([FromQuery] GetFoodsRequest request)
        {
            ListNutrientsDto foods = await _nutrientService.GetNutrientsForCategoryAsync(request.Page, request.Size, request.CategoryId);
            return Ok(foods);
        }
        [HttpGet("all-nutrients")]
        public async Task<IActionResult> GetFoods([FromQuery] int page,int size)
        {
          ListNutrientsDto nutrients =  await _nutrientService.GetNutrientsAsync(page, size);
            return Ok(nutrients);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFoodById(string id)
        {
            NutrientDto food = await _nutrientService.GetNutrientByIdAsync(id);
            return Ok(food);
        }
        [HttpPost]
        public async Task<IActionResult> CreateNutrient([FromBody]NutrientDto request)
        {
            await _nutrientService.CreateNutrientAsync(request);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateNutrient(UpdateNutrientDto request)
        {
            await _nutrientService.UpdateNutrientAsync(request);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteNutrient(string id)
        {
            await _nutrientService.DeleteNutrientAsync(id);
            return Ok();
        }
    }
}
