using CinemaBookingAPI_SOA_CA2_JianfengHan.DTOs.Seats;
using CinemaBookingAPI_SOA_CA2_JIanfengHan.Models;

namespace CinemaBookingAPI_SOA_CA2_JianfengHan.Repositories;

public interface ISeatRepository
{
    Task<IEnumerable<Seat>> GetByHallNumberAsync(int hallNumber);
    Task<Seat?> GetByIdAsync(long id);
    // Task<IEnumerable<Seat>> GetSeatsForScreeningAsync(long screeningId);
    Task<IEnumerable<SeatAvailabilityDto>> GetSeatsForScreeningAsync(long screeningId);
}