using Twitter.Core.Enums;

namespace Twitter.Core.Entities
{
    public class PostReaction : BaseEntity
    {
        public int PostId { get; set; }
        public Post Post { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public ReactionTypes Reaction { get; set; }
    }
}
