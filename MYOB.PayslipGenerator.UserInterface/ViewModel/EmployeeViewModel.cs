using MYOB.PayslipGenerator.BusinessLogic;
using MYOB.PayslipGenerator.DomainModel;
using MYOB.PayslipGenerator.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace MYOB.PayslipGenerator.UserInterface.ViewModel
{
    /// <summary>
    /// Employee view model
    /// </summary>
    public class EmployeeViewModel : IEmployeeViewModel
    {
        private const string InvalidInput = "Input data has invalid entries";
        private readonly IEmployeeService _employeeService;
        private readonly ITaxCalculatorService _taxCalculatorService;

        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="employeeService">instance of employee service</param>
        /// <param name="taxCalculatorService">instance of tax calculator service</param>
        public EmployeeViewModel(IEmployeeService employeeService, ITaxCalculatorService taxCalculatorService)
        {
            this._employeeService = employeeService;
            this._taxCalculatorService = taxCalculatorService;
        }

        /// <summary>
        /// Error message if any
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Check if all data is valid
        /// </summary>
        public bool IsAllDataValid { get; set; }

        /// <summary>
        /// Read Employee details from a File
        /// </summary>
        /// <param name="fileName">file name</param>
        /// <returns>list of employees read</returns>
        public IList<Employee> ReadEmployeesFromFile(string fileName)
        {
            var employeeList = this._employeeService.GetEmployeesFromFile(fileName);

            var validListOfEmployees = employeeList.ToList().FindAll(p => p.PaymentStartDate != null &&
                     ((p.PaymentStartDate.Year == Constants.TaxYear && p.PaymentStartDate.Month <= Constants.LastTaxMonthMarch) ||
                         (p.PaymentStartDate.Year == Constants.TaxYear - 1 && p.PaymentStartDate.Month >= Constants.FirstTaxMonthJuly)));
            IsAllDataValid = employeeList.Count == validListOfEmployees.Count;
            ErrorMessage = employeeList.Count != validListOfEmployees.Count ? InvalidInput : string.Empty;

            return validListOfEmployees;
        }

        /// <summary>
        /// Perform Tax calculation for Employees
        /// </summary>
        /// <param name="employees">Employees for whom the tax calculation is to be done</param>
        /// <param name="taxYear">Tax year </param>
        /// <returns>Tax details for employees</returns>
        public IList<EmployeeTax> CalculateTaxForEmployees(IList<Employee> employees, int taxYear)
        {
            var validListOfEmployees = employees.ToList().FindAll(p => p.PaymentStartDate != null &&
                    ((p.PaymentStartDate.Year == Constants.TaxYear && p.PaymentStartDate.Month <= Constants.LastTaxMonthMarch) ||
                        (p.PaymentStartDate.Year == Constants.TaxYear - 1 && p.PaymentStartDate.Month >= Constants.FirstTaxMonthJuly)));
            IsAllDataValid = employees.Count == validListOfEmployees.Count;
            ErrorMessage = employees.Count != validListOfEmployees.Count ? InvalidInput : string.Empty;

            if (IsAllDataValid)
            {
                IsAllDataValid = taxYear == Constants.TaxYear || taxYear == Constants.TaxYear - 1;
            }

            var employeeTaxList = new List<EmployeeTax>();
            foreach (var employee in validListOfEmployees)
            {
                employeeTaxList.Add(this._taxCalculatorService.Calculate(employee, taxYear));
            }

            return employeeTaxList;
        }

        /// <summary>
        /// Create Payslip for Employees
        /// </summary>
        /// <param name="employees">Employees for whom the pay slip is to be generated and Tax is calculated</param>
        /// <param name="filename">File name of the </param>
        /// <returns>true/ false</returns>
        public bool GeneratePaySlipForEmployees(IList<EmployeeTax> employees, string filename)
        {
            return this._employeeService.GeneratePaySlipForSelectedEmployees(employees, filename);
        }
    }
}
