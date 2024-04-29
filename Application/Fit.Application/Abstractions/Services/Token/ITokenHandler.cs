using Fit.Application.DTOs.Token;
using Fit.Domain.Entites.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fit.Application.Abstractions.Services.Token
{
    public interface ITokenHandler
    {
        TokenDto CreateAccessToken(AppUser user, int second);
        string CreateRefreshToken();
    }
}
