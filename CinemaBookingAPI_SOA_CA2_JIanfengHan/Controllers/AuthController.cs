using CinemaBookingAPI_SOA_CA2_JianfengHan.DTOs.Auth;
using CinemaBookingAPI_SOA_CA2_JianfengHan.Services;
using Microsoft.AspNetCore.Mvc;

namespace CinemaBookingAPI_SOA_CA2_JianfengHan.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<AuthResponseDto>> Register(RegisterDto dto)
    {
        return Ok(await _authService.RegisterAsync(dto));
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthResponseDto>> Login(LoginDto dto)
    {
        return Ok(await _authService.LoginAsync(dto));
    }
}