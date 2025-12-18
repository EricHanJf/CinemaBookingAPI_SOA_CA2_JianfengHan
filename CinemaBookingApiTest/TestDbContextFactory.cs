using CinemaBookingAPI_SOA_CA2_JIanfengHan.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaBookingApiTest;

public class TestDbContextFactory
{
    public static CinemaContext Create()
    {
        var options = new DbContextOptionsBuilder<CinemaContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        return new CinemaContext(options);
    }
}