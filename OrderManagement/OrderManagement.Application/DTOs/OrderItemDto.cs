namespace OrderManagement.Application.DTOs
{
    public record OrderItemDto(Guid ProductId, string ProductName, decimal ProductPrice, int Quantity);
}