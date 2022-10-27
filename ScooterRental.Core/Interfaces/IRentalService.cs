using ScooterRental.Core.Core_Models;

namespace ScooterRental.Core.Interfaces
{
    public interface IRentalService
    {
        Rental StartRent(Scooter scooter);
        void StopRent(Rental rental);
        decimal CalculateRentFee(Rental rental);
        Rental GetUnfinishedRentalByScooterId(int id);
    }
}