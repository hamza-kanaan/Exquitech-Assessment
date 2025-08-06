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
    private readonly Mock<ITenantRepository> _tenantRepositoryMock;
    private readonly Mock<ILogService<UserService>> _loggerMock;
    private readonly UserService _userService;

    public UserServiceUnitTests()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
        _tenantRepositoryMock = new Mock<ITenantRepository>();
        _loggerMock = new Mock<ILogService<UserService>>();
        _userService = new UserService(_userRepositoryMock.Object, _tenantRepositoryMock.Object, _loggerMock.Object);
    }

    [Fact]
    public async Task RegisterAsync_ShouldReturnFalse_WhenUserAlreadyExists()
    {
        // Arrange

        var userDto = new UserDto("Hamza", "hamza@example.com", "123456", "Tenant-1");

        var existingUser = new User
        {
            Id = 1,
            Username = "Hamza",
            Email = "hamza@example.com",
            PasswordHash = "hashed_123456",
            TenantId = 1
        };


        _userRepositoryMock.Setup(x => x.GetByEmailAsync(userDto.Email))
                           .ReturnsAsync(existingUser);

        // Act
        var result = await _userService.RegisterAsync(userDto);

        // Assert
        Assert.False(result);
        _loggerMock.Verify(l => l.LogInfo($"User with email {userDto.Email} already exists."), Times.Once);
        _userRepositoryMock.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Never);
    }

    //[Fact]
    //public async Task RegisterAsync_ShouldReturnTrue_WhenUserDoesNotExist()
    //{
    //    // Arrange
    //    var email = "new@example.com";
    //    _userRepositoryMock.Setup(x => x.GetByEmailAsync(email))
    //                       .ReturnsAsync((User)null);

    //    // Act
    //    var result = await _userService.RegisterAsync(email, "New", "123456");

    //    // Assert
    //    Assert.True(result);
    //    _loggerMock.Verify(l => l.LogInfo($"User with email {email} registered successfully."), Times.Once);
    //    _userRepositoryMock.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Once);
    //}
}