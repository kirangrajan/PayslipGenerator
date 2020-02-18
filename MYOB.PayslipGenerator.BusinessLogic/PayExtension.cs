using MYOB.PayslipGenerator.DomainModel;
using MYOB.PayslipGenerator.Utilities;
using System;

namespace MYOB.PayslipGenerator.BusinessLogic
{
    /// <summary>
    /// Extension method specific to Tax pay
    /// </summary>
    public static class PayExtension
    {
        /// <summary>
        /// calculate gross pay from annual pay
        /// </summary>
        /// <param name="taxCalculator">tax calculator instance</param>
        /// <param name="annualPay">annual pay</param>
        /// <returns>Gross pay</returns>
        public static decimal GrossPay(this TaxCalculatorService taxCalculator, decimal annualPay)
        {
            return annualPay / 12;
        }

        /// <summary>
        /// Calculates Net pay
        /// </summary>
        /// <param name="taxCalculator">tax calculator instance</param>
        /// <param name="grossPay">Gross pay</param>
        /// <param name="tax">income tax</param>
        /// <returns>Net pay</returns>
        public static decimal NetPay(this TaxCalculatorService taxCalculator, decimal grossPay, decimal tax)
        {
            return grossPay - tax;
        }

        /// <summary>
        /// Calculates Super pay amount
        /// </summary>
        /// <param name="taxCalculator">tax calculator instance</param>
        /// <param name="grossPay">Gross pay</param>
        /// <param name="superRate">super rate</param>
        /// <returns>Return super amount</returns>
        public static decimal SuperPay(this TaxCalculatorService taxCalculator, decimal grossPay, decimal superRate)
        {
            return grossPay * (superRate / 100);
        }

        /// <summary>
        /// Creates a PayPeriod string
        /// </summary>
        /// <param name="taxCalculator">tax calculator instance</param>
        /// <param name="payDate">pay date</param>
        /// <returns>PayPeriod string</returns>
        public static string PayDateString(this TaxCalculatorService taxCalculator, DateTime payDate)
        {
            return string.Format("{0} {1} - {2} {3}", payDate.Day.GetPaddedString(2), payDate.Month.GetMonthName(), DateTime.DaysInMonth(payDate.Year, payDate.Month).GetPaddedString(2), payDate.Month.GetMonthName());
        }

        /// <summary>
        /// Creates a decimal from a rate value
        /// </summary>
        /// <param name="value">value to be converted</param>
        /// <returns>decimal value from a string</returns>
        public static decimal ToDecimalRate(this string value)
        {
            var input = value.Replace("%", string.Empty).Replace("percent", string.Empty).Replace("percentage", string.Empty);
            var result = 0.0M;
            decimal.TryParse(input, out result);
            return result;
        }

        /// <summary>
        /// Gets employees name
        /// </summary>
        /// <param name="employee">employee object</param>
        /// <returns>employee name</returns>
        public static string GetEmployeeName(this Employee employee)
        {
            return string.Format("{0} {1}", employee.FirstName, employee.LastName);
        }

        public static int NumberOfDaysToBePaidInMonth(this Employee employee)
        {
            return (DateTime.DaysInMonth(employee.PaymentStartDate.Year, employee.PaymentStartDate.Month) - employee.PaymentStartDate.Day) + 1;
        }
    }
}
