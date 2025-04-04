
namespace BookStore.Business.Dtos.Cart;

public class AddToCartRequest
{
    public string UserId { get; set; } = null!;
    public int BookId { get; set; }
    public int Quantity { get; set; } = 1;
}
