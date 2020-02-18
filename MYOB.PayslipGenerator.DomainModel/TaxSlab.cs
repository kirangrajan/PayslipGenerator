namespace MYOB.PayslipGenerator.DomainModel
{
    /// <summary>
    /// Tax slab domain model
    /// </summary>
    public class TaxSlab : BaseEntity
    {
        public int Year { get; set; }
        public decimal BaseTaxAmount { get; set; }

        public decimal MinimumIncome { get; set; }

        public decimal MaximumIncome { get; set; }

        public float TaxOnEachDollar { get; set; }
    }
}
