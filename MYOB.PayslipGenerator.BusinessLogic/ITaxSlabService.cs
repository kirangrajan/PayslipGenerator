using MYOB.PayslipGenerator.DomainModel;
using System.Collections.Generic;

namespace MYOB.PayslipGenerator.BusinessLogic
{
    /// <summary>
    /// Tax slab interface
    /// </summary>
    public interface ITaxSlabService
    {
        /// <summary>
        /// Get Tax slabs for year
        /// </summary>
        /// <param name="year">tax year</param>
        /// <returns>tax slab </returns>
        IList<TaxSlab> GetTaxSlabs(int year);

        /// <summary>
        /// Get tax slab for a given tax year for a given taxable income
        /// </summary>
        /// <param name="taxableIncome">taxable income</param>
        /// <param name="year">tax year</param>
        /// <returns>tax slab details</returns>
        TaxSlab GetTaxSlab(decimal taxableIncome, int year);
    }
}
