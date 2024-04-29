using Fit.Application.DTOs;
using Fit.Application.DTOs.User;
using Fit.Domain.Entites.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fit.Application.Abstractions.Services
{
    public interface IUserService
    {
        Task<ListDto> GetUsersAsync(int page, int size);
        Task<UserDto> GetUserByIdAsync(string id);
        Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime accessTokenDate);
        Task CreateUserAsync(CreateUserDto user);
        Task UpdateUserAsync(UpdateUserDto user);
        Task DeleteUserAsync(string id);
    }
}
