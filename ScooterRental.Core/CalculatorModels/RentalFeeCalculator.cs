using System;
using ScooterRental.Core;
using ScooterRental.Core.Interfaces;

namespace ScooterRental.Services
{
    public class RentalFeeCalculator : IRentalFeeCalculator
    {
        public decimal CalculateRentalFee(Rental rental)
        {
            decimal totalFee = 0;
            DateTime rentEnd = rental.RentEnd ?? DateTime.Now;
            DateTime rentStart = rental.RentStart;
            decimal pricePerMinute = rental.PricePerMinute;

            if ((rentEnd - rentStart).Days == 0)
            {
                TimeSpan differenceTimeSpan = rentEnd - rentStart;
                var totalMinutes = Math.Ceiling(differenceTimeSpan.TotalMinutes);

                if ((decimal)totalMinutes * rental.PricePerMinute > 20m)
                {
                    totalFee = 20m;
                }
                else
                {
                    totalFee = (decimal)totalMinutes * pricePerMinute;
                }
            }
            else
            {
                var firstDayIncome = (decimal)(rentStart.Date.AddDays(1) - rentStart).TotalMinutes * pricePerMinute;

                if (firstDayIncome > 20m)
                {
                    firstDayIncome = 20m;
                }

                var lastDayIncome = (decimal)(rentEnd - rentEnd.Date).TotalMinutes * pricePerMinute;

                if (lastDayIncome > 20m)
                {
                    lastDayIncome = 20m;
                }

                var daysBetween = (rentEnd.AddDays(-1) - rentStart).Days;
                decimal betweenIncome = daysBetween * 20m;
                totalFee = firstDayIncome + lastDayIncome + betweenIncome;
            }

            return totalFee;
        }
    }
}