using CinemaBookingAPI_SOA_CA2_JIanfengHan.Models;
using CinemaBookingAPI_SOA_CA2_JianfengHan.Repositories;
using CinemaBookingAPI_SOA_CA2_JianfengHan.Services;
using Microsoft.EntityFrameworkCore;

namespace CinemaBookingAPI_SOA_CA2_JianfengHan;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();

        //Repository
        builder.Services.AddScoped<IMovieRepository, MovieRepository>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        
        // DbContext - SQLite (persistent storage for CA)
        builder.Services.AddDbContext<CinemaContext>(
            opt => opt.UseSqlite("Data Source=cinema.db")
        );
        
        //Service
        builder.Services.AddScoped<IAuthService, AuthService>();
        
        // Swagger
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}