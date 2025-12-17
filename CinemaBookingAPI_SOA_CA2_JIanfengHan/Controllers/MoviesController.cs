using CinemaBookingAPI_SOA_CA2_JianfengHan.DTOs.Movies;
using CinemaBookingAPI_SOA_CA2_JIanfengHan.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaBookingAPI_SOA_CA2_JianfengHan.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MoviesController : ControllerBase
{
    private readonly CinemaContext _context;

    public MoviesController(CinemaContext context)
    {
        _context = context;
    }
    
    // GET: api/movies
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MovieReadDto>>> GetMovies()
    {
        return await _context.Movies
            .Select(m => new MovieReadDto
            {
                Id = m.Id,
                Title = m.Title,
                DurationMinutes = m.DurationMinutes,
                Genre = m.Genre
            })
            .ToListAsync();
    }
    
    // GET: api/movies/id(1)
    [HttpGet("{id}")]
    public async Task<ActionResult<MovieReadDto>> GetMovie(long id)
    {
        var movie = await _context.Movies.FindAsync(id);

        if (movie == null)
        {
            return NotFound();
        }

        var dto = new MovieReadDto
        {
            Id = movie.Id,
            Title = movie.Title,
            DurationMinutes = movie.DurationMinutes,
            Genre = movie.Genre
        };

        return Ok(dto);
    }
    
    // POST: api/movies
    [HttpPost]
    public async Task<ActionResult<MovieReadDto>> CreateMovie(MovieCreateDto dto)
    {
        var movie = new Movie
        {
            Title = dto.Title,
            Description = dto.Description,
            DurationMinutes = dto.DurationMinutes,
            Genre = dto.Genre
        };

        _context.Movies.Add(movie);
        await _context.SaveChangesAsync();

        var result = new MovieReadDto
        {
            Id = movie.Id,
            Title = movie.Title,
            DurationMinutes = movie.DurationMinutes,
            Genre = movie.Genre
        };

        return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, result);
    }
    
    // PUT: api/movies/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMovie(long id, MovieUpdateDto dto)
    {
        var movie = await _context.Movies.FindAsync(id);

        if (movie == null)
        {
            return NotFound();
        }

        movie.Title = dto.Title;
        movie.Description = dto.Description;
        movie.DurationMinutes = dto.DurationMinutes;
        movie.Genre = dto.Genre;

        await _context.SaveChangesAsync();

        return NoContent();
    }
    
    // DELETE: api/movies/id(1)
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMovie(long id)
    {
        var movie = await _context.Movies.FindAsync(id);
        if (movie == null)
        {
            return NotFound();
        }

        _context.Movies.Remove(movie);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}


