using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tywynh.Domain.Models;
using Tywynh.Features.Common;
using Tywynh.Features.GetStory;
using Tywynh.Features.PostStory;

namespace Tywynh.Features
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddFeatures(this IServiceCollection services)
        {
            // Register the AppMediator
            services.AddScoped<AppMediator>();
            services.AddScoped<IRequestHandler<PostStoryCommand, int>, PostStoryHandler>();
            services.AddScoped<IRequestHandler<GetStoryCommand, List<Story>>, GetStoryHandler>();

            return services;
        }
    }
}
