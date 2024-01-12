namespace Twitter.Core.Entities;
public class Post : BaseEntity
{
    public string Content { get; set; }
    public DateTime? UpdatedTime { get; set; }
    public int UpdatedCount { get; set; }
    public string AppUserId { get; set; }
    public AppUser AppUser{ get; set; }
    public ICollection<PostReaction> Reactions { get; set; }
}
