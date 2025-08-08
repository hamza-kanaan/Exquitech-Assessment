using AutoMapper;
using OrderManagement.Application.DTOs;
using OrderManagement.Application.Interfaces;
using OrderManagement.Application.Models;
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

        public async Task<Result<List<UserDto>>> GetAllAsync()
        {
            try
            {
                _logger.LogInfo($"UserService/GetAllAsync is starting");
                var users = await _userRepository.GetAllAsync();
                if (users.Count() <= 0)
                {
                    return Result<List<UserDto>>.FailureResult("No users for this tenant");
                }
                else
                {
                    var userDtos = _mapper.Map<List<UserDto>>(users);
                    return Result<List<UserDto>>.SuccessResult(_mapper.Map<List<UserDto>>(userDtos), "Users returned successfully");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get the users", ex);
                throw;
            }
        }

        public async Task<Result<UserDto>> RegisterAsync(RegisterUserDto userDto)
        {
            try
            {
                _logger.LogInfo($"UserService/RegisterAsync is starting");
                var existing = await _userRepository.GetByEmailAsync(userDto.Email);
                if (existing != null)
                {
                    _logger.LogWarning($"User with email {userDto.Email} already exists");
                    return Result<UserDto>.FailureResult("User already exists");
                }
                var user = new User
                {
                    Username = userDto.Username,
                    Email = userDto.Email,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(userDto.Password)
                };
                user = await _userRepository.AddAsync(user);
                _logger.LogInfo($"User with email {userDto.Email} registered successfully");
                return Result<UserDto>.SuccessResult(_mapper.Map<UserDto>(user), "User registered successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to register user {userDto.Username}", ex);
                throw;
            }
        }
    }
}