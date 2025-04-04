using BookStore.Business.Dtos.Books.Responses;

namespace BookStore.Business.Dtos.Order;

public class OrderItemResponse
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public BookResponse? bookResponse { get; set; }
    public int Quantity { get; set; }
    public double UnitPrice { get; set; }
    public double TotalPrice { get; set; }
}