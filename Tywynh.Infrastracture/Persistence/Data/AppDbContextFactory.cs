using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Tywynh.Infrastracture.Persistence.Data
{
    // This factory is used by EF Core tools at design-time to create an instance of AppDbContext.
    // It provides the DbContext with the necessary configuration (like connection string) when running commands such as migrations.
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            var connectionString = "User Id=postgres.pmewymqmvobxhjtkvsqk;Password=HhGlJYu4tJm4744f;Server=aws-0-ap-southeast-1.pooler.supabase.com;Port=5432;Database=postgres";
            optionsBuilder.UseNpgsql(connectionString);

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}