namespace CinemaBookingAPI_SOA_CA2_JianfengHan.DTOs.Bookings;

public class BookingReadDto
{
    public long Id { get; set; }
    public long ScreeningId { get; set; }
    public long SeatId { get; set; }
    public DateTime CreatedAt { get; set; }
}