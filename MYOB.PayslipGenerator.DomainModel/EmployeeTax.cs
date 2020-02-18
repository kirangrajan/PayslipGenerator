namespace MYOB.PayslipGenerator.DomainModel
{
    /// <summary>
    /// Employee Tax domain model
    /// </summary>
    public class EmployeeTax : BaseEntity
    {
        public string EmployeeName { get; set; }

        public string PayPeriod { get; set; }

        public decimal GrossIncome { get; set; }

        public decimal IncomeTax { get; set; }

        public decimal NetIncome { get; set; }

        public decimal SuperAmount { get; set; }
    }
}
