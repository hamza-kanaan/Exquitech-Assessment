using AutoMapper;
using OrderManagement.Application.DTOs;
using OrderManagement.Application.Interfaces;
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

        public async Task<OrderDto> GetAsync(int id)
        {
            var order = await _orderRepository.GetAsync(id);
            var orderDto = _mapper.Map<OrderDto>(order);
            return orderDto;
        }

        public async Task<bool> CreateAsync(CreateOrderDto createOrderDto)
        {
            try
            {
                _logger.LogInfo($"OrderService/CreateAsync is starting");
                var order = _mapper.Map<Order>(createOrderDto);
                await _orderRepository.AddAsync(order);
                _logger.LogInfo($"Order by user {createOrderDto.UserId} created successfully.");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to create order by user {createOrderDto.UserId}", ex);
                throw;
            }
        }
    }
}