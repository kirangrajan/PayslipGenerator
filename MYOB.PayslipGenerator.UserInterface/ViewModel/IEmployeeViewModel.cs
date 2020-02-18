using MYOB.PayslipGenerator.DomainModel;
using System.Collections.Generic;

namespace MYOB.PayslipGenerator.UserInterface.ViewModel
{
    /// <summary>
    /// Employee view model contract
    /// </summary>
    public interface IEmployeeViewModel
    {
        /// <summary>
        /// Read Employee details from a File
        /// </summary>
        /// <param name="fileName">file name</param>
        /// <returns>list of employees read</returns>
        IList<Employee> ReadEmployeesFromFile(string fileName);

        /// <summary>
        /// Create Payslip for Employees
        /// </summary>
        /// <param name="employees">Employees for whom the pay slip is to be generated and Tax is calculated</param>
        /// <param name="filename">File name of the </param>
        /// <returns>true/ false</returns>
        bool GeneratePaySlipForEmployees(IList<EmployeeTax> employees, string filename);

        /// <summary>
        /// Perform Tax calculation for Employees
        /// </summary>
        /// <param name="employees">Employees for whom the tax calculation is to be done</param>
        /// <param name="taxYear">Tax year </param>
        /// <returns>Tax details for employees</returns>
        IList<EmployeeTax> CalculateTaxForEmployees(IList<Employee> employees, int taxYear);

        /// <summary>
        /// Error message if any
        /// </summary>
        string ErrorMessage { get; set; }

        /// <summary>
        /// Check if all data is valid
        /// </summary>
        bool IsAllDataValid { get; set; }
    }
}
