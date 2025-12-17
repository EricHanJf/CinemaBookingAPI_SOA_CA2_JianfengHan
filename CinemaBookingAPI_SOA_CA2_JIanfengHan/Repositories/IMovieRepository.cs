using CinemaBookingAPI_SOA_CA2_JIanfengHan.Models;

namespace CinemaBookingAPI_SOA_CA2_JianfengHan.Repositories;

public interface IMovieRepository
{
    Task<IEnumerable<Movie>> GetAllAsync();
    Task<Movie?> GetByIdAsync(long id);
    Task<Movie> AddAsync(Movie movie);
    Task UpdateAsync(Movie movie);
    Task DeleteAsync(Movie movie);
}