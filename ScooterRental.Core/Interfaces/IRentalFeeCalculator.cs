using ScooterRental.Core.Core_Models;

namespace ScooterRental.Core.Interfaces
{
    public interface IRentalFeeCalculator
    {
        decimal CalculateRentalFee(Rental rental);
    }
}