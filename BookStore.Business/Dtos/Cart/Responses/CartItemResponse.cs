
using BookStore.Business.Dtos.Books.Responses;
using BookStore.Data.Entities;

namespace BookStore.Business.Dtos.Cart;

public class CartItemResponse
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public BookResponse? Book { get; set; }
    public int Quantity { get; set; }
    public double UnitPrice { get; set; }
    public double TotalPrice { get; set; }
}
