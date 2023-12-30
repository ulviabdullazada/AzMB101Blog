namespace Twitter.Core.Entities.Common;

public class BaseEntity
{
    public int Id { get; set; }
    public virtual DateTime CreatedTime { get; set; }
    public virtual bool IsDeleted { get; set; }
}
