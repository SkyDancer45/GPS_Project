using GPS.Api.Endpoint;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.MapCarInfoEndpoints();
app.Run();
