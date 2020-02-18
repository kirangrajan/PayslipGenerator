using MYOB.PayslipGenerator.DomainModel;
using System.Collections.Generic;
namespace MYOB.PayslipGenerator.BusinessLogic
{
    /// <summary>
    /// Employee service contract
    /// </summary>
    public interface IEmployeeService
    {
        /// <summary>
        /// Get list of all employees from a certain file
        /// </summary>
        /// <param name="fileName">file name</param>
        /// <returns>collection of employees</returns>
        IList<Employee> GetEmployeesFromFile(string fileName);

        /// <summary>
        /// Generate payslip for Employees for whom tax calculation is complete
        /// </summary>
        /// <param name="employeeTaxInfo">tax details of employees</param>
        /// <param name="fileName">File name</param>
        /// <returns>succes/ failure</returns>
        bool GeneratePaySlipForSelectedEmployees(IList<EmployeeTax> employeeTaxInfo, string fileName);
    }
}
