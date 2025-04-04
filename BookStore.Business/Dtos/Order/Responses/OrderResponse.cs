namespace BookStore.Business.Dtos.Order;

public class OrderResponse
{
    public int Id { get; set; }
    public string UserId { get; set; } = null!;
    public double SubTotal { get; set; }
    public double ShippingCost { get; set; }
    public double Tax { get; set; }
    public double Total { get; set; }
    public string OrderStatus { get; set; } = null!;
    public string PaymentStatus { get; set; } = null!;
    public string? Notes { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public ICollection<OrderItemResponse> OrderItems { get; set; } = new List<OrderItemResponse>();
} 