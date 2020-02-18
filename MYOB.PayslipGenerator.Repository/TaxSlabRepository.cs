using MYOB.PayslipGenerator.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MYOB.PayslipGenerator.Repository
{
    /// <summary>
    /// Tax slab repository
    /// </summary>
    public class TaxSlabRepository : ITaxSlabRepository
    {
        static IList<TaxSlab> taxSlabs = new List<TaxSlab>
        {
            new TaxSlab
            {
                 Year =2013,
                BaseTaxAmount =0M,
                Id=1,
                MinimumIncome=0M,
                MaximumIncome=18200.00M,
                TaxOnEachDollar =0F,
                Createdby= "Kiran",
                CreatedOn=DateTime.Now
        
            },
                new TaxSlab
                {
                     Year =2013,
                BaseTaxAmount =0M,
                Id=2,
                MinimumIncome=18201.00M,
                MaximumIncome=37000.00M,
                TaxOnEachDollar =19.0F,
                Createdby= "Kiran",
                CreatedOn=DateTime.Now
        
            },
            new TaxSlab
            {
                 Year =2013,
                BaseTaxAmount =3572.00M,
                Id=3,
                MinimumIncome=37001M,
                MaximumIncome=80000M,
                TaxOnEachDollar =32.5F,
                Createdby= "Kiran",
                CreatedOn=DateTime.Now
        
            },
            new TaxSlab
            {
                 Year =2013,
                BaseTaxAmount =17547.00M,
                Id=4,
                MinimumIncome=80001M,
                MaximumIncome=180000M,
                TaxOnEachDollar =37F,
                Createdby= "Kiran",
                CreatedOn=DateTime.Now
        
            },
            new TaxSlab
            {
                Year =2013,
                BaseTaxAmount =54547.00M,
                Id=5,
                MinimumIncome=180001.00M,
                MaximumIncome=decimal.MaxValue,
                TaxOnEachDollar =45F,
                Createdby= "Kiran",
                CreatedOn=DateTime.Now
        
            }
        };

        /// <summary>
        /// Get Tax slabs for year
        /// </summary>
        /// <param name="year">tax year</param>
        /// <returns>tax slabs </returns>
        public IList<TaxSlab> GetTaxSlabs(int year)
        {
            return taxSlabs.ToList().FindAll(p => p.Year == year);
        }

        /// <summary>
        /// Get tax slab for a given tax year for a given taxable income
        /// </summary>
        /// <param name="taxableIncome">taxable income</param>
        /// <param name="year">tax year</param>
        /// <returns>tax slab details</returns>
        public TaxSlab GetTaxSlab(decimal taxableIncome, int year)
        {
            return taxSlabs.ToList().FindAll(p => p.Year == year).Find(p => (p.MinimumIncome <= taxableIncome && p.MaximumIncome >= taxableIncome));
        }
    }
}
