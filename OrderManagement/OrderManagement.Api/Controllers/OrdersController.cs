using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.DTOs;
using OrderManagement.Application.Interfaces;

namespace OrderManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService) => _orderService = orderService;

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var order = await _orderService.GetAsync(id);
            return Ok(order);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Create(CreateOrderDto orderDto)
        {
            await _orderService.CreateAsync(orderDto);
            return Ok();
        }
    }
}