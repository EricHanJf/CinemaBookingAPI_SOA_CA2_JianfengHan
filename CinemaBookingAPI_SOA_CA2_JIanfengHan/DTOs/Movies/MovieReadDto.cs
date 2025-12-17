namespace CinemaBookingAPI_SOA_CA2_JianfengHan.DTOs.Movies;

public class MovieReadDto
{
    public long Id { get; set; }
    public string Title { get; set; }
    public int DurationMinutes { get; set; }
    public string Genre { get; set; }
}