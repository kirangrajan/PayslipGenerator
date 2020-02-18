using MYOB.PayslipGenerator.DomainModel;
using MYOB.PayslipGenerator.Repository;
using MYOB.PayslipGenerator.XmlUtilities;
using System.Collections.Generic;
using MYOB.PayslipGenerator.Utilities;

namespace MYOB.PayslipGenerator.BusinessLogic
{
    /// <summary>
    /// Employee service class
    /// </summary>
    public class EmployeeService : IEmployeeService
    {
        private readonly ITaxSlabRepository _taxSlabRepository;

        public EmployeeService(ITaxSlabRepository taxSlabRepository)
        {
            this._taxSlabRepository = taxSlabRepository;
        }
        /// <summary>
        /// Get list of all employees
        /// </summary>
        /// <returns>list of employees</returns>
        public IList<Employee> GetEmployeesFromFile(string fileName)
        {
            var factory = new XmlReaderFactory<Employees>(fileName);
            var employeeReader = factory.GetReader(Utilities.XmlType.Employee);

            var employees = employeeReader.Read<Employees>();

            return this.Map(employees);
        }

        /// <summary>
        /// Generate payslip for Employees for whom tax calculation is complete
        /// </summary>
        /// <param name="employeeTaxInfo">tax details of employees</param>
        /// <param name="fileName">File name</param>
        /// <returns>succes/ failure</returns>
        public bool GeneratePaySlipForSelectedEmployees(IList<EmployeeTax> employeeTaxInfo, string fileName)
        {
            var factory = new XmlWriterFactory<List<EmployeeTaxInfo>>(fileName);
            var employeeWriter = factory.GetWriter(Utilities.XmlType.Employee);

            return employeeWriter.Write(this.Map(employeeTaxInfo));
        }

        private List<EmployeeTaxInfo> Map(IList<EmployeeTax> employeeTaxes)
        {
            var employeesTaxList = new List<EmployeeTaxInfo>();
            foreach (var tax in employeeTaxes)
            {
                employeesTaxList.Add(new EmployeeTaxInfo
                {
                    EmployeeName = tax.EmployeeName,
                    NetIncome = tax.NetIncome,
                    SuperAmount = tax.SuperAmount,
                    PayPeriod = tax.PayPeriod,
                    GrossIncome = tax.GrossIncome,
                    IncomeTax = tax.IncomeTax
                });
            }
            return employeesTaxList;
        }
        private IList<Employee> Map(IList<dynamic> employees)
        {
            IList<Employee> employeeList = new List<Employee>();
            foreach (var employee in employees)
            {
                if (employee is EmployeesEmployee)
                {
                    var readEmployee = (EmployeesEmployee)employee;
                    employeeList.Add(new Employee
                    {
                        FirstName = readEmployee.FirstName,
                        LastName = readEmployee.LastName,
                        SuperRate = readEmployee.SuperRate,
                        PaymentStartDate = readEmployee.PayStartDate.ToDate(),
                        AnnualSalary = readEmployee.AnnualSalary.ToDecimal()
                    });
                }
            }

            return employeeList;
        }
    }
}
