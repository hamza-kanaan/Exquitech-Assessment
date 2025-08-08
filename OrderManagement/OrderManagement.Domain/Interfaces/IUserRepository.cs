using OrderManagement.Domain.Entities;

namespace OrderManagement.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByEmailAsync(string email);
        Task<List<User>> GetAllAsync();
        Task<User> AddAsync(User user);
    }
}