using OrderManagement.Application.DTOs;

namespace OrderManagement.Application.Interfaces
{
    public interface IOrderService
    {
        Task<OrderDto> GetAsync(int id);
        Task<bool> CreateAsync(CreateOrderDto dto);
    }
}