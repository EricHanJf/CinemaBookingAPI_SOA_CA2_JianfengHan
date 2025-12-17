namespace CinemaBookingAPI_SOA_CA2_JianfengHan.DTOs.Screenings;

public class ScreeningReadDto
{
    public long Id { get; set; }
    public long MovieId { get; set; }
    public string MovieTitle { get; set; }

    public DateTime StartTime { get; set; }
    public int HallNumber { get; set; }
}