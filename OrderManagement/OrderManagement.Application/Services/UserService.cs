using AutoMapper;
using OrderManagement.Application.DTOs;
using OrderManagement.Application.Interfaces;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Interfaces;

namespace OrderManagement.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogService<UserService> _logger;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, ILogService<UserService> logger, IMapper mapper)
        {
            _userRepository = userRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
            var userDtos = _mapper.Map<List<UserDto>>(users);
            return userDtos;
        }

        public async Task<bool> RegisterAsync(RegisterUserDto userDto)
        {
            try
            {
                _logger.LogInfo($"RegisterAsync is starting");
                var existing = await _userRepository.GetByEmailAsync(userDto.Email);
                if (existing != null)
                {
                    _logger.LogWarning($"User with email {userDto.Email} already exists.");
                    return false;
                }
                var user = new User
                {
                    Username = userDto.Username,
                    Email = userDto.Email,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(userDto.Password)
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