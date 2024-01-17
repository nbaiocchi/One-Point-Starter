using Microsoft.EntityFrameworkCore;
using NewStart.Server.Models;

namespace NewStart.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Autres configurations...

            modelBuilder.Entity<PostModelTagModel>().HasNoKey();
        }

        public DbSet<TodoModel> Todo { get; set; }

        public DbSet<TagModel> Tag { get; set; }

        public DbSet<PostModel> Post { get; set; }

        public DbSet<PostModelTagModel> PostTag { get; set; }
    }
}
