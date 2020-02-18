using MYOB.PayslipGenerator.DomainModel;
using System;
using System.Collections.Generic;
namespace MYOB.PayslipGenerator.Repository.Tests
{
    /// <summary>
    /// Data Helper
    /// </summary>
    internal static class DataHelper
    {
        internal static List<TaxSlab> GetTaxSlabsFor2012()
        {
            return new List<TaxSlab>
            {
                new TaxSlab
                {
                    Year =2012,
                    BaseTaxAmount =0M,
                    Id=11,
                    MinimumIncome=0M,
                    MaximumIncome=28200.00M,
                    TaxOnEachDollar =0F,
                    Createdby= "Kiran",
                    CreatedOn=DateTime.Now
        
                },
                new TaxSlab
                {
                    Year =2012,
                    BaseTaxAmount =0M,
                    Id=12,
                    MinimumIncome=28201.00M,
                    MaximumIncome=57000.00M,
                    TaxOnEachDollar =15.0F,
                    Createdby= "Kiran",
                    CreatedOn=DateTime.Now
                },
                new TaxSlab
                {
                    Year =2012,
                    BaseTaxAmount =54547.00M,
                    Id=13,
                    MinimumIncome=57001.00M,
                    MaximumIncome=decimal.MaxValue,
                    TaxOnEachDollar =45F,
                    Createdby= "Kiran",
                    CreatedOn=DateTime.Now
                }
            };
        }

        internal static List<TaxSlab> GetTaxSlabsFor2013()
        {
            return new List<TaxSlab>
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
        }

        internal static List<TaxSlab> GetTaxSlabs()
        {
            var taxSlabs = new List<TaxSlab>();
            taxSlabs.AddRange(GetTaxSlabsFor2012());
            taxSlabs.AddRange(GetTaxSlabsFor2013());

            return taxSlabs;
        }
    }
}
