using SmartMeets.Models;

namespace SmartMeets.Data
{
    public class SmartMeetsDBContext : DbContext
    {
        public SmartMeetsDBContext(DbContextOptions options) : base (options)
        {
            
        }
        
        public DbSet<User> User { get; set; }
        //public DbSet<Meeting> Meeting { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u=>u.UserID);
            modelBuilder.Entity<User>().Property(u=>u.FirstName).IsRequired().HasMaxLength(100);
            
        }

    }
    
}
