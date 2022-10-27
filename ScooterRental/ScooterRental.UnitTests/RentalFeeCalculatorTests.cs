using FluentAssertions;
using ScooterRental.Core.CalculatorModels;
using ScooterRental.Core.Core_Models;
using ScooterRental.Core.Interfaces;
using System;
using System.Globalization;
using Xunit;

namespace ScooterRental.UnitTests
{
    public class RentalFeeCalculatorTests
    {
        private readonly IRentalFeeCalculator _calculator;
        private readonly Rental _rental;

        public RentalFeeCalculatorTests()
        {
            _calculator = new RentalFeeCalculator();
            _rental = new Rental(0.2m, 1, new DateTime(2022, 01, 01, 0, 0, 0));
        }

        [Theory]
        [InlineData("01/01/2022 00:05", 1)]
        [InlineData("02/01/2022 01:06", 33.2)]
        [InlineData("11/01/2022 01:00", 212)]
        [InlineData("21/01/2022 01:12", 414.4)]
        public void RentalFeeCalculator_ShouldReturnCorrectDecimal(string date, decimal expected)
        {
            //Arrange
            _rental.RentEnd = DateTime.ParseExact(date, "dd/MM/yyyy hh:mm", CultureInfo.InvariantCulture);
            //Act & Assert
            _calculator.CalculateRentalFee(_rental).Should().Be(expected);
        }
    }
}