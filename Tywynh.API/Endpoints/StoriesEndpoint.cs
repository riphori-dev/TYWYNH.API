using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting.Server;
using Tywynh.Features.Common;
using Tywynh.Features.GetStory;
using Tywynh.Features.PostStory;
using Tywynh.Features.StoryHeart;

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

            app.MapGet("/api/stories/random", async (
                AppMediator mediator) =>
            {
                var command = new GetRandomStoriesCommand();
                var stories = await mediator.SendAsync(command);
                return Results.Ok(stories);
            })
            .WithName("GetRandomStoriesAsync")
            .WithOpenApi();

            app.MapPost("/api/stories/{id}/heart", async (
                int id,
                AppMediator mediator) =>
            {
                var command = new AddHeartCommand(id);
                var result = await mediator.SendAsync(command);
                return result ? Results.Ok() : Results.NotFound();
            })
            .WithName("AddHeartToStory")
            .WithOpenApi();
        }
    }
}