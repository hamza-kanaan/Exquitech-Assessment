namespace OrderManagement.Application.DTOs
{
    public record UserDto(string Username, string Password, string Email, string TenantName);
}