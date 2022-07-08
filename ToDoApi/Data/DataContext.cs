using Microsoft.EntityFrameworkCore;
using ToDoApi.Entities;

namespace ToDoApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

       
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
            modelBuilder.Entity<Mission>().HasData(new Mission { Id = 1, Title = "First Task" });
            modelBuilder.Entity<Mission>().HasData(new Mission { Id = 2, Title = "Second Task" });
         
        }

        public DbSet<Mission> Missions { get; set; }
    }
}
