using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ScooterRental.Core;

namespace ScooterRental.DB
{
    public interface IScooterDbContext
    {
        public DbSet<Scooter> Scooters { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        DbSet<T> Set<T>() where T : class;
        EntityEntry<T> Entry<T>(T entity) where T : class;
        
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}