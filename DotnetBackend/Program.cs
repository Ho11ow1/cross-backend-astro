var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
<<<<<<< Updated upstream
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
=======
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
>>>>>>> Stashed changes
}
