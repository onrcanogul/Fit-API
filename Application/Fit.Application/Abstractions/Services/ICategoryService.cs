using Fit.Application.DTOs;
using Fit.Application.DTOs.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fit.Application.Abstractions.Services
{
    public interface ICategoryService
    {
        Task<ListDto> GetCategoriesAsync(int page, int size);
        Task<CategoryDto> GetCategoryByIdAsync(string id);
        Task CreateCategoryAsync(CreateCategoryDto category);
        Task UpdateCategoryAsync(UpdateCategoryDto category);
        Task DeleteCategoryAsync(string id);
        Task AddNutrientToCategory(string categoryId, string nutrientId);
    }
}
