using Twitter.Business.Dtos.AppUserDtos;

namespace Twitter.Business.Dtos.PostDtos
{
    public class PostListItemDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public int ReactionCount { get; set; }
        public AppUserInPostItemDto AppUser { get; set; }
    }
}
