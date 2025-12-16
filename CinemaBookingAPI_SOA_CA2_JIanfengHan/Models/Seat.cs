namespace CinemaBookingAPI_SOA_CA2_JIanfengHan.Models;

public class Seat
{
    public long Id { get; set; }

    public int HallNumber { get; set; }

    public string Row { get; set; } = string.Empty;

    public int SeatNumber { get; set; }

    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}