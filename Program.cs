using GPS.Api.Endpoint;
using GPS.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Retrieve the connection string
var connstring = builder.Configuration.GetConnectionString("Gps");

// Register DbContext with DI
builder.Services.AddDbContext<GpsContext>(options =>
    options.UseSqlite(connstring));

var app = builder.Build();

// Apply migrations and seed data
app.MigrateDb();

// Map endpoints
app.MapUserInfoEndpoints();
app.MapCarInfoEndpoints();

app.Run();