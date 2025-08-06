//using OrderManagement.Application.DTOs;
//using OrderManagement.Application.Interfaces;
//using OrderManagement.Domain.Entities;
//using OrderManagement.Domain.Interfaces;

//namespace OrderManagement.Application.Services
//{
//    public class OrderService : IOrderService
//    {
//        private readonly IOrderRepository _orderRepository;
//        private readonly ILogService<OrderService> _logger;

//        public OrderService(IOrderRepository orderRepository, ILogService<OrderService> logger)
//        {
//            _orderRepository = orderRepository;
//            _logger = logger;
//        }

//        public async Task<OrderDto> GetAsync(Guid userId)
//        {
//            var order =  await _orderRepository.GetAsync(userId);
//            OrderDto orderDto = new OrderDto();
//            return orderDto;
//        }

//        public async Task<Guid> CreateAsync(OrderDto dto)
//        {
//            var order = new Order
//            {
//                Id = Guid.NewGuid(),
//                CreatedAt = DateTime.UtcNow,
//                UserId = dto.UserId,
//                Items = dto.Items.Select(i => new OrderItem
//                {
//                    Id = Guid.NewGuid(),
//                    ProductName = i.ProductName,
//                    Price = i.Price,
//                    Quantity = i.Quantity
//                }).ToList()
//            };

//            _db.Orders.Add(order);
//            await _db.SaveChangesAsync();
//            return order.Id;
//        }
//    }
//}