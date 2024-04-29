using Fit.Application.Abstractions.Services;
using Fit.Application.DTOs.Drink;
using Fit.Application.Repositories.Drink;
using Fit.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fit.Persistance.Services
{
    public class DrinkService : IDrinkService
    {
        readonly IDrinkReadRepository _drinkReadRepository;
        readonly IDrinkWriteRepository _drinkWriteRepository;
        public DrinkService(IDrinkReadRepository drinkReadRepository, IDrinkWriteRepository drinkWriteRepository)
        {
            _drinkReadRepository = drinkReadRepository;
            _drinkWriteRepository = drinkWriteRepository;
        }

        public async Task CreateDrinkAsync(DrinkDto drink)
        {
            await _drinkWriteRepository.AddAsync(new Domain.Entites.Drink
            {
                Fat = drink.Fat,
                Carbohydrate = drink.Carbohydrate,
                Protein = drink.Protein,
                Calorie = drink.Calorie,
                Measure = drink.Measure,
                Name = drink.Name,
                Id = Guid.NewGuid()
            });

            await _drinkWriteRepository.SaveAsync();
        }

        public async Task<DrinkDto> GetDrinkByIdAsync(string id)
        {
            Drink drink = await _drinkReadRepository.GetByIdAsync(id);
            return new()
            {
                Calorie = drink.Calorie,
                Measure = drink.Measure,
                Carbohydrate = drink.Carbohydrate,
                Fat = drink.Fat,
                Protein = drink.Protein,
                Name = drink.Name
            };
        }

        public async Task<ListDrinksDto> GetDrinksAsync(int page, int size)
        {
            var query = _drinkReadRepository.Table.Include(d => d.Categories);
            var datas = await query.Skip(page * size).Take(size).ToListAsync();

            var newDatas = datas.Select(drink => new
            {
                Calorie = drink.Calorie,
                Carbohydrate = drink.Carbohydrate,
                Fat = drink.Fat,
                Protein = drink.Protein,
                Name = drink.Name,
                Id = drink.Id.ToString(),
                Measure = drink.Measure
            });;

            return new()
            {
                Drinks = newDatas,
                TotalCount = query.Count()
            };
           
        }

        public async Task RemoveDrinkAsync(string id)
        {
            await _drinkWriteRepository.RemoveAsync(id);
            await _drinkWriteRepository.SaveAsync();
        }

        public async Task UpdateDrinkAsync(UpdateDrinkDto drink)
        {
            _drinkWriteRepository.Update(new()
            {
                Calorie = drink.Calorie,
                Carbohydrate = drink.Carbohydrate,
                Fat = drink.Fat,
                Id = Guid.Parse(drink.Id),
                Measure = drink.Measure,
                Name = drink.Name,
                Protein = drink.Protein
            });
            await _drinkWriteRepository.SaveAsync();
        }
    }
}
