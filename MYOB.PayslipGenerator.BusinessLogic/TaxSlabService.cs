using MYOB.PayslipGenerator.DomainModel;
using MYOB.PayslipGenerator.Repository;
using System.Collections.Generic;
namespace MYOB.PayslipGenerator.BusinessLogic
{
    /// <summary>
    /// Tax slab service
    /// </summary>
    public class TaxSlabService : ITaxSlabService
    {
        private readonly ITaxSlabRepository _taxSlabRepository;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="taxSlabRepository"></param>
        public TaxSlabService(ITaxSlabRepository taxSlabRepository)
        {
            this._taxSlabRepository = taxSlabRepository;
        }

        /// <summary>
        /// Get Tax slabs for year
        /// </summary>
        /// <param name="year">tax year</param>
        /// <returns>tax slab </returns>
        public IList<TaxSlab> GetTaxSlabs(int year)
        {
            return this._taxSlabRepository.GetTaxSlabs(year);
        }

        /// <summary>
        /// Get tax slab for a given tax year for a given taxable income
        /// </summary>
        /// <param name="taxableIncome">taxable income</param>
        /// <param name="year">tax year</param>
        /// <returns>tax slab details</returns>
        public TaxSlab GetTaxSlab(decimal taxableIncome, int year)
        {
            return this._taxSlabRepository.GetTaxSlab(taxableIncome, year);
        }
    }
}
