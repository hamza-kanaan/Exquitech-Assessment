using OrderManagement.Application.DTOs;

namespace OrderManagement.Application.Interfaces
{
    public interface IUserService
    {
        Task<bool> RegisterAsync(UserDto userDto);
    }
}