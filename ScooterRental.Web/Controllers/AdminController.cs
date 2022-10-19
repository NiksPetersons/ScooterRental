using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScooterRental.Core;
using ScooterRental.Core.Interfaces;

namespace ScooterRental.Web.Controllers
{
    [Route("scooter")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IDbService _dbService;

        public AdminController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpPut]
        [Route("add")]
        public IActionResult AddScooter(Scooter scooter)
        {
            _dbService.Create(scooter);
            return Created("", scooter);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult DeleteScooter(int id)
        {
            var scooter = _dbService.GetById<Scooter>(id);
            _dbService.Delete(scooter);
            return Ok();
        }
    }
}
