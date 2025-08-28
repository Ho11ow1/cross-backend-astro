using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

using DotnetBackend.Services;

namespace DotnetBackend
{
    public class Program
    {
        private static WebApplicationBuilder builder;
        private static WebApplication app;

        public static void Main(string[] args)
        {
            // Create builder
            builder = WebApplication.CreateBuilder(args);
            // Add services and controllers before building
            AddServices();
            AddControllers();
            // Build app making .Services read-only
            app = builder.Build();
            // Map controllers to their endpoints & Add middleware
            SetAppEndpoints();
            // Start the Backend
            app.Run();
        }

        private static void AddServices()
        {
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });

            builder.Services.AddSingleton<TestService>();
        }

        private static void AddControllers()
        {
            builder.Services.AddControllers();
        }

        private static void SetAppEndpoints()
        {
            app.UseCors();
            app.UseHttpsRedirection();
            app.MapControllers();
        }
    }
}
