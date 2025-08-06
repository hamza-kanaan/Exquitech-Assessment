//using Microsoft.AspNetCore.Mvc;

//namespace OrderManagement.Api.Controllers
//{
//    public class OrdersController : ControllerBase
//    {
//        private readonly IOrderService _orderService;

//        public OrdersController(IOrderService orderService) => _orderService = orderService;

//        [HttpPost]
//        public async Task<IActionResult> Create(CreateOrderDto dto)
//        {
//            var orderId = await _orderService.CreateOrderAsync(dto);
//            return Ok(new { OrderId = orderId });
//        }

//        [HttpGet("{userId}")]
//        public async Task<IActionResult> Get(Guid userId)
//        {
//            var orders = await _orderService.GetOrdersByUserAsync(userId);
//            return Ok(orders);
//        }
//    }
//}