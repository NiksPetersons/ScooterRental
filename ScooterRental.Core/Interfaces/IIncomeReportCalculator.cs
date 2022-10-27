using System.Collections.Generic;
using ScooterRental.Core.Core_Models;

namespace ScooterRental.Core.Interfaces
{
    public interface IIncomeReportCalculator
    {
        decimal CalculateIncome(List<Rental> fullRentalList, int? year, bool includeNotCompletedRentals);
    }
}