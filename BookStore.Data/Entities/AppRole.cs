using Microsoft.AspNetCore.Identity;

namespace BookStore.Data.Entities;

public class AppRole : IdentityRole
{
    public string? Description { get; set; }
}
