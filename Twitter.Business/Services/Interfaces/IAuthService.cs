using Twitter.Business.Dtos.AuthDtos;

namespace Twitter.Business.Services.Interfaces
{
    public interface IAuthService
    {
        Task<TokenDto> Login(LoginDto dto);
    }
}
