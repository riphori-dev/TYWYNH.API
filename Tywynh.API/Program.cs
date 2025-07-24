using Tywynh.API.Endpoints;
using Tywynh.API.Middleware;
using Tywynh.Features;
using Tywynh.Infrastracture;

AppContext.SetSwitch("System.Net.Sockets.Socket.OSSupportsIPv6", false);

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddFeatures();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Add this line before other middlewares
app.UseMiddleware<ExceptionHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapStoriesEndpoints();
app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
