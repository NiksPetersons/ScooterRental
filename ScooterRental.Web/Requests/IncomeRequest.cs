namespace ScooterRental.Web.Requests
{
    public class IncomeRequest
    {
        public bool IncludeNotCompletedRentals { get; set; }
        public int? Year { get; set; }
    }
}