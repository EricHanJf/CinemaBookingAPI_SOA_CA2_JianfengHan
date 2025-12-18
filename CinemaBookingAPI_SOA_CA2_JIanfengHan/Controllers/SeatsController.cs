using CinemaBookingAPI_SOA_CA2_JianfengHan.DTOs.Seats;
using CinemaBookingAPI_SOA_CA2_JianfengHan.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CinemaBookingAPI_SOA_CA2_JianfengHan.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SeatsController : ControllerBase
{
    private readonly ISeatRepository _seatRepository;

    public SeatsController(ISeatRepository seatRepository)
    {
        _seatRepository = seatRepository;
    }

    // GET: api/seats/hall/1
    [HttpGet("hall/{hallNumber}")]
    public async Task<ActionResult<IEnumerable<SeatReadDto>>> GetSeatsByHall(int hallNumber)
    {
        var seats = await _seatRepository.GetByHallNumberAsync(hallNumber);

        return Ok(seats.Select(s => new SeatReadDto
        {
            Id = s.Id,
            HallNumber = s.HallNumber,
            Row = s.Row,
            SeatNumber = s.SeatNumber
        }));
    }
    
    // GET: api/seats/screening/1
    [HttpGet("screening/{screeningId}")]
    public async Task<ActionResult<IEnumerable<SeatReadDto>>> GetSeatsForScreening(long screeningId)
    {
        var result = await _seatRepository.GetSeatsForScreeningAsync(screeningId);
        return Ok(result);
    }
}
