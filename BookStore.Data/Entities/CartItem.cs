using System.ComponentModel.DataAnnotations;

namespace BookStore.Data.Entities;

public class CartItem
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public int CartId { get; set; }
    
    public Cart? Cart { get; set; }
    
    [Required]
    public int BookId { get; set; }
    
    public Book? Book { get; set; }
    
    [Required]
    [Range(1, int.MaxValue)]
    public int Quantity { get; set; }
    
    [Required]
    public double UnitPrice { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public DateTime? UpdatedAt { get; set; }
} 