using Microsoft.EntityFrameworkCore;
using ToDoService.Entities;

namespace ToDoService.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mission>().HasData(new Mission { Id = 1, Title = "First Task" });
            modelBuilder.Entity<Mission>().HasData(new Mission { Id = 2, Title = "Second Task" });
            base.OnModelCreating(modelBuilder); 
        }

        public DbSet<Mission> Missions { get; set; }
    }
}
