using OrderManagement.Application.Interfaces;

namespace OrderManagement.Infrastructure.MultiTenants
{
    public class TenantProvider : ITenantProvider
    {
        public int TenantId { get; set; }
    }
}