using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data.Entities;

public class Cart
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string UserId { get; set; } = null!;
    
    public AppUser? User { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public DateTime? UpdatedAt { get; set; }
    
    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
} 