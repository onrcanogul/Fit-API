using Fit.Application.Abstractions.Services;
using Fit.Application.DTOs;
using Fit.Application.DTOs.Category;
using Fit.Application.Repositories.Category;
using Fit.Application.Repositories.Food;
using Fit.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fit.Persistance.Services
{
    public class CategoryService : ICategoryService
    {
        readonly ICategoryReadRepository _categoryReadRepository;
        readonly ICategoryWriteRepository _categoryWriteRepository;
        readonly INutrientReadRepository _nutrientReadRepository;

        public CategoryService(ICategoryReadRepository categoryReadRepository, ICategoryWriteRepository categoryWriteRepository, INutrientReadRepository nutrientReadRepository)
        {
            _categoryReadRepository = categoryReadRepository;
            _categoryWriteRepository = categoryWriteRepository;
            _nutrientReadRepository = nutrientReadRepository;
        }

        public async Task AddNutrientToCategory(string categoryId, string nutrientId)
        {
            var category = await _categoryReadRepository.Table.Include(c => c.Nutrients).FirstOrDefaultAsync(x => x.Id == Guid.Parse(categoryId));
            var nutrient = await _nutrientReadRepository.GetByIdAsync(nutrientId);
            category.Nutrients.Add(nutrient);
            await _categoryWriteRepository.SaveAsync();

        }

        public async Task CreateCategoryAsync(CreateCategoryDto category)
        {
            await _categoryWriteRepository.AddAsync(new() { Id = Guid.NewGuid(), Name = category.Name});
            await _categoryWriteRepository.SaveAsync();
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _categoryWriteRepository.RemoveAsync(id);
            await _categoryWriteRepository.SaveAsync();

        }

        public async Task<ListDto> GetCategoriesAsync(int page, int size)
        {
            var query = _categoryReadRepository.Table.Include(c => c.Nutrients);
            var datas = await query.Skip(page * size).Take(size).ToListAsync();
            var newDatas = datas.Select(d => new
            {
                Id = d.Id.ToString(),
                Name = d.Name,
                Nutrients = d.Nutrients,
            });
            return new()
            {
                TotalCount = query.Count(),
                Entity = newDatas
            };
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(string id)
        {
            Category? category = await _categoryReadRepository.Table.Include(c => c.Nutrients).FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
            return new()
            {
                Name = category.Name,
                Nutrients = category.Nutrients
            };

        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto category)
        {
            _categoryWriteRepository.Update(new Category() { Name = category.Name, Id = Guid.Parse(category.Id) });
            await _categoryWriteRepository.SaveAsync();
        }
    }
}
