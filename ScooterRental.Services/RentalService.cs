using System;
using System.Collections.Generic;
using System.Linq;
using ScooterRental.Core;
using ScooterRental.Core.Interfaces;

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

        public Rental StartRentById(int id)
        {
            var scooter = _dbService.GetById<Scooter>(id);
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