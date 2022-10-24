using AutoMapper;
using FluentAssertions;
using ScooterRental.Core;
using ScooterRental.Web.AutoMapper;
using ScooterRental.Web.ViewModels;
using Xunit;

namespace ScooterRental.UnitTests
{
    public class ScooterMapperTests
    {
        private readonly IMapper _mapper;

        public ScooterMapperTests()
        {
            _mapper = AutoMapperConfig.CreateMapper();
        }

        [Fact]
        public void Mapper_ShouldConvertScooterToScooterView()
        {
            var scooter = new Scooter(0.2m);
            var scooterView = _mapper.Map<ScooterView>(scooter);

            scooterView.PricePerMinute.Should().Be(0.2m);
            scooterView.IsRented.Should().BeFalse();
        }
    }
}