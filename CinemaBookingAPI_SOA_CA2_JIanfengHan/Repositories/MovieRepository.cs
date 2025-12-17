using CinemaBookingAPI_SOA_CA2_JIanfengHan.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaBookingAPI_SOA_CA2_JianfengHan.Repositories;

public class MovieRepository : IMovieRepository
{
    private readonly CinemaContext _context;

    public MovieRepository(CinemaContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Movie>> GetAllAsync()
    {
        return await _context.Movies.ToListAsync();
    }

    public async Task<Movie?> GetByIdAsync(long id)
    {
        return await _context.Movies.FindAsync(id);
    }

    public async Task<Movie> AddAsync(Movie movie)
    {
        _context.Movies.Add(movie);
        await _context.SaveChangesAsync();
        return movie;
    }

    public async Task UpdateAsync(Movie movie)
    {
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Movie movie)
    {
        _context.Movies.Remove(movie);
        await _context.SaveChangesAsync();
    }
}