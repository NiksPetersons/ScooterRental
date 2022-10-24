namespace ScooterRental.Core
{
    public class Scooter : Entity
    {
        public Scooter(decimal pricePerMinute)
        {
            PricePerMinute = pricePerMinute;
            IsRented = false;
        }
        
        public decimal PricePerMinute { get; set; }
        public bool IsRented { get; set; }
    }
}
