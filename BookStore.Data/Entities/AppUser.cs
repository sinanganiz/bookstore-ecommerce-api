using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace BookStore.Data.Entities;

public class AppUser : IdentityUser
{
    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public string Surname { get; set; } = null!;
    public string? ProfileImageUrl { get; set; }

    public string? Address { get; set; }
}
