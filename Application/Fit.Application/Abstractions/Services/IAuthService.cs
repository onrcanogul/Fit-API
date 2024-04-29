using Fit.Application.DTOs.Auth;
using Fit.Application.DTOs.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fit.Application.Abstractions.Services
{
    public interface IAuthService
    {
        Task<TokenDto> Login(LoginRequestDto request);
        Task<TokenDto> RefreshTokenLogin(string refreshToken);
    }
}
