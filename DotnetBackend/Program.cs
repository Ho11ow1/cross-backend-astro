using DotnetBackend.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;

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
                    policy.WithOrigins("http://localhost:4321", "http://localhost:3000")
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            // Using this method will result in the actual propertyNameCase
            builder.Services.AddControllers().AddJsonOptions(options => {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });

            // Using this method will result in camelCase json
            //builder.Services.ConfigureHttpJsonOptions(options => {
            //    options.SerializerOptions.PropertyNamingPolicy = null;
            //});

            builder.Services.AddSingleton<TestService>();
            builder.Services.AddSingleton<DatabaseService>();
        }

        private static void AddControllers()
        {
            builder.Services.AddControllers();
        }

        private static void SetAppEndpoints()
        {
            app.UseCors();
            app.MapControllers();
            // Commented out for local http testing
            //app.UseHttpsRedirection();
        }
    }
}
