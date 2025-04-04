using BookStore.Data.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BookStore.Data.Repositories.Abstracts;

public interface IOrderItemRepository : IRepository<OrderItem, int>
{
    Task<IEnumerable<OrderItem>> GetOrderItemsByOrderIdAsync(int orderId);

}