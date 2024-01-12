using Twitter.Business.Repositories.Interfaces;
using Twitter.Core.Entities;
using Twitter.DAL.Contexts;

namespace Twitter.Business.Repositories.Implements;

public class PostReactionRepository : GenericRepository<PostReaction>, IPostReactionRepository
{
    public PostReactionRepository(TwitterContext context) : base(context)
    {
    }
}
