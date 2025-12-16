namespace CinemaBookingAPI_SOA_CA2_JIanfengHan.Models;

public class Movie
{
    public long Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public int DurationMinutes { get; set; }

    public string Genre { get; set; } = string.Empty;

    public ICollection<Screening> Screenings { get; set; } = new List<Screening>();
}