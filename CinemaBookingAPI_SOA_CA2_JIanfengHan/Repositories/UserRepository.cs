using CinemaBookingAPI_SOA_CA2_JIanfengHan.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaBookingAPI_SOA_CA2_JianfengHan.Repositories;

public class UserRepository : IUserRepository
{
    private readonly CinemaContext _context;

    public UserRepository(CinemaContext context)
    {
        _context = context;
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Username == username);
    }

    public async Task<User?> GetByApiKeyAsync(string apiKey)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.ApiKey == apiKey);
    }

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}