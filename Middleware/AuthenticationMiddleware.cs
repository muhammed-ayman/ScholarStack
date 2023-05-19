using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

public class AuthenticationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<AuthenticationMiddleware> _logger;

    public AuthenticationMiddleware(RequestDelegate next, ILogger<AuthenticationMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        _logger.LogInformation("AuthenticationMiddleware invoked");

        // Exclude the login page from redirection
        if (!context.Request.Path.StartsWithSegments("/Login"))
        {
            // Check if the user is logged in based on a custom condition
            if (!IsUserLoggedIn(context))
            {
                _logger.LogWarning("User not logged in. Redirecting to the login page.");

                // Redirect to the login page
                context.Response.Redirect("/Login");
                return;
            }
        }

        string userId = context.Session.GetString("UserId");
        _logger.LogInformation($"User {userId} is logged in. Continuing to the next middleware.");

        // Call the next middleware in the pipeline
        await _next(context);
    }

    private bool IsUserLoggedIn(HttpContext context)
    {
        // Add your custom logic to determine if the user is logged in
        // For example, you could check if a specific session variable or cookie is set
        // You can also use other authentication mechanisms, such as JWT, cookies, etc.

        // Return true if the user is logged in; otherwise, return false
        return context.Session.GetString("UserId") != null;
    }
}
