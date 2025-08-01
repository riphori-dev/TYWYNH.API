using Tywynh.Domain.Interfaces;

namespace Tywynh.API.Endpoints
{
    public static class LogEndpoint
    {
        public static void MapLogEndpoints(this WebApplication app)
        {
            app.MapGet("/api/logs", async (ILogRepository logRepository) =>
            {
                var logs = await logRepository.GetAllAsync();
                return Results.Ok(logs);
            })
            .WithName("GetRequestLogs")
            .WithOpenApi();
        }
    }
}