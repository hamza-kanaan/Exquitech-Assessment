namespace OrderManagement.Application.DTOs
{
    public class OrderItemDto
    {
        public int Quantity { get; set; }
        public required string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
    }
}