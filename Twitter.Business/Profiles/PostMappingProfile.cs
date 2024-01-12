using AutoMapper;
using Twitter.Business.Dtos.PostDtos;
using Twitter.Core.Entities;

namespace Twitter.Business.Profiles;

public class PostMappingProfile : Profile
{
    public PostMappingProfile()
    {
        CreateMap<PostCreateDto, Post>();
        CreateMap<PostUpdateDto, Post>();
        CreateMap<Post, PostListItemDto>()
            .ForMember(x => x.ReactionCount, opt => opt.MapFrom(x => x.Reactions.Count));
    }
}
