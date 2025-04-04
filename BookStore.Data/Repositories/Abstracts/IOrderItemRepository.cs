using BookStore.Data.Entities;

namespace BookStore.Data.Repositories.Abstracts;

public interface IOrderItemRepository : IRepository<OrderItem, int>
{
    Task<IEnumerable<OrderItem>> GetOrderItemsByOrderIdAsync(int orderId);

}