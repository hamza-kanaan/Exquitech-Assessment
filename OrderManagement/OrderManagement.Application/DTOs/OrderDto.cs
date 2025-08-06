namespace OrderManagement.Application.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public required List<OrderItemDto> Items { get; set; }
        public decimal TotalPrice { get; set; }
        public required string Username { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}