using ScooterRental.Core.Interfaces;
using ScooterRental.DB;

namespace ScooterRental.Services
{
    public class ScooterService : DbService, IScooterService
    {
        public ScooterService(IScooterDbContext context) : base(context)
        {
        }
    }
}