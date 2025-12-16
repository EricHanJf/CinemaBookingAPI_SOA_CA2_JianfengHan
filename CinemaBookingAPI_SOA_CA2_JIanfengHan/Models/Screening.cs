namespace CinemaBookingAPI_SOA_CA2_JIanfengHan.Models;

public class Screening
{
    public long Id { get; set; }

    public long MovieId { get; set; }
    public Movie Movie { get; set; } = null!;

    public DateTime StartTime { get; set; }

    public int HallNumber { get; set; }

    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}