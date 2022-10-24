using System;

namespace ScooterRental.Core
{
    public class Rental : Entity
    {
        public int ScooterId { get; set; }
        public decimal PricePerMinute { get; set; }
        public DateTime RentStart { get; set; }
        public DateTime? RentEnd { get; set; }

        public Rental(decimal pricePerMinute, int scooterId)
        {
            PricePerMinute = pricePerMinute;
            ScooterId = scooterId;
            RentStart = DateTime.Now;
            RentEnd = null;
        }

        public Rental(decimal pricePerMinute, int scooterId, DateTime rentStart)
        {
            PricePerMinute = pricePerMinute;
            ScooterId = scooterId;
            RentStart = rentStart;
            RentEnd = null;
        }

        public Rental(decimal pricePerMinute, int scooterId, DateTime rentStart, DateTime rentEnd)
        {
            PricePerMinute = pricePerMinute;
            ScooterId = scooterId;
            RentStart = rentStart;
            RentEnd = rentEnd;
        }
    }
}