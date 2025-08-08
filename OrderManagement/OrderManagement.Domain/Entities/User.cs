namespace OrderManagement.Domain.Entities
{
    public class User : ITenantEntity
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string PasswordHash { get; set; }
        public required string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public int TenantId { get; set; }
        public Tenant? Tenant { get; set; }
    }
}