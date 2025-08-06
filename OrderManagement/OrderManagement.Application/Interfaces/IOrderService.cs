using OrderManagement.Application.DTOs;

namespace OrderManagement.Application.Interfaces
{
    public interface IOrderService
    {
        Task<OrderDto> GetAsync(Guid id);
        Task<Guid> CreateAsync(OrderDto dto);
    }
}