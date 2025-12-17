using System.Security.Cryptography;
using System.Text;
using CinemaBookingAPI_SOA_CA2_JianfengHan.DTOs.Auth;
using CinemaBookingAPI_SOA_CA2_JIanfengHan.Models;
using CinemaBookingAPI_SOA_CA2_JianfengHan.Repositories;

namespace CinemaBookingAPI_SOA_CA2_JianfengHan.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;

    public AuthService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<AuthResponseDto> RegisterAsync(RegisterDto dto)
    {
        var existing = await _userRepository.GetByUsernameAsync(dto.Username);
        if (existing != null)
            throw new Exception("User already exists");

        var user = new User
        {
            Username = dto.Username,
            //with Hashed password
            Password = Hash(dto.Password),
            //without hashed password
            // Password = dto.Password,
            ApiKey = Guid.NewGuid().ToString()
        };

        await _userRepository.AddAsync(user);
        await _userRepository.SaveChangesAsync();

        return new AuthResponseDto
        {
            Username = user.Username,
            ApiKey = user.ApiKey
        };
    }

    public async Task<AuthResponseDto> LoginAsync(LoginDto dto)
    {
        var user = await _userRepository.GetByUsernameAsync(dto.Username);
        if (user == null || user.Password != Hash(dto.Password))
            throw new Exception("Invalid credentials");
        
        return new AuthResponseDto
        {
            Username = user.Username,
            ApiKey = user.ApiKey
        };
        //without hashed
        // var user = await _userRepository.GetByUsernameAsync(dto.Username);
        //
        // if (user == null || user.Password != dto.Password)
        //     throw new Exception("Invalid credentials");
        //
        // return new AuthResponseDto
        // {
        //     Username = user.Username,
        //     ApiKey = user.ApiKey
        // };
    }

    private string Hash(string input)
    {
        using var sha = SHA256.Create();
        var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
        return Convert.ToBase64String(bytes);
    }
}