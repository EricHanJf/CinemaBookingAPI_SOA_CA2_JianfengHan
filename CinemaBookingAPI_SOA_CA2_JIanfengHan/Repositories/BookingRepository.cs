using CinemaBookingAPI_SOA_CA2_JIanfengHan.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaBookingAPI_SOA_CA2_JianfengHan.Repositories;

public class BookingRepository : IBookingRepository
{
    private readonly CinemaContext _context;

    public BookingRepository(CinemaContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Booking>> GetByUserIdAsync(int userId)
    {
        return await _context.Bookings
            .Include(b => b.Screening)
            .Include(b => b.Seat)
            .Where(b => b.UserId == userId)
            .ToListAsync();
    }
    
    public async Task<Booking> CreateBookingAsync(int userId, long screeningId, long seatId)
    {
        var screening = await _context.Screenings
            .FirstOrDefaultAsync(s => s.Id == screeningId);

        if (screening == null)
            throw new Exception("Screening not found");

        var seat = await _context.Seats
            .FirstOrDefaultAsync(s => s.Id == seatId);

        if (seat == null)
            throw new Exception("Seat not found");

        if (seat.HallNumber != screening.HallNumber)
            throw new Exception("Seat does not belong to screening hall");

        var booking = new Booking
        {
            UserId = userId,
            ScreeningId = screeningId,
            SeatId = seatId
        };

        _context.Bookings.Add(booking);
        await _context.SaveChangesAsync();

        return booking;
    }

    public async Task AddAsync(Booking booking)
    {
        await _context.Bookings.AddAsync(booking);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}