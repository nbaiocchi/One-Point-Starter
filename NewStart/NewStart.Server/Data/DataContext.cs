using Microsoft.EntityFrameworkCore;
using NewStart.Server.Models;

namespace NewStart.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<GameModel>? GameModel { get; set; }

        public DbSet<CategoryModel>? CategoryModel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameModel>()
                    .HasMany(x => x.Categories)
                    .WithMany(x => x.Games)
                    .UsingEntity(j => j.ToTable("GameCategory"));

        }
    }
}