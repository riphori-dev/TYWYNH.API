using Microsoft.AspNetCore.Mvc;
using Tywynh.Domain.Interfaces;
using Tywynh.Features.Common;
using Tywynh.Features.UpliftingThought;

namespace Tywynh.API.Endpoints
{
    public static class ThoughtEndpoint
    {
        public static void MapThoughtEndpoint(this WebApplication app)
        {
            app.MapGet("/api/thoughts", async (string query, AppMediator mediator) =>
            {
                var request = new UplifingThoughtCommand(query);
                var thoughts = await mediator.SendAsync(request);
                return Results.Ok(thoughts);
            })
      .WithName("GetThoughts")
      .WithOpenApi();
        }
    }
}
