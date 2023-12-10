using Autoservis01.Models.DBEntities;
using Microsoft.EntityFrameworkCore;

namespace Autoservis01.DAL
{
    public class ModelDbContext : DbContext
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ModelDbContext(DbContextOptions<ModelDbContext> options) : base(options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            Options = options;
        }
        public DbSet<Model> Models { get; set; }
        public DbContextOptions Options { get; }
    }

}
