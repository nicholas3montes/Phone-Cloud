using Microsoft.EntityFrameworkCore;
using Phone_Cloud.models;

namespace Phone_Cloud.Data
{
    public class DbUserContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbUserContext(DbContextOptions<DbUserContext> options) : base(options)
        {
            Users = Set<User>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
        }
    }
}