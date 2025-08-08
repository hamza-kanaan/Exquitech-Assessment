using OrderManagement.Application.DTOs;
using OrderManagement.Application.Models;

namespace OrderManagement.Application.Interfaces
{
    public interface IOrderService
    {
        Task<Result<OrderDto>> GetAsync(int id);
        Task<Result<int>> CreateAsync(CreateOrderDto dto);
    }
}