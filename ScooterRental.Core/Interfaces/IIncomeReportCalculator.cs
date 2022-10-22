using System.Collections.Generic;

namespace ScooterRental.Core.Interfaces
{
    public interface IIncomeReportCalculator
    {
        decimal CalculateIncome(List<Rental> fullRentalList, int? year, bool includeNotCompletedRentals);
    }
}