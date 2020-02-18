using MYOB.PayslipGenerator.DomainModel;
using MYOB.PayslipGenerator.Repository;
using MYOB.PayslipGenerator.Utilities;

namespace MYOB.PayslipGenerator.BusinessLogic
{
    /// <summary>
    /// Tax Calculator Service
    /// </summary>
    public class TaxCalculatorService : ITaxCalculatorService
    {
        private readonly IIncomeTaxCalculationRepository _incomeTaxCalculationRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="incomeTaxCalculationRepository">Income Tax Calculation Repository instance</param>
        public TaxCalculatorService(IIncomeTaxCalculationRepository incomeTaxCalculationRepository)
        {
            this._incomeTaxCalculationRepository = incomeTaxCalculationRepository;
        }

        /// <summary>
        /// Calculates tax
        /// </summary>
        /// <param name="employee">employee instance</param>
        /// <param name="taxYear">Tax Year</param>
        /// <returns>employee tax details</returns>
        public EmployeeTax Calculate(Employee employee, int taxYear)
        {
            var grossPay = this.GrossPay(employee.AnnualSalary).Round();

            var incomeTax = this._incomeTaxCalculationRepository.CalculateIncomeTax(employee.AnnualSalary, taxYear).Round();

            var employeeTax = new EmployeeTax()
            {
                EmployeeName = employee.GetEmployeeName(),
                GrossIncome = (grossPay * (employee.NumberOfDaysToBePaidInMonth().ToDecimal() / employee.PaymentStartDate.DaysInMonth().ToDecimal())).Round(),
                IncomeTax = (incomeTax * (employee.NumberOfDaysToBePaidInMonth().ToDecimal() / employee.PaymentStartDate.DaysInMonth().ToDecimal())).Round(),
                NetIncome = this.NetPay((grossPay * (employee.NumberOfDaysToBePaidInMonth().ToDecimal() / employee.PaymentStartDate.DaysInMonth().ToDecimal())).Round(), (incomeTax * (employee.NumberOfDaysToBePaidInMonth().ToDecimal() / employee.PaymentStartDate.DaysInMonth().ToDecimal())).Round()).Round(),
                SuperAmount = this.SuperPay((grossPay * (employee.NumberOfDaysToBePaidInMonth().ToDecimal() / employee.PaymentStartDate.DaysInMonth().ToDecimal())).Round(), employee.SuperRate.ToDecimalRate()).Round(),
                PayPeriod = this.PayDateString(employee.PaymentStartDate)
            };

            return employeeTax;
        }
    }
}
