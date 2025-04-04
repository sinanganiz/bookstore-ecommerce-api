using BookStore.Data.Contexts;
using BookStore.Data.Entities;
using BookStore.Data.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data.Repositories.Concretes;

public class CartRepository : Repository<Cart, int>, ICartRepository
{
    public CartRepository(AppDbContext context) : base(context) { }

    public async Task<Cart?> GetCartByUserIdAsync(string userId)
    {
        return await _context.Carts.FirstOrDefaultAsync(c => c.UserId == userId);
    }
    public async Task<Cart?> GetCartWithItemsByUserIdAsync(string userId)
    {
        return await _context.Carts
            .Include(c => c.CartItems)
            .ThenInclude(ci => ci.Book)
            .FirstOrDefaultAsync(c => c.UserId == userId);
    }
}