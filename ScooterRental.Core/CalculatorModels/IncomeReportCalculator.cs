using System;
using System.Collections.Generic;
using System.Linq;
using ScooterRental.Core;
using ScooterRental.Core.Interfaces;

namespace ScooterRental.Services
{
    public class IncomeReportCalculator : IIncomeReportCalculator
    {
        private readonly IRentalFeeCalculator _calculator;

        public IncomeReportCalculator(IRentalFeeCalculator calculator)
        {
            _calculator = calculator;
        }

        public decimal CalculateIncome(List<Rental> fullRentalList, int? year, bool includeNotCompletedRentals)
        {
            decimal income = 0;
            List<Rental> relevantRentalList;

            if (year.HasValue)
            {
                relevantRentalList = fullRentalList.Where(x => x.RentEnd.HasValue && x.RentEnd.Value.Year == year).ToList();
                income += relevantRentalList.Aggregate(0m, (ac, x) => ac += _calculator.CalculateRentalFee(x));

                if (includeNotCompletedRentals && year == DateTime.Now.Year)
                {
                    relevantRentalList = fullRentalList.Where(x => x.RentEnd == null).ToList();
                    income += relevantRentalList.Aggregate(0m, (ac, x) => ac += _calculator.CalculateRentalFee(x));
                }
            }
            else if (includeNotCompletedRentals)
            {
                income += fullRentalList.Aggregate(0m, (ac, x) => ac += _calculator.CalculateRentalFee(x));
            }
            else
            {
                relevantRentalList = fullRentalList.Where(x => x.RentEnd.HasValue).ToList();
                income += relevantRentalList.Aggregate(0m, (ac, x) => ac += _calculator.CalculateRentalFee(x));
            }

            return income;
        }
    }
}