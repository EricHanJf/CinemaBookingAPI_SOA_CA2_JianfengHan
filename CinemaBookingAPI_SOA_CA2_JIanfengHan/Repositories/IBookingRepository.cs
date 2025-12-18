using CinemaBookingAPI_SOA_CA2_JIanfengHan.Models;

namespace CinemaBookingAPI_SOA_CA2_JianfengHan.Repositories;

public interface IBookingRepository
{
    Task<IEnumerable<Booking>> GetByUserIdAsync(int userId);
    Task<Booking> CreateBookingAsync(
        int userId,
        long screeningId,
        long seatId
    );
    Task<Booking?> GetByIdAsync(long bookingId, int userId);
    Task<bool> DeleteAsync(long bookingId, int userId);
    // Task AddAsync(Booking booking);
    // Task SaveChangesAsync();
}