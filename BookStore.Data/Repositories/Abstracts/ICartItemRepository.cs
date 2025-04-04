using BookStore.Data.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BookStore.Data.Repositories.Abstracts;

public interface ICartItemRepository : IRepository<CartItem, int>
{
    Task<CartItem?> GetCartItemByCartIdAndBookIdAsync(int cartId, int bookId);
    Task<IEnumerable<CartItem>> GetCartItemsByCartIdAsync(int cartId);
}