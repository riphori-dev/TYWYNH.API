using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting.Server;
using Tywynh.Features.Common;
using Tywynh.Features.GetStory;
using Tywynh.Features.PostStory;

namespace Tywynh.API.Endpoints
{
    public static class StoriesEndpoint
    {
        public static void MapStoriesEndpoints(this WebApplication app)
        {
            app.MapPost("/api/stories", async (
                PostStoryCommand request,
                AppMediator mediator) =>
            {
                var command = new PostStoryCommand
                {
                    Text = request.Text,
                    Category = request.Category
                };

                var storyId = await mediator.SendAsync(command);
                return Results.Created($"/api/stories/{storyId}", new { id = storyId });
            })
            .WithName("SaveStoriesAsync")
            .WithOpenApi();

            app.MapGet("/api/stories", async (
                AppMediator mediator) =>
            {
                var command = new GetStoryCommand();
                var stories = await mediator.SendAsync(command);
                return Results.Ok(stories);
            })
            .WithName("GetStoriesAsync")
            .WithOpenApi();
        }
    }
}