using CinemaBookingAPI_SOA_CA2_JianfengHan.DTOs.Movies;
using CinemaBookingAPI_SOA_CA2_JIanfengHan.Models;
using CinemaBookingAPI_SOA_CA2_JianfengHan.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaBookingAPI_SOA_CA2_JianfengHan.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MoviesController : ControllerBase
{
    private readonly IMovieRepository _movieRepository;

    public MoviesController(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }
    
    // GET: api/movies
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MovieReadDto>>> GetMovies()
    {
        var movies = await _movieRepository.GetAllAsync();

        return Ok(movies.Select(m => new MovieReadDto
        {
            Id = m.Id,
            Title = m.Title,
            DurationMinutes = m.DurationMinutes,
            Genre = m.Genre
        }));
    }
    
    // GET: api/movies/id(1)
    [HttpGet("{id}")]
    public async Task<ActionResult<MovieReadDto>> GetMovie(long id)
    {
        var movie = await _movieRepository.GetByIdAsync(id);

        if (movie == null)
            return NotFound();

        return Ok(new MovieReadDto
        {
            Id = movie.Id,
            Title = movie.Title,
            DurationMinutes = movie.DurationMinutes,
            Genre = movie.Genre
        });
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

        await _movieRepository.AddAsync(movie);

        return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, new MovieReadDto
        {
            Id = movie.Id,
            Title = movie.Title,
            DurationMinutes = movie.DurationMinutes,
            Genre = movie.Genre
        });
    }
    
    // PUT: api/movies/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMovie(long id, MovieUpdateDto dto)
    {
        var movie = await _movieRepository.GetByIdAsync(id);

        if (movie == null)
            return NotFound();

        movie.Title = dto.Title;
        movie.Description = dto.Description;
        movie.DurationMinutes = dto.DurationMinutes;
        movie.Genre = dto.Genre;

        await _movieRepository.UpdateAsync(movie);

        return NoContent();
    }

    // DELETE: api/movies/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMovie(long id)
    {
        var movie = await _movieRepository.GetByIdAsync(id);

        if (movie == null)
            return NotFound();

        await _movieRepository.DeleteAsync(movie);

        return NoContent();
    }
}


