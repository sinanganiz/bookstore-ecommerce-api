using BookStore.Data.Entities;

namespace BookStore.Data.Repositories.Abstracts;

public interface IOrderRepository : IRepository<Order, int>
{
    Task<IEnumerable<Order>> GetOrdersByUserIdAsync(string userId);
    Task<Order?> GetOrderWithItemsByIdAsync(int orderId);
}