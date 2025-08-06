using OrderManagement.Domain.Entities;

namespace OrderManagement.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> GetAsync(int id);
        Task AddAsync(Order order);
    }
}