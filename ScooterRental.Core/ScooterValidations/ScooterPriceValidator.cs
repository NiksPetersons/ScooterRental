namespace ScooterRental.Core.ScooterValidations
{
    public class ScooterPriceValidator : IScooterValidator
    {
        public bool IsValid(Scooter scooter)
        {
            if (scooter.PricePerMinute <= 0)
            {
                return false;
            }
            
            return true;
        }
    }
}