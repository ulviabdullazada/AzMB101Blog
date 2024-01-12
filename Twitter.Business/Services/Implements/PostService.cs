using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Twitter.Business.Dtos.PostDtos;
using Twitter.Business.Exceptions.Common;
using Twitter.Business.Repositories.Interfaces;
using Twitter.Business.Services.Interfaces;
using Twitter.Core.Entities;
using Twitter.Core.Enums;

namespace Twitter.Business.Services.Implements;

public class PostService : IPostService
{
    IPostRepository _repo { get; }
    IPostReactionRepository _reactionRepository { get; }
    IHttpContextAccessor _contextAccessor { get; }
    IMapper _mapper { get; }
    UserManager<AppUser> _userManager { get; }
    readonly string userId;
    public PostService(IPostRepository repo,
        IHttpContextAccessor contextAccessor,
        UserManager<AppUser> userManager,
        IMapper mapper,
        IPostReactionRepository reactionRepository)
    {
        _repo = repo;
        _contextAccessor = contextAccessor;
        if (_contextAccessor.HttpContext.User.Claims.Any())
        {
            userId = _contextAccessor.HttpContext?.User?.Claims?.First(x => x.Type == ClaimTypes.NameIdentifier)?.Value ?? throw new NullReferenceException();
        }
        _userManager = userManager;
        _mapper = mapper;
        _reactionRepository = reactionRepository;
    }

    public async Task Create(PostCreateDto dto)
    {
        var entity = _mapper.Map<Post>(dto);
        entity.AppUserId = userId;
        await _repo.CreateAsync(entity);
        await _repo.SaveAsync();
    }

    public IEnumerable<PostListItemDto> Get()
    {
        var data = _repo.GetAll(true, "AppUser", "Reactions").OrderByDescending(r=>r.CreatedTime);
        return _mapper.Map<IEnumerable<PostListItemDto>>(data);
    }

    public async Task Delete(int id)
    {
        var data = await _repo.GetByIdAsync(id, false);
        if (data == null) throw new NotFoundException<Post>();
        if (data.AppUserId != userId) throw new Exception("User has no access");
        _repo.Remove(data);
        await _repo.SaveAsync();
    }

    public Task SoftDelete(int id)
    {
        throw new NotImplementedException();
    }

    public Task ReverseSoftDelete(int id)
    {
        throw new NotImplementedException();
    }

    public async Task Update(int id, PostUpdateDto dto)
    {
        var data = await _repo.GetByIdAsync(id, false);
        if (data == null) throw new NotFoundException<Post>();
        if (data.AppUserId != userId) throw new Exception("User has no access");
        _mapper.Map(dto, data);
        data.UpdatedTime = DateTime.UtcNow;
        data.UpdatedCount++;
        await _repo.SaveAsync();
    }
    public async Task React(int id, ReactionTypes type)
    {
        var post = await _repo.GetByIdAsync(id, false, "Reactions");
        if (post == null) throw new NotFoundException<Post>();
        var existReaction = await _reactionRepository.GetSingleAsync(x=>x.AppUserId == userId && x.PostId == id, false);
        if (existReaction != null)
        {
            if (existReaction.Reaction == type) return;
            existReaction.Reaction = type;
        }
        else
        {
            post.Reactions ??= new List<PostReaction>();
            post.Reactions.Add(new PostReaction { Reaction = type, AppUserId = userId,  PostId = id});
        }
        await _repo.SaveAsync();
    }
}
