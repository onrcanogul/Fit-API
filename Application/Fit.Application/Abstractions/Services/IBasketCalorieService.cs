using Fit.Application.DTOs.Basket;
using Fit.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fit.Application.Abstractions.Services
{
    public interface IBasketCalorieService
    {
        Task<BasketItemDto> GetBasketItemsAsync();
        Task AddBasketItemToBasketCalorieAsync(string nutrientId, float measure);
        Task UpdateMeasureAsync(string basketItemId, float measure);
        Task RemoveBasketItemAsync(string basketItemId);
    }
}
