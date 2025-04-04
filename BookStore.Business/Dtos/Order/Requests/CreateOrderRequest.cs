namespace BookStore.Business.Dtos.Order;

public class CreateOrderRequest
{
    public string UserId { get; set; } = null!;
    public string? Notes { get; set; }
} 