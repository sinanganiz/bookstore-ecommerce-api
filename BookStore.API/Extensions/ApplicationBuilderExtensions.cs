using Microsoft.AspNetCore.Builder;
using Scalar.AspNetCore;
using System.Text;

namespace BookStore.API.Extensions;

public static class ApplicationBuilderExtensions
{
    public static WebApplication ConfigureApplication(this WebApplication app, IConfiguration configuration)
    {
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.MapScalarApiReference();
        }

        app.UseHttpsRedirection();

        // CORS Configuration
        string origin = configuration["Origin"]!;
        app.UseCors(options =>
        {
            options.AllowAnyHeader()
                   .AllowAnyMethod()
                   .AllowCredentials()
                   .WithOrigins(origin);
        });

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        return app;
    }
} 