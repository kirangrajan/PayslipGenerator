using MYOB.PayslipGenerator.DomainModel;
namespace MYOB.PayslipGenerator.Repository
{
    /// <summary>
    /// Extensions method specific to tax calculations
    /// </summary>
    public static class IncomeExtension
    {
        /// <summary>
        /// Get the ceiling value of the previous slab, if any
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static decimal GetPreviousTaxSlabMax(this TaxSlab value)
        {
            return value.MinimumIncome > 0 ? value.MinimumIncome - 1 : 0;
        }
    }
}
