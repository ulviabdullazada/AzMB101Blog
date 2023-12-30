using Twitter.Business.Dtos.TopicDtos;

namespace Twitter.Business.Services.Interfaces;

public interface ITopicService
{
    public IEnumerable<TopicListItemDto> GetAll();
    public Task<TopicDetailDto> GetByIdAsync(int id);
    public Task CreateAsync(TopicCreateDto dto);
    public Task RemoveAsync(int id);
    public Task UpdateAsync(int id, TopicUpdateDto dto);
}
