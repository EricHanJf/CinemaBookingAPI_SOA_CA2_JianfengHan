using Microsoft.EntityFrameworkCore;

namespace CinemaBookingAPI_SOA_CA2_JIanfengHan.Models;

public class CinemaContext : DbContext
{
    public CinemaContext(DbContextOptions<CinemaContext> options)
        : base(options)
    {
    }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Screening> Screenings { get; set; }
    public DbSet<Seat> Seats { get; set; }
    public DbSet<Booking> Bookings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Prevent double booking of the same seat in the same screening
        modelBuilder.Entity<Booking>()
            .HasIndex(b => new { b.ScreeningId, b.SeatId })
            .IsUnique();
    }
}