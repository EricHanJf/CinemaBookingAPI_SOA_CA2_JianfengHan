using CinemaBookingAPI_SOA_CA2_JianfengHan.DTOs.Auth;

namespace CinemaBookingAPI_SOA_CA2_JianfengHan.Services;

public interface IAuthService
{
    Task<AuthResponseDto> RegisterAsync(RegisterDto dto);
    Task<AuthResponseDto> LoginAsync(LoginDto dto);
}