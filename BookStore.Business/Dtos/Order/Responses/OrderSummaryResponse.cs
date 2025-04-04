namespace BookStore.Business.Dtos.Order;

public class OrderSummaryResponse
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public double Total { get; set; }
    public string OrderStatus { get; set; } = null!;
    public string PaymentStatus { get; set; } = null!;
    public int ItemCount { get; set; }
} 