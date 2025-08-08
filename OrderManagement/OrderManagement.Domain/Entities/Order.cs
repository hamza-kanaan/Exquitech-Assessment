namespace OrderManagement.Domain.Entities
{
    public class Order : ITenantEntity
    {
        public int Id { get; set; }
        public List<OrderItem> Items { get; set; } = new();
        public decimal TotalPrice => Items.Sum(i => i.Product.Price * i.Quantity);
        public DateTime CreatedAt { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public int TenantId { get; set; }
        public Tenant? Tenant { get; set; }
    }
}