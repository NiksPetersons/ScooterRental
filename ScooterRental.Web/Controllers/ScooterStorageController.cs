using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ScooterRental.Core;
using ScooterRental.Core.Interfaces;
using ScooterRental.Core.ScooterValidations;
using ScooterRental.Web.ViewModels;

namespace ScooterRental.Web.Controllers
{
    [Route("scooter")]
    [ApiController]
    public class ScooterStorageController : ControllerBase
    {
        private readonly IDbService _dbService;
        private readonly IMapper _mapper;
        private readonly IEnumerable<IScooterValidator> _validators;

        public ScooterStorageController(IDbService dbService, IMapper mapper, IEnumerable<IScooterValidator> validators)
        {
            _dbService = dbService;
            _mapper = mapper;
            _validators = validators;
        }

        [HttpPut]
        [Route("add")]
        public IActionResult AddScooter(ScooterView scooterView)
        {
            var scooter = _mapper.Map<Scooter>(scooterView);

            if (!_validators.All(x => x.IsValid(scooter)))
            {
                return BadRequest();
            }

            _dbService.Create(scooter);
            var view = _mapper.Map<ScooterView>(scooter);
            return Created("", view);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult DeleteScooter(int id)
        {
            var scooter = _dbService.GetById<Scooter>(id);
            _dbService.Delete(scooter);
            return Ok();
        }

        [HttpPut]
        [Route("update/{id}")]
        public IActionResult UpdateScooterById(int id, ScooterView updateScooterView)
        {
            var dbScooter = _dbService.GetById<Scooter>(id);
            var updateScooter = _mapper.Map<Scooter>(updateScooterView);
            dbScooter.IsRented = updateScooter.IsRented;
            dbScooter.PricePerMinute = updateScooter.PricePerMinute;
            _dbService.Update(dbScooter);
            return Ok(updateScooterView);
        }
    }
}
