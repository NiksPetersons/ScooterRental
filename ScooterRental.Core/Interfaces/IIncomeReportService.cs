namespace ScooterRental.Core.Interfaces
{
    public interface IIncomeReportService
    {
        decimal IncomeReport(int? year, bool includeNotCompletedRentals);
    }
}