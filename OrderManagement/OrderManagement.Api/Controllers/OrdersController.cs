using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.DTOs;
using OrderManagement.Application.Interfaces;

namespace OrderManagement.Api.Controllers
{
    [ApiController]
    [Route("api/{tenantId}/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService) => _orderService = orderService;

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _orderService.GetAsync(id);

            if (!result.Success)
                return BadRequest(new { result.Message });

            return Ok(new { result.Message, Order = result.Data });
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateOrderDto orderDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _orderService.CreateAsync(orderDto);

            if (!result.Success)
                return BadRequest(new { result.Message });

            return Ok(new { result.Message, OrderId = result.Data });
        }
    }
}