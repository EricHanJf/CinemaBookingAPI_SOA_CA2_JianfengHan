namespace CinemaBookingAPI_SOA_CA2_JianfengHan.DTOs.Seats;

public class SeatReadDto
{
    public long Id { get; set; }

    public int HallNumber { get; set; }

    public string Row { get; set; } = "";

    public int SeatNumber { get; set; }

    // public bool IsAvailable { get; set; }
}