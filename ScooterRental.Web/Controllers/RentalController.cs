using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScooterRental.Core;
using ScooterRental.Core.Interfaces;

namespace ScooterRental.Web.Controllers
{
    [Route("rental")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        private readonly IRentalService _rentalService;

        public RentalController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpPut]
        [Route("start/{id}")]
        public IActionResult StartRentByScooterId(int id)
        {
            var rental = _rentalService.StartRentById(id);
            return Created("", rental);
        }

        [HttpPut]
        [Route("end/{id}")]
        public IActionResult EndRentByScooterId(int id)
        {
            var rental = _rentalService.GetUnfinishedRentalByScooterId(id);
            _rentalService.StopRent(rental);
            var fee = _rentalService.CalculateRentFee(rental);
            return Ok(fee);
        }
    }
}
