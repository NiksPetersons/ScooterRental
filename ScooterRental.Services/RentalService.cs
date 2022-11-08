using ScooterRental.Core.Core_Models;
using ScooterRental.Core.Interfaces;
using System;
using System.Linq;

namespace ScooterRental.Services
{
    public class RentalService : IRentalService
    {
        private readonly IDbService _dbService;
        private readonly IRentalFeeCalculator _calculator;

        public RentalService(IDbService dbService, IRentalFeeCalculator calculator)
        {
            _dbService = dbService;
            _calculator = calculator;
        }

        public Rental StartRent(Scooter scooter)
        {
            scooter.IsRented = true;
            _dbService.Update(scooter);
            var rental = new Rental(scooter.PricePerMinute, scooter.Id);
            _dbService.Create(rental);
            return rental;
        }

        public void StopRent(Rental rental)
        {
            rental.RentEnd = DateTime.Now;
            _dbService.Update(rental);
            var scooter = _dbService.GetById<Scooter>(rental.ScooterId);
            scooter.IsRented = false;
            _dbService.Update(scooter);
        }

        public decimal CalculateRentFee(Rental rental)
        {
            return _calculator.CalculateRentalFee(rental);
        }

        public Rental GetUnfinishedRentalByScooterId(int id)
        {
            IQueryable<Rental> query = _dbService.Query<Rental>();
            var rentalByScooterId = query.FirstOrDefault(x=> x.ScooterId == id && x.RentEnd == null);
            return rentalByScooterId;
        }
    }
}