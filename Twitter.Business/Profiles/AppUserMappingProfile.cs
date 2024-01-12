using AutoMapper;
using Twitter.Business.Dtos.AppUserDtos;
using Twitter.Core.Entities;

namespace Twitter.Business.Profiles
{
    public class AppUserMappingProfile:Profile
    {
        public AppUserMappingProfile()
        {
            CreateMap<RegisterDto, AppUser>();
            CreateMap<AppUser, AppUserInPostItemDto>();
        }
    }
}
