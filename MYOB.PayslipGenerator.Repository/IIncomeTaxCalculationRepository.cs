namespace MYOB.PayslipGenerator.Repository
{
    /// <summary>
    /// Income Tax Calculation Repository contract
    /// </summary>
    public interface IIncomeTaxCalculationRepository
    {
        // <summary>
        /// Calculate Income Tax
        /// </summary>
        /// <param name="annualSalary">annual salary</param>
        /// <param name="taxYear">tax year</param>
        /// <returns>Income tax details</returns>
        decimal CalculateIncomeTax(decimal annualSalary, int taxYear);
    }
}
