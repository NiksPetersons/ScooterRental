using FluentAssertions;
using ScooterRental.Core.Core_Models;
using ScooterRental.Core.ScooterValidations;
using Xunit;

namespace ScooterRental.UnitTests
{
    public class ScooterValidatorTests
    {
        private readonly IScooterValidator _priceValidator;
        private readonly IScooterValidator _isRentedValidator;

        public ScooterValidatorTests()
        {
            _priceValidator = new ScooterPriceValidator();
            _isRentedValidator = new ScooterIsRentedValidator();
        }

        [Fact]
        public void ScooterValidation_ShouldReturnFalseIfGivenZeroOrNegativePricePerMinute()
        {
            var scooter = new Scooter(0);
            var scooter2 = new Scooter(-2);

            _priceValidator.IsValid(scooter).Should().BeFalse();
            _priceValidator.IsValid(scooter2).Should().BeFalse();
        }

        [Fact]
        public void ScooterValidation_ShouldReturnTrueIfGivenPositivePricePerMinute()
        {
            var scooter = new Scooter(0.2m);

            _priceValidator.IsValid(scooter).Should().BeTrue();
        }

        [Fact]
        public void ScooterValidation_ShouldReturnFalseIfIsRentedIsTrue()
        {
            var scooter = new Scooter(0.2m);
            scooter.IsRented = true;

            _isRentedValidator.IsValid(scooter).Should().BeFalse();
        }

        [Fact]
        public void ScooterValidation_ShouldReturnTrueIfIsRentedIsFalse()
        {
            var scooter = new Scooter(0.2m);

            _isRentedValidator.IsValid(scooter).Should().BeTrue();
        }
    }
}