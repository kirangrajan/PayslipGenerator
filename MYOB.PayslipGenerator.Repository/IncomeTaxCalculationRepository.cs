using MYOB.PayslipGenerator.Utilities;

namespace MYOB.PayslipGenerator.Repository
{
    /// <summary>
    /// Income Tax Calculation Repository
    /// </summary>
    public class IncomeTaxCalculationRepository : IIncomeTaxCalculationRepository
    {
        private readonly ITaxSlabRepository _taxSlabRepository;
        
        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="taxSlabRepository">Tax SlabRepository instance</param>
        public IncomeTaxCalculationRepository(ITaxSlabRepository taxSlabRepository)
        {
            this._taxSlabRepository = taxSlabRepository;
        }

        /// <summary>
        /// Calculate Income Tax
        /// </summary>
        /// <param name="annualSalary">annual salary</param>
        /// <param name="taxYear">tax year</param>
        /// <returns>Income tax details</returns>
        public decimal CalculateIncomeTax(decimal annualSalary, int taxYear)
        {
            var taxSlab = this._taxSlabRepository.GetTaxSlab(annualSalary, taxYear);

            return (taxSlab.BaseTaxAmount + ((annualSalary - (taxSlab.GetPreviousTaxSlabMax())) * (taxSlab.TaxOnEachDollar.ToDecimal().ToPercentage()))) / Constants.MonthsInYear;
        }
    }
}
