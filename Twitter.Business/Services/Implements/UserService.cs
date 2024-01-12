using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Text;
using Twitter.Business.Dtos.AppUserDtos;
using Twitter.Business.Exceptions.AppUser;
using Twitter.Business.Services.Interfaces;
using Twitter.Core.Entities;
using Twitter.Core.Enums;

namespace Twitter.Business.Services.Implements
{
    public class UserService : IUserService
    {
        UserManager<AppUser> _userManager { get; }
        RoleManager<IdentityRole> _roleManager { get; }
        IMapper _mapper { get; }

        public UserService(UserManager<AppUser> userManager,
            IMapper mapper,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _roleManager = roleManager;
        }

        public async Task CreateAsync(RegisterDto dto)
        {
            AppUser user = _mapper.Map<AppUser>(dto);
            var result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
            {
                StringBuilder sb = new();
                foreach (var item in result.Errors)
                {
                    sb.Append(item.Description + " ");
                }
                throw new AppUserCreatedFailedException(sb.ToString().TrimEnd());
            }
            var roleResult = await _userManager.AddToRoleAsync(user, nameof(Roles.Member));
            if (!roleResult.Succeeded)
            {
                StringBuilder sb = new();
                foreach (var item in result.Errors)
                {
                    sb.Append(item.Description + " ");
                }
                //TODO : Custom Exception
                throw new Exception(sb.ToString().TrimEnd());
            }
        }
    }
}
