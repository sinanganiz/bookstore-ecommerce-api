using BookStore.Data.Contexts;
using BookStore.Data.Entities;
using BookStore.Data.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data.Repositories.Concretes;

public class OrderItemRepository : Repository<OrderItem, int>, IOrderItemRepository
{
    public OrderItemRepository(AppDbContext context) : base(context) { }
    public async Task<IEnumerable<OrderItem>> GetOrderItemsByOrderIdAsync(int orderId)
    {
        var orderItems = await _context.OrderItems
            .Include(oi => oi.Book)
            .Where(oi => oi.OrderId == orderId)
            .ToListAsync();
            
        return orderItems;
    }
}