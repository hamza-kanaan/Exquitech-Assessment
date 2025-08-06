using Microsoft.EntityFrameworkCore;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Interfaces;
using OrderManagement.Infrastructure.Persistence;

namespace OrderManagement.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;

        public OrderRepository(AppDbContext appDbContext) => _appDbContext = appDbContext;

        public async Task AddAsync(Order order)
        {
            order.CreatedAt = DateTime.Now;
            _appDbContext.Orders.Add(order);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<Order> GetAsync(int id)
        {
            return await _appDbContext.Orders
                .Include(o => o.User)
                .Include(o => o.Items)
                                    .ThenInclude(i => i.Product)
                                   .FirstAsync(o => o.Id == id);
        }
    }
}