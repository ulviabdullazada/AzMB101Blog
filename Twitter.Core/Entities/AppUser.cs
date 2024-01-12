using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Twitter.Core.Entities;

public class AppUser : IdentityUser
{
    public string Fullname { get; set; }
    public DateTime BirthDate { get; set; }
    public IEnumerable<Post> Posts { get; set; }
    public IEnumerable<PostReaction> Reactions { get; set; }
}
