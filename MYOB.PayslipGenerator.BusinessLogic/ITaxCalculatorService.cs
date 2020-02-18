using MYOB.PayslipGenerator.DomainModel;

namespace MYOB.PayslipGenerator.BusinessLogic
{
    /// <summary>
    /// Tax Calculator Service contract
    /// </summary>
    public interface ITaxCalculatorService
    {
        /// <summary>
        /// Calculates tax
        /// </summary>
        /// <param name="employee">employee instance</param>
        /// <param name="taxYear">Tax Year</param>
        /// <returns>employee tax details</returns>
        EmployeeTax Calculate(Employee employee, int taxYear);
    }
}
