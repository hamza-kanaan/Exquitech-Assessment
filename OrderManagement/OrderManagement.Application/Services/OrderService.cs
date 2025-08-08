using AutoMapper;
using OrderManagement.Application.DTOs;
using OrderManagement.Application.Interfaces;
using OrderManagement.Application.Models;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Interfaces;

namespace OrderManagement.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILogService<OrderService> _logger;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, ILogService<OrderService> logger, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<Result<OrderDto>> GetAsync(int id)
        {
            try
            {
                _logger.LogInfo($"OrderService/GetAsync is starting");
                var order = await _orderRepository.GetAsync(id);
                if (order == null)
                {
                    return Result<OrderDto>.FailureResult("User doesn't exist");
                }
                else
                {
                    var orderDto = _mapper.Map<OrderDto>(order);
                    return Result<OrderDto>.SuccessResult(_mapper.Map<OrderDto>(orderDto), "Order returned successfully");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get the order {id}", ex);
                throw;
            }
        }

        public async Task<Result<int>> CreateAsync(CreateOrderDto createOrderDto)
        {
            try
            {
                _logger.LogInfo($"OrderService/CreateAsync is starting");
                var order = _mapper.Map<Order>(createOrderDto);
                order = await _orderRepository.AddAsync(order);
                if (order == null)
                {
                    _logger.LogWarning($"Order by user {createOrderDto.UserId} has not been added");
                    return Result<int>.FailureResult("Order has not been added");
                }
                else
                {
                    _logger.LogInfo($"Order by user {createOrderDto.UserId} created successfully.");
                    return Result<int>.SuccessResult(order.Id, "Order created successfully");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to create order by user {createOrderDto.UserId}", ex);
                throw;
            }
        }
    }
}