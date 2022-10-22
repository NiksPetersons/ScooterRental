namespace ScooterRental.Core.Interfaces
{
    public interface IRentalService
    {
        Rental StartRentById(int id);
        void StopRent(Rental rental);
        decimal CalculateRentFee(Rental rental);
        Rental GetUnfinishedRentalByScooterId(int id);
    }
}