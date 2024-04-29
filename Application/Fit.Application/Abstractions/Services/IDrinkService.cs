using Fit.Application.DTOs.Drink;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fit.Application.Abstractions.Services
{
    public interface IDrinkService
    {
        Task<ListDrinksDto> GetDrinksAsync(int page, int size);
        Task<DrinkDto> GetDrinkByIdAsync(string id);
        Task CreateDrinkAsync(DrinkDto drink);
        Task UpdateDrinkAsync(UpdateDrinkDto drink);
        Task RemoveDrinkAsync(string id);
    }
}
