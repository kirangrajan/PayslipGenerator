using MYOB.PayslipGenerator.DomainModel;
using System.Collections.Generic;
namespace MYOB.PayslipGenerator.Repository
{
    /// <summary>
    /// Tax slab repository interface
    /// </summary>
    public interface ITaxSlabRepository
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
        /// <param name="taxableIncome"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        TaxSlab GetTaxSlab(decimal taxableIncome, int year);
    }
}
