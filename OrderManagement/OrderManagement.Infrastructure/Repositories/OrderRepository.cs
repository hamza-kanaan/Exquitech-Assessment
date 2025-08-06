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

        public async Task<int> AddAsync(Order order)
        {
            var newOrder = _appDbContext.Orders.Add(order);
            await _appDbContext.SaveChangesAsync();
            return newOrder.Entity.Id;
        }

        public async Task<Order> GetAsync(int id)
        {
            return await _appDbContext.Orders.Include(o => o.Items)
                                   .FirstOrDefaultAsync(o => o.Id == id);
        }
    }
}