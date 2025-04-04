using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Data.Entities;

public class Order
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string UserId { get; set; } = null!;
    
    public AppUser? User { get; set; }
    
    [Required]
    public double SubTotal { get; set; }
    
    [Required]
    public double ShippingCost { get; set; }
    
    [Required]
    public double Tax { get; set; }
    
    [Required]
    public double Total { get; set; }
    
    [Required]
    public string OrderStatus { get; set; } = "Pending";
    
    [Required]
    public string PaymentStatus { get; set; } = "Pending";
        
    public string? Notes { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public DateTime? UpdatedAt { get; set; }
    
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
} 