using Microsoft.AspNetCore.Mvc;
using ScooterRental.Core.Interfaces;
using ScooterRental.Web.Requests;

namespace ScooterRental.Web.Controllers
{
    [Route("income")]
    [ApiController]
    public class IncomeController : ControllerBase
    {
        private readonly IIncomeReportService _incomeService;

        public IncomeController(IIncomeReportService incomeService)
        {
            _incomeService = incomeService;
        }

        [HttpPost]
        public IActionResult IncomeReport(IncomeRequest request)
        {
            var income = _incomeService.IncomeReport(request.Year, request.IncludeNotCompletedRentals);
            return Ok(income);
        }
    }
}
