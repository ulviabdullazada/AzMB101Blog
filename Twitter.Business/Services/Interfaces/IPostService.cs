using Twitter.Business.Dtos.PostDtos;
using Twitter.Core.Enums;

namespace Twitter.Business.Services.Interfaces
{
    public interface IPostService
    {
        Task Create(PostCreateDto dto);
        IEnumerable<PostListItemDto> Get();
        Task Delete(int id);
        Task SoftDelete(int id);
        Task ReverseSoftDelete(int id);
        Task Update(int id, PostUpdateDto dto);
        Task React(int id, ReactionTypes type);
    }
}
