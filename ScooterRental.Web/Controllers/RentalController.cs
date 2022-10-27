using Microsoft.AspNetCore.Mvc;
using ScooterRental.Core.Core_Models;
using ScooterRental.Core.Interfaces;

namespace ScooterRental.Web.Controllers
{
    [Route("rental")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        private readonly IRentalService _rentalService;
        private readonly IDbService _dbService;

        public RentalController(IRentalService rentalService, IDbService dbService)
        {
            _rentalService = rentalService;
            _dbService = dbService;
        }

        [HttpPut]
        [Route("start/{id}")]
        public IActionResult StartRentByScooterId(int id)
        {
            var scooter = _dbService.GetById<Scooter>(id);

            if (scooter.IsRented == true)
            {
                return Conflict();
            }

            var rental = _rentalService.StartRent(scooter);
            return Created("", rental);
        }

        [HttpPut]
        [Route("end/{id}")]
        public IActionResult EndRentByScooterId(int id)
        {
            var rental = _rentalService.GetUnfinishedRentalByScooterId(id);

            if (rental == null)
            {
                return NotFound();
            }

            _rentalService.StopRent(rental);
            var fee = _rentalService.CalculateRentFee(rental);
            return Ok(fee);
        }
    }
}
