using BookStore.Data.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BookStore.Data.Repositories.Abstracts;

public interface ICartRepository : IRepository<Cart, int>
{
    Task<Cart?> GetCartByUserIdAsync(string userId);
    Task<Cart?> GetCartWithItemsByUserIdAsync(string userId);
}