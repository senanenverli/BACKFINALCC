using Microsoft.AspNetCore.Identity;

namespace WebApplication6.Models;

public class AppUser : IdentityUser
{
    
    public string Fullname { get; set; } = null!;
    public bool IsActive { get; set; }
}
