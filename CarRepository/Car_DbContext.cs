using Microsoft.EntityFrameworkCore;

namespace CarRepository
{
    public class Car_DbContext : DbContext
    {
        public Car_DbContext(DbContextOptions<Car_DbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();

            modelBuilder.Entity<Car>()
                .HasKey(i => i.Id);
            modelBuilder.Entity<Car>()
              .Property(i => i.Id).
              ValueGeneratedOnAdd();

        }
        public DbSet<Car> Cars { get; set; }
    }
}
