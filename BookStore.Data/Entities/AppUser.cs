using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BookStore.Data.Entities;

public class AppUser : IdentityUser
{
    [Required]
    public string Name { get; set; } = null!;
    
    [Required]
    public string Surname { get; set; } = null!;
    public string? ProfileImageUrl{ get; set; }

}
