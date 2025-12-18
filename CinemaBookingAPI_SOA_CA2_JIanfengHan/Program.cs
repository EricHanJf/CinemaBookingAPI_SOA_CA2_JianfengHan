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
        builder.Services.AddScoped<IBookingRepository, BookingRepository>();
        builder.Services.AddScoped<ISeatRepository, SeatRepository>();
        
        // DbContext - SQLite (persistent storage for CA)
        builder.Services.AddDbContext<CinemaContext>(
            opt => opt.UseSqlite("Data Source=cinema.db")
        );
        
        //Service
        builder.Services.AddScoped<IAuthService, AuthService>();
        
        // Swagger
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        builder.Services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("ApiKey", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Description = "API Key needed to access the endpoints. X-API-KEY: {key}",
                In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                Name = "X-API-KEY",
                Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey
            });

            c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
            {
                {
                    new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                    {
                        Reference = new Microsoft.OpenApi.Models.OpenApiReference
                        {
                            Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                            Id = "ApiKey"
                        }
                    },
                    new string[] {}
                }
            });
        });


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        // if (app.Environment.IsDevelopment())
        // {
        //     app.UseSwagger();
        //     app.UseSwaggerUI();
        // }
        using (var scope = app.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<CinemaContext>();
            // db.Database.Migrate();
            db.Database.EnsureCreated(); // for railway deploy
        }
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}