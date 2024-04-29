using Fit.Application.Abstractions.Services;
using Fit.Application.DTOs.Basket;
using Fit.Domain.Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class BasketCaloriesController : ControllerBase
    {
        readonly IBasketCalorieService _basketCalorieService;

        public BasketCaloriesController(IBasketCalorieService basketCalorieService)
        {
            _basketCalorieService = basketCalorieService;
        }
        [HttpGet]
        public async Task<IActionResult> GetBasketItems()
        {
            BasketItemDto items = await _basketCalorieService.GetBasketItemsAsync();
            return Ok(items);
        }

        [HttpPost]
        public async Task<IActionResult> AddItemToBasketCalorie(AddToBasketRequest request)
        {
            await _basketCalorieService.AddBasketItemToBasketCalorieAsync(request.NutrientId, request.Measure);
            return Ok();
            
        }
        [HttpPut]
        public async Task<IActionResult> UpdateMeasure([FromBody]UploadMeasureDto request)
        {
            await _basketCalorieService.UpdateMeasureAsync(request.BasketItemId, request.Measure);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBasketItem(string basketItemId)
        {
            await _basketCalorieService.RemoveBasketItemAsync(basketItemId);
            return Ok();
        }
    }
}
 