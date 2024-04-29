using Fit.Application.DTOs.Food;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fit.Application.Abstractions.Services
{
    public interface INutrientService
    {
        Task<ListNutrientsDto> GetNutrientsAsync(int page, int size);
        Task<NutrientDto> GetNutrientByIdAsync(string id);
        Task<ListNutrientsDto> GetNutrientsForCategoryAsync(int page, int size, string? categoryId);
        Task CreateNutrientAsync(NutrientDto food);
        Task DeleteNutrientAsync(string id);
        Task UpdateNutrientAsync(UpdateNutrientDto food);
    }
}
