using ScooterRental.Core.Core_Models;

namespace ScooterRental.Core.ScooterValidations
{
    public interface IScooterValidator
    {
        public bool IsValid(Scooter scooter);
    }
}