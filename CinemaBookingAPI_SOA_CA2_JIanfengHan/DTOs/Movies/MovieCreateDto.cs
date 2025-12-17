namespace CinemaBookingAPI_SOA_CA2_JianfengHan.DTOs.Movies;

public class MovieCreateDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int DurationMinutes { get; set; }
    public string Genre { get; set; }
}