using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Unicode;
using Twitter.Business.Dtos.AuthDtos;
using Twitter.Business.Exceptions.Auth;
using Twitter.Business.Exceptions.Common;
using Twitter.Business.ExternalServices.Interfaces;
using Twitter.Business.Services.Interfaces;
using Twitter.Core.Entities;

namespace Twitter.Business.Services.Implements
{
    public class AuthService : IAuthService
    {
        UserManager<AppUser> _userManager { get; }
        ITokenService _tokenService { get; }

        public AuthService(UserManager<AppUser> userManager, 
            ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<TokenDto> Login(LoginDto dto)
        {
            AppUser? user = null;
            if (dto.UsernameOrEmail.Contains("@"))
            {
                user = await _userManager.FindByEmailAsync(dto.UsernameOrEmail);
            }
            else
            {
                user = await _userManager.FindByNameAsync(dto.UsernameOrEmail);
            }
            if (user == null) throw new UsernameOrPasswordWrongException();
            var result = await _userManager.CheckPasswordAsync(user, dto.Password);
            if (!result) throw new UsernameOrPasswordWrongException();
            string role = (await _userManager.GetRolesAsync(user)).First();
            return _tokenService.CreateToken(new TokenParamsDto
            {
                Role = role,
                User = user
            });
        }
    }
}
