using Fit.Application.Abstractions.Services;
using Fit.Application.Abstractions.Services.Token;
using Fit.Application.DTOs.Auth;
using Fit.Application.DTOs.Token;
using Fit.Domain.Entites.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fit.Persistance.Services
{
    public class AuthService : IAuthService
    {
        readonly SignInManager<AppUser> _signInManager;
        readonly UserManager<AppUser> _userManager;
        readonly ITokenHandler _tokenHandler;
        readonly IUserService _userService;

        public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler, IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
            _userService = userService;
        }

        public async Task<TokenDto> Login(LoginRequestDto request)
        {
            AppUser? user = await _userManager.FindByEmailAsync(request.Email);
            if(user == null)
            {
                throw new Exception("User could not found");
            }
           SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, request.Password,false);
            if (result.Succeeded)
            {
                TokenDto token = _tokenHandler.CreateAccessToken(user, 900); //60 parametreden de alınabilir. üşenmek :)
                await _userService.UpdateRefreshToken(token.RefreshToken, user, token.Expiration);

                return new TokenDto
                {
                    AccessToken = token.AccessToken,
                    Expiration = token.Expiration,
                    RefreshToken = token.RefreshToken
                };
            }
            throw new Exception();
        }

        public async Task<TokenDto> RefreshTokenLogin(string refreshToken)
        {
            AppUser? user = await _userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken ==  refreshToken);
            if(user != null && user.RefreshTokenEndDate > DateTime.UtcNow)
            {
                TokenDto token = new();
                token = _tokenHandler.CreateAccessToken(user, 900);
                await _userService.UpdateRefreshToken(refreshToken, user, token.Expiration);
                return new()
                {
                    AccessToken = token.AccessToken,
                    Expiration = token.Expiration,
                    RefreshToken = token.RefreshToken
                };
            }
            throw new Exception("User is not found or Token was expired");
        }
    }
}
