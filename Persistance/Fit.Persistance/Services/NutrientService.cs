using Fit.Application.Abstractions.Services;
using Fit.Application.DTOs.Food;
using Fit.Application.Repositories.Category;
using Fit.Application.Repositories.Food;
using Fit.Domain.Entites;
using Fit.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fit.Persistance.Services
{
    public class NutrientService : INutrientService
    {
        readonly INutrientReadRepository _nutrientReadRepository;
        readonly INutrientWriteRepository _nutrientWriteRepository;
        readonly ICategoryWriteRepository _categoryWriteRepository;
        readonly ICategoryReadRepository _categoryReadRepository;  

        public NutrientService(INutrientWriteRepository nutrientWriteRepository, INutrientReadRepository nutrientReadRepository, ICategoryReadRepository categoryReadRepository, ICategoryWriteRepository categoryWriteRepository, ApplicationDbContext context)
        {
            _nutrientWriteRepository = nutrientWriteRepository;
            _nutrientReadRepository = nutrientReadRepository;
            _categoryReadRepository = categoryReadRepository;
            _categoryWriteRepository = categoryWriteRepository;
            
        }

        public async Task CreateNutrientAsync(NutrientDto food)
        {
            await _nutrientWriteRepository.AddAsync(new()
            {
                Fat = food.Fat,
                Name = food.Name,
                Calorie = food.Calorie,
                Carbohydrate = food.Carbohydrate,
                Protein = food.Protein,
                Id = Guid.NewGuid()
            });
            await _nutrientWriteRepository.SaveAsync();
        }

        public async Task DeleteNutrientAsync(string id)
        {
            await _nutrientWriteRepository.RemoveAsync(id);
            await _nutrientWriteRepository.SaveAsync();
        }

        public async Task<NutrientDto> GetNutrientByIdAsync(string id)
        {
            Nutrient nutrient = await _nutrientReadRepository.GetByIdAsync(id);
            return new()
            {
                Id = nutrient.Id,
                Calorie = nutrient.Calorie,
                Carbohydrate = nutrient.Carbohydrate,
                Fat = nutrient.Fat,
                Protein = nutrient.Protein,
                Name = nutrient.Name,
            };
        }

        public async Task<ListNutrientsDto> GetNutrientsAsync(int page, int size)
        {
            var query = _nutrientReadRepository.Table.Include(n => n.Categories);
            var datas = await query.Skip(page * size).Take(size).ToListAsync();

            var newDatas = datas.Select(d => new
            {
                Calorie = d.Calorie,
                Carbohydrate = d.Carbohydrate,
                Fat = d.Fat,
                Protein = d.Protein,
                Name = d.Name,
                Id = d.Id,
                Categories = d.Categories
            }).ToList();

            return new()
            {
                Foods = newDatas,
                TotalCount = query.Count(),
            };


        }

        public async Task<ListNutrientsDto> GetNutrientsForCategoryAsync(int page, int size, string? categoryId)
        {
            var query = _categoryReadRepository.Table.Include(n => n.Nutrients).ThenInclude(n => n.Categories).AsQueryable();
            if(categoryId != null)
            {
                query = query.Where(c => c.Id == Guid.Parse(categoryId));
            }
            List<Category>? categories = await query.ToListAsync();

            var nutrients = categories
            .SelectMany(c => c.Nutrients)
            .GroupBy(n => n.Id) // Besin maddelerini ID'lerine göre grupla
            .Select(group => group.First()) // Her grubun ilk elemanını alarak yinelenenleri kaldır
            .Select(n => new
             {
                Id = n.Id,
                Name = n.Name,
                Fat = n.Fat,
                Protein = n.Protein,
                Carbohydrate = n.Carbohydrate,
                Calorie = n.Calorie,
                Categories = n.Categories
             });
            var _foods = nutrients.Skip(page * size).Take(size).ToList();
            return new()
            {
                Foods = _foods,
                TotalCount = nutrients.Count()
            };
        }

        public async Task UpdateNutrientAsync(UpdateNutrientDto food)
        {
            _nutrientWriteRepository.Update(new() 
            { 
                Calorie = food.Calorie,
                Fat = food.Fat,
                Protein = food.Protein,
                Carbohydrate = food.Carbohydrate,
                Name = food.Name,
                Id = Guid.Parse(food.Id),

            });
            await _nutrientWriteRepository.SaveAsync();
        }
    }
}
