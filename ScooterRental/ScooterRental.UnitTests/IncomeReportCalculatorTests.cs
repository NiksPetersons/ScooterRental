using FluentAssertions;
using ScooterRental.Core.CalculatorModels;
using ScooterRental.Core.Core_Models;
using ScooterRental.Core.Interfaces;
using System;
using System.Collections.Generic;
using Xunit;

namespace ScooterRental.UnitTests
{
    public class IncomeReportCalculatorTests
    {
        private readonly IIncomeReportCalculator _calculator;

        public IncomeReportCalculatorTests()
        {
            var feeCalc = new RentalFeeCalculator();
            _calculator = new IncomeReportCalculator(feeCalc);
        }

        [Theory]
        [InlineData(2020, false, 38.2)]
        [InlineData(2020, true, 38.2)]
        [InlineData(null, false, 60.2)]
        [InlineData(2022, true, 24.2)]
        [InlineData(null, true, 62.4)]
        public void RentalCompany_CalculateIncome_ShouldReturnCorrectDecimal(int? year
            , bool includeNotCompletedRentals, decimal expected)
        {
            List<Rental> rentalHistory = SimulateRentalHistory();
            
            _calculator.CalculateIncome(rentalHistory ,year, includeNotCompletedRentals).Should().Be(expected);
        }

        private List<Rental> SimulateRentalHistory()
        {
            var rentalHistory = new List<Rental>
            {
                new (0.2m, 1
                , new DateTime(2020, 01, 01, 0, 0, 0)
                , new DateTime(2020, 01, 01, 0, 1, 0)),//0.2
                new (0.3m, 1
                , new DateTime(2020, 01, 01, 0, 0, 0)
                , new DateTime(2020, 01, 01, 1, 0, 0)),//18
                new (0.25m, 1
                , new DateTime(2020, 01, 01, 0, 0, 0)
                , new DateTime(2020, 01, 02, 0, 0, 0)),//20
                new (0.2m, 1
                , new DateTime(2022, 01, 01, 0, 0, 0)
                , new DateTime(2022, 01, 02, 0, 0, 0)),//20
                new (0.2m, 1
                , new DateTime(2022, 01, 01, 0, 0, 0)
                , new DateTime(2022, 01, 01, 0, 10, 0)),//2
                new (0.2m, 1, DateTime.Now.AddMinutes(-10))//2.2
            };

            return rentalHistory;
        }
    }
}