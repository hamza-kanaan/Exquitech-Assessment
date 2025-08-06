namespace OrderManagement.Application.DTOs
{
    public record CreateOrderDto(List<CreateOrderItemDto> Items, int UserId);
}