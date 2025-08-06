namespace OrderManagement.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public List<OrderItem> Items { get; set; } = new();
        public decimal TotalPrice => Items.Sum(i => i.Product.Price * i.Quantity);
        public int UserId { get; set; }
        public User? User { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}