using CinemaBookingAPI_SOA_CA2_JianfengHan.Auth;
using CinemaBookingAPI_SOA_CA2_JianfengHan.DTOs.Bookings;
using CinemaBookingAPI_SOA_CA2_JIanfengHan.Models;
using CinemaBookingAPI_SOA_CA2_JianfengHan.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CinemaBookingAPI_SOA_CA2_JianfengHan.Controllers;

[ApiController]
[Route("api/[controller]")]
[ApiKeyAuth] // must be login 
public class BookingsController : ControllerBase
{
    private readonly IBookingRepository _bookingRepository;

    public BookingsController(IBookingRepository bookingRepository)
    {
        _bookingRepository = bookingRepository;
    }

    // GET: api/bookings/my
    [HttpGet("my")]
    public async Task<ActionResult<IEnumerable<BookingReadDto>>> GetMyBookings()
    {
        var userId = (int)HttpContext.Items["UserId"]!;

        var bookings = await _bookingRepository.GetByUserIdAsync(userId);

        return Ok(bookings.Select(b => new BookingReadDto
        {
            Id = b.Id,
            ScreeningId = b.ScreeningId,
            SeatId = b.SeatId,
            CreatedAt = b.CreatedAt
        }));
    }

    // POST: api/bookings
    [HttpPost]
    public async Task<IActionResult> CreateBooking(BookingCreateDto dto)
    {
        var userId = (int)HttpContext.Items["UserId"]!;

        try
        {
            await _bookingRepository.CreateBookingAsync(
                userId,
                dto.ScreeningId,
                dto.SeatId
            );

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}