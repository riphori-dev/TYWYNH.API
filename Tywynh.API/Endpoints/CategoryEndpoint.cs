using Tywynh.Features.Category;
using Tywynh.Features.Common;

namespace Tywynh.API.Endpoints
{
    public static class CategoryEndpoint
    {
        public static void MapCategoryEndpoints(this WebApplication app)
        {
            app.MapPost("/api/categories", async (CreateCategoryCommand request, AppMediator mediator) =>
            {       
                var id = await mediator.SendAsync(request);
                return Results.Created($"/api/categories/{id}", new { id });
            })
            .WithName("CreateCategory")
            .WithOpenApi();

            app.MapGet("/api/categories", async (AppMediator mediator) =>
            {
                var query = new GetCategoriesQuery();
                var categories = await mediator.SendAsync(query);
                return Results.Ok(categories);
            })
            .WithName("GetCategories")
            .WithOpenApi();
        }
    }
}