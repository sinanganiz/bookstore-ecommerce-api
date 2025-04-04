using BookStore.Data.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BookStore.Data.Repositories.Abstracts;

public interface IOrderRepository : IRepository<Order, int>
{
    Task<IEnumerable<Order>> GetOrdersByUserIdAsync(string userId);
    Task<Order?> GetOrderWithItemsByIdAsync(int orderId);
}