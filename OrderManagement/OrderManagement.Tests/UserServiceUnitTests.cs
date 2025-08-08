using AutoMapper;
using Moq;
using OrderManagement.Application.DTOs;
using OrderManagement.Application.Interfaces;
using OrderManagement.Application.Services;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Interfaces;

namespace OrderManagement.Tests;

public class UserServiceUnitTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly Mock<ILogService<UserService>> _loggerMock;
    private readonly Mock<IMapper> _mockMapper;
    private readonly UserService _userService;

    public UserServiceUnitTests()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
        _loggerMock = new Mock<ILogService<UserService>>();
        _mockMapper = new Mock<IMapper>();
        _userService = new UserService(_userRepositoryMock.Object, _loggerMock.Object, _mockMapper.Object);
    }

    [Fact]
    public async Task RegisterAsync_ShouldReturnFalse_WhenUserAlreadyExists()
    {
        // Arrange
        var registerUserDto = new RegisterUserDto("Hamza", "123456", "hamza@example.com");
        var existingUser = new User
        {
            Id = 1,
            Username = "Hamza",
            Email = "hamza@example.com",
            PasswordHash = "hashed_123456",
            TenantId = 1
        };
        _userRepositoryMock.Setup(x => x.GetByEmailAsync(registerUserDto.Email))
                           .ReturnsAsync(existingUser);

        // Act
        var result = await _userService.RegisterAsync(registerUserDto);

        // Assert
        Assert.False(result.Success);
        _loggerMock.Verify(l => l.LogWarning($"User with email {registerUserDto.Email} already exists"), Times.Once);
        _userRepositoryMock.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Never);
    }

    [Fact]
    public async Task RegisterAsync_ShouldReturnTrue_WhenUserDoesNotExist()
    {
        // Arrange
        var registerUserDto = new RegisterUserDto("Hamza", "123456", "hamza@example.com");
        _userRepositoryMock.Setup(x => x.GetByEmailAsync(registerUserDto.Email))
                           .ReturnsAsync((User)null);

        // Act
        var result = await _userService.RegisterAsync(registerUserDto);

        // Assert
        Assert.True(result.Success);
        _loggerMock.Verify(l => l.LogInfo($"User with email {registerUserDto.Email} registered successfully"), Times.Once);
        _userRepositoryMock.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Once);
    }
}