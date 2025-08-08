namespace OrderManagement.Domain.Entities
{
    public class Product : ITenantEntity
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public int TenantId { get; set; }
        public Tenant? Tenant { get; set; }
    }
}