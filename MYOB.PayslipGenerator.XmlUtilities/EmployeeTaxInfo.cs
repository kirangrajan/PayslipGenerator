namespace MYOB.PayslipGenerator.XmlUtilities
{
    public class EmployeeTaxInfo
    {
        /// <summary>
        /// Name of the the employee
        /// </summary>
        public string EmployeeName { get; set; }

        public string PayPeriod { get; set; }

        public decimal GrossIncome { get; set; }

        public decimal IncomeTax { get; set; }

        public decimal NetIncome { get; set; }

        public decimal SuperAmount { get; set; }
    }
}
