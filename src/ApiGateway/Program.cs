using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
builder.Services.AddOpenApi();
builder.Services.AddOcelot(builder.Configuration);

builder.Configuration.SetBasePath(builder.Environment.ContentRootPath).AddOcelot();


var app = builder.Build();

app.UseRouting();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

await app.UseOcelot();
await app.RunAsync();
