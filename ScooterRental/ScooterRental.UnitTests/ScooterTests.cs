using FluentAssertions;
using ScooterRental.Core;
using Xunit;

namespace ScooterRental.UnitTests
{
    public class ScooterTests
    {
        [Fact]
        public void ScooterCreation_DefaultRentStateShouldBeFalse()
        {
            var scooter = new Scooter(0.2m);
            scooter.PricePerMinute.Should().Be(0.2m);
            scooter.IsRented.Should().BeFalse();
        }
    }
}
