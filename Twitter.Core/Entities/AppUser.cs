using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Twitter.Core.Entities;

public class AppUser : IdentityUser
{
    public string Fullname { get; set; }
    public DateTime BirthDate { get; set; }

}
