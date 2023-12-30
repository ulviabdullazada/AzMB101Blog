using AutoMapper;
using Twitter.Business.Dtos.TopicDtos;
using Twitter.Core.Entities;

namespace Twitter.Business.Profiles
{
    public class TopicMappingProfile : Profile
    {
        public TopicMappingProfile()
        {
            CreateMap<TopicCreateDto, Topic>();
            CreateMap<TopicUpdateDto, Topic>();
            CreateMap<Topic, TopicListItemDto>();
            CreateMap<Topic, TopicDetailDto>();
        }
    }
}
