using Microsoft.EntityFrameworkCore; // Necesario para UseMySql y Migrate
using Ordenes.Context; // Necesario para el DbContext (OrdenesDbContext)
using Pomelo.EntityFrameworkCore.MySql.Infrastructure; // Necesario para la configuración de MySQL

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (string.IsNullOrEmpty(connectionString))
{
    Console.WriteLine("ADVERTENCIA: Cadena de conexión 'DefaultConnection' no encontrada.");
}

builder.Services.AddDbContext<OrdenesDbContext>(options =>
    options.UseMySql(
        connectionString,
        // AutoDetectará la versión de MySQL usando la cadena de conexión
        ServerVersion.AutoDetect(connectionString),
        mysqlOptions =>
        {
            // Configuración de tolerancia a fallos/reintentos (esencial en Docker)
            mysqlOptions.EnableRetryOnFailure(
                maxRetryCount: 15,
                maxRetryDelay: TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null);
        }
    )
);

// Add services to the container.
builder.Services.AddOpenApi();

var app = builder.Build();

// ====================================================================
// 2. APLICACIÓN DE MIGRACIONES AL INICIO
// ====================================================================
ApplyMigrations(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

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
        // NOTA: Se utiliza OrdenesDbContext para este microservicio
        var dbContext = scope.ServiceProvider.GetRequiredService<OrdenesDbContext>();

        try
        {
            Console.WriteLine("Ordenes: Aplicando migraciones...");
            // Este método crea la base de datos si no existe y aplica todas las migraciones pendientes.
            dbContext.Database.Migrate();
            Console.WriteLine("Ordenes: Migraciones aplicadas con éxito.");
        }
        catch (Exception ex)
        {
            // Captura errores de conexión o migración. 
            Console.WriteLine($"Ordenes: ERROR al aplicar migraciones: {ex.Message}");
            // La configuración de RetryOnFailure en el AddDbContext ayuda a mitigar este error.
        }
    }
}

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}