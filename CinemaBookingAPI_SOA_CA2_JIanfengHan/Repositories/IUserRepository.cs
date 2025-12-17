using CinemaBookingAPI_SOA_CA2_JIanfengHan.Models;

namespace CinemaBookingAPI_SOA_CA2_JianfengHan.Repositories;

public interface IUserRepository
{
    Task<User?> GetByUsernameAsync(string username);
    Task<User?> GetByApiKeyAsync(string apiKey);
    Task AddAsync(User user);
    Task SaveChangesAsync();
}