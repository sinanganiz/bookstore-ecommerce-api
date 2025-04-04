using BookStore.Data.Entities;

namespace BookStore.Data.Repositories.Abstracts;

public interface ICartItemRepository : IRepository<CartItem, int>
{
    Task<CartItem?> GetCartItemByCartIdAndBookIdAsync(int cartId, int bookId);
    Task<IEnumerable<CartItem>> GetCartItemsByCartIdAsync(int cartId);
}