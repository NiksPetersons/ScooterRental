namespace ScooterRental.Core.Interfaces
{
    public interface IRentalFeeCalculator
    {
        decimal CalculateRentalFee(Rental rental);
    }
}