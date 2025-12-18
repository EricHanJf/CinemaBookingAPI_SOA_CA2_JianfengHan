using CinemaBookingAPI_SOA_CA2_JIanfengHan.Models;
using CinemaBookingAPI_SOA_CA2_JianfengHan.Repositories;

namespace CinemaBookingApiTest;

[TestClass]
public class SeatRepositoryTests
{
    [TestMethod]
    public async Task GetByHallNumberAsync_ShouldReturnCorrectSeats()
    {
        // Arrange
        var context = TestDbContextFactory.Create();
        context.Seats.AddRange(
            new Seat { HallNumber = 1, Row = "A", SeatNumber = 1 },
            new Seat { HallNumber = 2, Row = "A", SeatNumber = 1 }
        );
        await context.SaveChangesAsync();

        var repo = new SeatRepository(context);

        // Act
        var seats = await repo.GetByHallNumberAsync(1);

        // Assert
        Assert.AreEqual(1, seats.Count());
        Assert.AreEqual(1, seats.First().HallNumber);
    }
    
    [TestMethod]
    public async Task GetByUserIdAsync_NoBookings_ShouldReturnEmpty()
    {
        // Arrange
        var context = TestDbContextFactory.Create();
        var repo = new BookingRepository(context);

        // Act
        var result = await repo.GetByUserIdAsync(999);

        // Assert
        Assert.AreEqual(0, result.Count());
    }
    
    [TestMethod]
    public async Task AddAsync_AllowsDuplicateSeatBooking_CurrentLimitation()
    {
        // Arrange
        var context = TestDbContextFactory.Create();
        var repo = new BookingRepository(context);

        await repo.AddAsync(new Booking { UserId = 1, ScreeningId = 1, SeatId = 1 });
        await repo.AddAsync(new Booking { UserId = 2, ScreeningId = 1, SeatId = 1 });
        await repo.SaveChangesAsync();

        // Assert
        Assert.AreEqual(2, context.Bookings.Count());
    }
}