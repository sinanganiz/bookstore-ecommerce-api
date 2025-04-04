using BookStore.Data.Contexts;
using BookStore.Data.Entities;
using BookStore.Data.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data.Repositories.Concretes;

public class CartItemRepository : Repository<CartItem, int>, ICartItemRepository
{
    public CartItemRepository(AppDbContext context) : base(context) { }

    public async Task<CartItem?> GetCartItemByCartIdAndBookIdAsync(int cartId, int bookId)
    {
        var cartItem = await _context.CartItems
            .Include(ci => ci.Book)
            .FirstOrDefaultAsync(ci => ci.CartId == cartId && ci.BookId == bookId);

        return cartItem;
    }
    public async Task<IEnumerable<CartItem>> GetCartItemsByCartIdAsync(int cartId)
    {
        var cartItems = await _context.CartItems
            .Include(ci => ci.Book)
            .Where(ci => ci.CartId == cartId)
            .ToListAsync();

        return cartItems;
    }

}