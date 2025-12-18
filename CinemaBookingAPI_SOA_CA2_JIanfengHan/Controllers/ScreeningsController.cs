using CinemaBookingAPI_SOA_CA2_JianfengHan.DTOs.Screenings;
using CinemaBookingAPI_SOA_CA2_JIanfengHan.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaBookingAPI_SOA_CA2_JianfengHan.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ScreeningsController : ControllerBase
{
    private readonly CinemaContext _context;

    public ScreeningsController(CinemaContext context)
    {
        _context = context;
    }

    // GET: api/screenings
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ScreeningReadDto>>> GetScreenings()
    {
        return await _context.Screenings
            .Include(s => s.Movie)
            .Select(s => new ScreeningReadDto
            {
                Id = s.Id,
                MovieId = s.MovieId,
                MovieTitle = s.Movie.Title,
                StartTime = s.StartTime,
                HallNumber = s.HallNumber
            })
            .ToListAsync();
    }

    // GET: api/screenings/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ScreeningReadDto>> GetScreening(long id)
    {
        var screening = await _context.Screenings
            .Include(s => s.Movie)
            .FirstOrDefaultAsync(s => s.Id == id);

        if (screening == null)
            return NotFound();

        return new ScreeningReadDto
        {
            Id = screening.Id,
            MovieId = screening.MovieId,
            MovieTitle = screening.Movie.Title,
            StartTime = screening.StartTime,
            HallNumber = screening.HallNumber
        };
    }

    // POST: api/screenings
    [HttpPost]
    public async Task<ActionResult<ScreeningReadDto>> CreateScreening(ScreeningCreateDto dto)
    {
        var movieExists = await _context.Movies.AnyAsync(m => m.Id == dto.MovieId);
        if (!movieExists)
            return BadRequest("Movie does not exist.");

        var screening = new Screening
        {
            MovieId = dto.MovieId,
            StartTime = dto.StartTime,
            HallNumber = dto.HallNumber
        };

        _context.Screenings.Add(screening);
        await _context.SaveChangesAsync();

        var movie = await _context.Movies.FindAsync(dto.MovieId);

        return CreatedAtAction(nameof(GetScreening), new { id = screening.Id },
            new ScreeningReadDto
            {
                Id = screening.Id,
                MovieId = screening.MovieId,
                MovieTitle = movie!.Title,
                StartTime = screening.StartTime,
                HallNumber = screening.HallNumber
            });
    }

    // PUT: api/screenings/1
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateScreening(long id, ScreeningUpdateDto dto)
    {
        var screening = await _context.Screenings.FindAsync(id);
        if (screening == null)
            return NotFound();

        screening.StartTime = dto.StartTime;
        screening.HallNumber = dto.HallNumber;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    // DELETE: api/screenings/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteScreening(long id)
    {
        var screening = await _context.Screenings.FindAsync(id);
        if (screening == null)
            return NotFound();

        _context.Screenings.Remove(screening);
        await _context.SaveChangesAsync();

        return NoContent();
    }
    
}