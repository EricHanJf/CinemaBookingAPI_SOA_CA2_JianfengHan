namespace CinemaBookingAPI_SOA_CA2_JianfengHan.DTOs.Screenings;

public class ScreeningCreateDto
{
    public long MovieId { get; set; }
    public DateTime StartTime { get; set; }
    public int HallNumber { get; set; }
}