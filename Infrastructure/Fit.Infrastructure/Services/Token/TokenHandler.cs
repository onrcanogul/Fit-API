using Fit.Application.Abstractions.Services.Token;
using Fit.Application.DTOs.Token;
using Fit.Domain.Entites.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Fit.Infrastructure.Services.Token
{
    public class TokenHandler : ITokenHandler
    {
        private readonly IConfiguration _configuration;
        readonly UserManager<AppUser> _userManager;

        public TokenHandler(UserManager<AppUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public TokenDto CreateAccessToken(AppUser user, int second)
        {
            TokenDto token = new();

            //Sym sec key
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));

            // new key
            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

            //options
            token.Expiration = DateTime.UtcNow.AddSeconds(second);
            JwtSecurityToken jwtSecurityToken = new(
                issuer: _configuration["Token:Issuer"],
                audience: _configuration["Token:Audience"],
                notBefore: DateTime.UtcNow,
                signingCredentials: signingCredentials,
                expires: token.Expiration,
                claims: new List<Claim> {new(ClaimTypes.Name, user.UserName),new("id",user.Id),new("gender",user.Gender.ToString()) }
                );

            //tokencreater instance
            JwtSecurityTokenHandler handler = new();
            token.AccessToken = handler.WriteToken(jwtSecurityToken);
            token.RefreshToken = CreateRefreshToken();


            return token;
        }

        public string CreateRefreshToken()
        {
            byte[] number = new byte[32];
            using RandomNumberGenerator random = RandomNumberGenerator.Create();
            random.GetBytes(number);
            return Convert.ToBase64String(number);
        }
    }
}
