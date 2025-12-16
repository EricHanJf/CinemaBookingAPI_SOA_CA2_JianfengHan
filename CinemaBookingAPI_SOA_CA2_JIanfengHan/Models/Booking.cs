namespace CinemaBookingAPI_SOA_CA2_JIanfengHan.Models;

public class Booking
{
    public long Id { get; set; }

    public long ScreeningId { get; set; }
    public Screening Screening { get; set; } = null!;

    public long SeatId { get; set; }
    public Seat Seat { get; set; } = null!;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}