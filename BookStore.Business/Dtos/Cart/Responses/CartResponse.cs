
namespace BookStore.Business.Dtos.Cart;

public class CartResponse
{
    public int Id { get; set; }
    public string UserId { get; set; } = null!;
    public double TotalAmount { get; set; }
    public ICollection<CartItemResponse> CartItems { get; set; } = new List<CartItemResponse>();

}
