using Fit.Application.Abstractions.Services;
using Fit.Application.Constants;
using Fit.Application.DTOs;
using Fit.Application.DTOs.User;
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
    public class UserService : IUserService
    {
        readonly UserManager<AppUser> _userManager;
        readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task CreateUserAsync(CreateUserDto user)
        {
            IdentityResult result = await _userManager.CreateAsync(new()
            {
                Age = user.Age,
                Email = user.Email,
                UserName = user.Username,
                Gender = user.Gender,
                Id = Guid.NewGuid().ToString(),
            },user.Password);

            if (!result.Succeeded)
            {
                throw new Exception();
            }


            
          
        }

        public async Task DeleteUserAsync(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            await _userManager.DeleteAsync(user);
        }

        public async Task<UserDto> GetUserByIdAsync(string id)
        {
            AppUser? user = await _userManager.FindByIdAsync(id);
            return new()
            {
                Id = user.Id,
                BMR = user.BMR,
                Email = user.Email,
                FatRate = user.FatRate,
                Gender = user.Gender,
                Height = user.Height,
                Weight = user.Weight,
                Activity = user.Activity,
                Age = user.Age,
                Username=user.UserName
            };
        }

        public async Task<ListDto> GetUsersAsync(int page, int size)
        {
            var query = _userManager.Users;
            var datas =await  query.Skip(size*page).Take(size).ToListAsync();
            var newDatas = datas.Select(x => new
            {
                Id = x.Id,
                FatRate = x.FatRate,
                Activity = x.Activity,
                Age = x.Age,
                BMR = x.BMR,
                Email = x.Email,
                Height = x.Height,
                Weight = x.Weight,
                Gender = x.Gender,
                Username = x.UserName

            });
            return new()
            {
                Entity = newDatas,
                TotalCount = query.Count()
            };
        }

        public async Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime accessTokenDate)
        {
            if (user != null)
            {
                user.RefreshToken = refreshToken;
                user.RefreshTokenEndDate = accessTokenDate.AddSeconds(60);
                await _userManager.UpdateAsync(user);
            }
            else throw new Exception("Not found user");
        }

        public async Task UpdateUserAsync(UpdateUserDto user)
        {
            AppUser currentUser = await _userManager.FindByIdAsync(user.Id);
            float BMR;
            float activityRate = 0;
            switch (user.Activity)
            {
                case Activity.Moveless:
                    activityRate = 1.2F;
                    break;
                case Activity.Low:
                    activityRate = 1.375F;
                    break;
                case Activity.Mid:
                    activityRate = 1.55F;
                    break;
                case Activity.High:
                    activityRate = 1.725F;
                    break;
                case Activity.VeryHigh:
                    activityRate = 1.9F;
                    break;
            }
            if (currentUser.Gender == Domain.Enums.Gender.Male)
                BMR = (float)((10 * user.Weight + 6.25 * user.Height - 5 * user.Age - 161) * activityRate);
            else if (currentUser.Gender == Domain.Enums.Gender.Female)
                BMR = (float)((10 * user.Weight + 6.25 * user.Height - 5 * user.Age + 5) * activityRate);
            else
                throw new Exception("Unknown Exception");

            currentUser.FatRate = user.FatRate;
            currentUser.BMR = BMR;
            currentUser.Activity = user.Activity;
            currentUser.Height = user.Height;
            currentUser.Age = user.Age;
            currentUser.Weight = user.Weight;

            await _userManager.UpdateAsync(currentUser);         
        }

        
    }
}
