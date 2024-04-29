using Fit.Application.Abstractions.Services;
using Fit.Application.DTOs;
using Fit.Application.DTOs.Category;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetCategories(int page, int size)
        {
            ListDto categories = await _categoryService.GetCategoriesAsync(page,size);
            return Ok(categories);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto category)
        {
            await _categoryService.CreateCategoryAsync(category);
            return Ok();
        }
        [HttpPost("add-to-category")]
        public async Task<IActionResult> AddNutrientToCategory(string categoryId, string nutrientId)
        {
            await _categoryService.AddNutrientToCategory(categoryId, nutrientId);
            return Ok();
        }
    }
}
