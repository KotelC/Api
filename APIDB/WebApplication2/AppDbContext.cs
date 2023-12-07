using Microsoft.EntityFrameworkCore;

namespace YourNamespace.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
       
        public void SaveChangesToDb()
        {
            this.SaveChanges();
        }
    }
}
