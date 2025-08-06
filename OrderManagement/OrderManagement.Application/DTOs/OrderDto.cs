namespace OrderManagement.Application.DTOs
{
    public record OrderDto(List<OrderItemDto> Items, decimal TotalPrice, Guid UserId, string Username, DateTime CreatedAt);
}