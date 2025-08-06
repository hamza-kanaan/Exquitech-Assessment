using OrderManagement.Domain.Entities;

namespace OrderManagement.Domain.Interfaces
{
    public interface ITenantRepository
    {
        Task<Tenant> GetByNameAsync(string name);
    }
}