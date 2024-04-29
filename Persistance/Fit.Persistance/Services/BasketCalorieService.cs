using Fit.Application.Abstractions.Services;
using Fit.Application.DTOs.Basket;
using Fit.Application.Repositories.BasketCalorie;
using Fit.Application.Repositories.BasketItem;
using Fit.Domain.Entites;
using Fit.Domain.Entites.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fit.Persistance.Services
{
    public class BasketCalorieService : IBasketCalorieService
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly UserManager<AppUser> _userManager;
        readonly IBasketItemReadRepository _basketItemReadRepository;
        readonly IBasketItemWriteRepository _basketItemWriteRepository;
        readonly IBasketCalorieReadRepository _basketCalorieReadRepository;
        readonly IBasketCalorieWriteRepository _basketCalorieWriteRepository;

        public BasketCalorieService(IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager, IBasketItemReadRepository basketItemReadRepository, IBasketItemWriteRepository basketItemWriteRepository, IBasketCalorieReadRepository basketCalorieReadRepository, IBasketCalorieWriteRepository basketCalorieWriteRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _basketItemReadRepository = basketItemReadRepository;
            _basketItemWriteRepository = basketItemWriteRepository;
            _basketCalorieReadRepository = basketCalorieReadRepository;
            _basketCalorieWriteRepository = basketCalorieWriteRepository;
        }

        private async Task<BasketCalorie> activeUser()
        {
            var username = _httpContextAccessor.HttpContext?.User?.Identity?.Name;
            AppUser user = await _userManager.FindByNameAsync(username);
            BasketCalorie basket = await _basketCalorieReadRepository.GetSingleAsync(x => x.UserId == user.Id);
            if(basket == null)
            {
                await _basketCalorieWriteRepository.AddAsync(new BasketCalorie { Id = Guid.NewGuid(), UserId = user.Id });
                await _basketCalorieWriteRepository.SaveAsync();
                basket = await _basketCalorieReadRepository.Table.FirstOrDefaultAsync(x => x.UserId == user.Id);
            }
            return basket;

        }

        public async Task AddBasketItemToBasketCalorieAsync(string nutrientId, float measure)
        {
            BasketCalorie basket = await activeUser();
            if(basket != null)
            {
                await _basketItemWriteRepository.AddAsync(new BasketItem
                {
                    NutrientId = Guid.Parse(nutrientId),
                    Measure = measure,
                    Id = Guid.NewGuid(),
                    BasketCalorieId = basket.Id
                });
                await _basketItemWriteRepository.SaveAsync();

            }else throw new Exception();
            
        }

        public async Task<BasketItemDto> GetBasketItemsAsync()
        {
            BasketCalorie basket = await activeUser();
            BasketCalorie _basket = await _basketCalorieReadRepository.Table.Include(b => b.BasketItems).ThenInclude(bi => bi.Nutrient).FirstOrDefaultAsync(b => b.Id == basket.Id);
            float? totalCalorie = 0;
            float? totalFat = 0;
            float? totalProtein = 0;
            float? totalCarb = 0;
            foreach (var item in _basket.BasketItems)
            {
                totalCalorie += item.Nutrient.Calorie * (item.Measure / 100);
                totalFat += item.Nutrient.Fat * (item.Measure / 100);
                totalProtein += item.Nutrient.Protein * (item.Measure / 100);
                totalCarb += item.Nutrient.Carbohydrate * (item.Measure / 100);
            }
            var newDatas = _basket.BasketItems.Select(a => new
            {
                Id = a.Id.ToString(),
                Measure = a.Measure,
                Protein = a.Nutrient.Protein,
                Fat = a.Nutrient.Fat,
                Carbohydrate = a.Nutrient.Carbohydrate,
                Calorie = a.Nutrient.Calorie,
                Name = a.Nutrient.Name
            }).ToList();

            return new()
            {
                BasketItems = newDatas,
                TotalCalorie = totalCalorie,
                TotalCarbohydrate = totalCarb,
                TotalFat = totalFat,
                TotalProtein = totalProtein,
            };
        }

        

        public async Task RemoveBasketItemAsync(string basketItemId)
        {
            BasketItem basketItem = await _basketItemReadRepository.GetByIdAsync(basketItemId);
            if(basketItem != null)
            {
                await _basketCalorieWriteRepository.RemoveAsync(basketItemId);
                await _basketCalorieWriteRepository.SaveAsync();
            }
        }

        public async Task UpdateMeasureAsync(string basketItemId, float measure)
        {
            BasketItem basketItem = await _basketItemReadRepository.GetByIdAsync(basketItemId);
            basketItem.Measure = measure;
            await _basketItemWriteRepository.SaveAsync();
        }
    }
}
