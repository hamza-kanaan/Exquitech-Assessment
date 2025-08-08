using OrderManagement.Application.DTOs;

namespace OrderManagement.Application.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllAsync();
        Task<bool> RegisterAsync(RegisterUserDto userDto);
    }
}