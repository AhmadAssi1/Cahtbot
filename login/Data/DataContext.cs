using login.models;
using Microsoft.EntityFrameworkCore;

namespace login.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base( options)
        {

        }
        public DbSet<Agents> Agents { get; set; }
        public DbSet<user> Users { get; set; }
        public DbSet<clients> Clients { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure your model relationships and constraints here if needed
            base.OnModelCreating(modelBuilder);
        }

    }
}
