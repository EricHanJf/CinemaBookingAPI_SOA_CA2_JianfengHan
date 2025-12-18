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
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Prevent double booking of the same seat in the same screening
        modelBuilder.Entity<Booking>()
            .HasIndex(b => new { b.ScreeningId, b.SeatId })
            .IsUnique();
        
        modelBuilder.Entity<Seat>().HasData(
            new Seat { Id = 1, HallNumber = 1, Row = "A", SeatNumber = 1 },
            new Seat { Id = 2, HallNumber = 1, Row = "A", SeatNumber = 2 },
            new Seat { Id = 3, HallNumber = 1, Row = "A", SeatNumber = 3 },
            new Seat { Id = 4, HallNumber = 1, Row = "B", SeatNumber = 1 },
            new Seat { Id = 5, HallNumber = 1, Row = "B", SeatNumber = 2 },
            new Seat { Id = 6, HallNumber = 1, Row = "B", SeatNumber = 3 },
            new Seat { Id = 7, HallNumber = 1, Row = "C", SeatNumber = 1 },
            new Seat { Id = 8, HallNumber = 1, Row = "C", SeatNumber = 2 },
            new Seat { Id = 9, HallNumber = 1, Row = "C", SeatNumber = 3 },
            new Seat { Id = 10, HallNumber = 1, Row = "D", SeatNumber = 1 },
            new Seat { Id = 11, HallNumber = 1, Row = "D", SeatNumber = 2 },
            new Seat { Id = 12, HallNumber = 1, Row = "D", SeatNumber = 3 },
            new Seat { Id = 13, HallNumber = 1, Row = "D", SeatNumber = 4 },
            new Seat { Id = 14, HallNumber = 2, Row = "A", SeatNumber = 1 },
            new Seat { Id = 15, HallNumber = 2, Row = "A", SeatNumber = 2 },
            new Seat { Id = 16, HallNumber = 2, Row = "A", SeatNumber = 3 },
            new Seat { Id = 17, HallNumber = 2, Row = "B", SeatNumber = 1 },
            new Seat { Id = 18, HallNumber = 2, Row = "B", SeatNumber = 2 },
            new Seat { Id = 19, HallNumber = 2, Row = "B", SeatNumber = 3 },
            new Seat { Id = 20, HallNumber = 2, Row = "C", SeatNumber = 1 },
            new Seat { Id = 21, HallNumber = 2, Row = "C", SeatNumber = 2 },
            new Seat { Id = 22, HallNumber = 2, Row = "C", SeatNumber = 3 },
            new Seat { Id = 23, HallNumber = 2, Row = "C", SeatNumber = 4 },
            new Seat { Id = 24, HallNumber = 2, Row = "D", SeatNumber = 1 },
            new Seat { Id = 25, HallNumber = 2, Row = "D", SeatNumber = 2 },
            new Seat { Id = 26, HallNumber = 2, Row = "D", SeatNumber = 3 },
            new Seat { Id = 27, HallNumber = 2, Row = "D", SeatNumber = 4 }
        );
    }
    
    
}