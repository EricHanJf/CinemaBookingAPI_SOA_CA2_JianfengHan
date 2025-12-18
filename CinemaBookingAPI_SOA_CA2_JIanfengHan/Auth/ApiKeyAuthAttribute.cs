using CinemaBookingAPI_SOA_CA2_JIanfengHan.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace CinemaBookingAPI_SOA_CA2_JianfengHan.Auth;

public class ApiKeyAuthAttribute : Attribute, IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(
        ActionExecutingContext context,
        ActionExecutionDelegate next)
    {
        if (!context.HttpContext.Request.Headers.TryGetValue("X-API-KEY", out var apiKeyHeader))
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        var apiKey = apiKeyHeader.ToString();

        var db = context.HttpContext.RequestServices.GetRequiredService<CinemaContext>();

        var user = await db.Users.FirstOrDefaultAsync(u => u.ApiKey == apiKey);
        if (user == null)
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        // Attach authenticated user info to request context
        context.HttpContext.Items["UserId"] = user.Id;

        await next();
    }
}