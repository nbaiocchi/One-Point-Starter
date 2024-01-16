using Microsoft.EntityFrameworkCore;
using NewStart.Server.Models;

namespace NewStart.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<TodoModel> Todo { get; set; }
    }
}
