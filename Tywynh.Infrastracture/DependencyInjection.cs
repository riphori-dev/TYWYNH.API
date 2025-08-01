using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tywynh.Domain.Interfaces;
using Tywynh.Infrastracture.Persistence.Data;
using Tywynh.Infrastracture.Repositories;

namespace Tywynh.Infrastracture
{
    public static class DependencyInjection 
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Register your infrastructure services here
            // For example, you might register a database context, repositories, etc.
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(connectionString));
            services.AddScoped<IStoryRepository, StoryRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ILogRepository, LogRepository>();
            services.AddScoped<IUpliftingThoughtService, ThoughtService>();
            return services;
        }
    }
}
