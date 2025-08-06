using OrderManagement.Application.DTOs;
using OrderManagement.Application.Interfaces;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Interfaces;

namespace OrderManagement.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITenantRepository _tenantRepository;
        private readonly ILogService<UserService> _logger;

        public UserService(IUserRepository userRepository, ITenantRepository tenantRepository, ILogService<UserService> logger)
        {
            _userRepository = userRepository;
            _tenantRepository = tenantRepository;
            _logger = logger;
        }

        public async Task<bool> RegisterAsync(UserDto userDto)
        {
            try
            {
                var existing = await _userRepository.GetByEmailAsync(userDto.Email);
                if (existing != null)
                {
                    _logger.LogInfo($"User with email {userDto.Email} already exists.");
                    return false;
                }

                var user = new User
                {
                    Username = userDto.Username,
                    Email = userDto.Email,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(userDto.Password),
                    Tenant = await _tenantRepository.GetByNameAsync(userDto.TenantName)
                };
                await _userRepository.AddAsync(user);
                _logger.LogInfo($"User with email {userDto.Email} registered successfully.");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to register user {userDto.Username}", ex);
                throw;
            }
        }
    }
}