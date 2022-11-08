using FluentAssertions;
using ScooterRental.Core.Core_Models;
using System;
using Xunit;

namespace ScooterRental.UnitTests
{
    public class RentalTests
    {
        [Fact]
        public void RentalCreation_RentStartShouldBeDateTimeNowAndRentEndShouldBeNull()
        {
            var rental = new Rental(0.2m, 1);
            rental.RentStart.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(100));
            rental.RentEnd.Should().BeNull();
        }
    }
}