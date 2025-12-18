using CinemaBookingAPI_SOA_CA2_JianfengHan.DTOs.Seats;
using CinemaBookingAPI_SOA_CA2_JIanfengHan.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaBookingAPI_SOA_CA2_JianfengHan.Repositories;

public class SeatRepository : ISeatRepository
{
    private readonly CinemaContext _context;

    public SeatRepository(CinemaContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Seat>> GetByHallNumberAsync(int hallNumber)
    {
        return await _context.Seats
            .Where(s => s.HallNumber == hallNumber)
            .ToListAsync();
    }

    public async Task<Seat?> GetByIdAsync(long id)
    {
        return await _context.Seats.FirstOrDefaultAsync(s => s.Id == id);
    }
    
    public async Task<IEnumerable<SeatAvailabilityDto>> GetSeatsForScreeningAsync(long screeningId)
    {
        var screening = await _context.Screenings.FindAsync(screeningId);
        if (screening == null)
            throw new Exception("Screening not found");

        var bookedSeatIds = await _context.Bookings
            .Where(b => b.ScreeningId == screeningId)
            .Select(b => b.SeatId)
            .ToListAsync();

        var seats = await _context.Seats
            .Where(s => s.HallNumber == screening.HallNumber)
            .ToListAsync();

        return seats.Select(s => new SeatAvailabilityDto
        {
            Id = s.Id,
            HallNumber = s.HallNumber,
            Row = s.Row,
            SeatNumber = s.SeatNumber,
            IsAvailable = !bookedSeatIds.Contains(s.Id)
        });
    }

}
