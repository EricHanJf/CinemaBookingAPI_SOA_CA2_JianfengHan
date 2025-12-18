using CinemaBookingAPI_SOA_CA2_JIanfengHan.Models;
using CinemaBookingAPI_SOA_CA2_JianfengHan.Repositories;

namespace CinemaBookingApiTest;

[TestClass]
public class BookingRepositoryTests
{
    [TestMethod]
    public async Task AddAsync_ShouldAddBooking()
    {
        // Arrange
        var context = TestDbContextFactory.Create();
        var repo = new BookingRepository(context);

        var booking = new Booking
        {
            UserId = 1,
            ScreeningId = 1,
            SeatId = 1
        };

        // Act
        await repo.AddAsync(booking);
        await repo.SaveChangesAsync();

        // Assert
        Assert.AreEqual(1, context.Bookings.Count());
    }
    
    [TestMethod]
    public async Task GetByUserIdAsync_ShouldReturnOnlyUsersBookings()
    {
        // Arrange
        var context = TestDbContextFactory.Create();
        context.Bookings.AddRange(
            new Booking { UserId = 1, ScreeningId = 1, SeatId = 1 },
            new Booking { UserId = 2, ScreeningId = 1, SeatId = 2 }
        );
        await context.SaveChangesAsync();

        var repo = new BookingRepository(context);

        // Act
        var result = await repo.GetByUserIdAsync(1);

        // Assert
        Assert.AreEqual(1, result.Count());
        Assert.AreEqual(1, result.First().UserId);
    }
}