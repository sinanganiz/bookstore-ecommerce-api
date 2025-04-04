using BookStore.Data.Contexts;
using BookStore.Data.Entities;
using BookStore.Data.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data.Repositories.Concretes;

public class OrderRepository : Repository<Order, int>, IOrderRepository
{
    public OrderRepository(AppDbContext context) : base(context) { }
    public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(string userId)
    {
        var orders = await _context.Orders
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Book)
            .Where(o => o.UserId == userId)
            .ToListAsync();

        return orders;
    }
    public async Task<Order?> GetOrderWithItemsByIdAsync(int orderId)
    {
        var order = await _context.Orders
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Book)
            .FirstOrDefaultAsync(o => o.Id == orderId);
            
        return order;
    }


}