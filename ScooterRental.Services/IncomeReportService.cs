using ScooterRental.Core.Core_Models;
using ScooterRental.Core.Interfaces;

namespace ScooterRental.Services
{
    public class IncomeReportService : IIncomeReportService
    {
        private readonly IIncomeReportCalculator _incomeCalculator;
        private readonly IDbService _dbService;

        public IncomeReportService(IIncomeReportCalculator incomeCalculator, IDbService dbService)
        {
            _incomeCalculator = incomeCalculator;
            _dbService = dbService;
        }

        public decimal IncomeReport(int? year, bool includeNotCompletedRentals)
        {
            var fullRentalList = _dbService.GetAll<Rental>();
            return _incomeCalculator.CalculateIncome(fullRentalList, year, includeNotCompletedRentals);
        }
    }
}