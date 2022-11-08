using ScooterRental.Core.Core_Models;

namespace ScooterRental.Core.ScooterValidations
{
    public class ScooterIsRentedValidator : IScooterValidator
    {
        public bool IsValid(Scooter scooter)
        {
            if (scooter.IsRented)
            {
                return false;
            }

            return true;
        }
    }
}