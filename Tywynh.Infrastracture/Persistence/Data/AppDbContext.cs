using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tywynh.Domain.Models;

namespace Tywynh.Infrastracture.Persistence.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
            public DbSet<Story> Stories { get; set; }   

            public DbSet<Category> Categories { get; set; }

            public DbSet<RequestLog> RequestLogs { get; set; }
    }
}
