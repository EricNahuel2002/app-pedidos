using Menus.Context;
using Microsoft.EntityFrameworkCore; // Necesario para UseMySql y Migrate
using Pomelo.EntityFrameworkCore.MySql.Infrastructure; // Necesario para la configuración de MySQL

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

var serverVersion = new MySqlServerVersion(new Version(9, 5, 0));

if (string.IsNullOrEmpty(connectionString))
{
    Console.WriteLine("ADVERTENCIA: Cadena de conexión 'DefaultConnection' no encontrada.");
}

builder.Services.AddDbContext<MenuDbContext>(options =>
    options.UseMySql(
        connectionString, serverVersion,
        mysqlOptions => mysqlOptions.MigrationsAssembly(typeof(MenuDbContext).Assembly.FullName)
    )
);

// Add services to the container.
builder.Services.AddOpenApi();

var app = builder.Build();

ApplyMigrations(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// ... (Endpoints de ejemplo originales, como /weatherforecast) ...
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
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

// ====================================================================
// MÉTODO AUXILIAR PARA APLICAR MIGRACIONES
// ====================================================================
static void ApplyMigrations(IApplicationBuilder app)
{
    using (var scope = app.ApplicationServices.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<MenuDbContext>();

        try
        {
            Console.WriteLine("Menus: Aplicando migraciones...");
            // Este método crea la base de datos si no existe y aplica todas las migraciones pendientes.
            dbContext.Database.Migrate();
            Console.WriteLine("Menus: Migraciones aplicadas con éxito.");
        }
        catch (Exception ex)
        {
            // Captura errores de conexión o migración. 
            // Esto sucede a menudo si el contenedor MySQL aún no está listo.
            Console.WriteLine($"Menus: ERROR al aplicar migraciones: {ex.Message}");
            // La configuración de RetryOnFailure en el AddDbContext ayuda a mitigar este error.
        }
    }
}

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}