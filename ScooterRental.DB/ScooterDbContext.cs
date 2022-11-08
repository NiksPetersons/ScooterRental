using Microsoft.EntityFrameworkCore;
using ScooterRental.Core.Core_Models;
using System.Threading.Tasks;

namespace ScooterRental.DB
{
    public class ScooterDbContext : DbContext, IScooterDbContext
    {
        public ScooterDbContext()
        {
        }

        public ScooterDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Scooter> Scooters { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=ScooterRental.db");
        }
    }
}