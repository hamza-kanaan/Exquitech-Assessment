using OrderManagement.Application.DTOs;
using OrderManagement.Application.Models;

namespace OrderManagement.Application.Interfaces
{
    public interface IUserService
    {
        Task<Result<List<UserDto>>> GetAllAsync();
        Task<Result<UserDto>> RegisterAsync(RegisterUserDto userDto);
    }
}