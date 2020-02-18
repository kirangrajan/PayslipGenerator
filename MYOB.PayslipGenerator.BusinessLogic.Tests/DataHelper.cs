using MYOB.PayslipGenerator.DomainModel;
namespace MYOB.PayslipGenerator.BusinessLogic.Tests
{
    /// <summary>
    /// Data Helper 
    /// </summary>
    public class DataHelper
    {
        internal static Employee GetEmployeeA()
        {
            return new Employee
            {
                Id = 1,
                LastName = "Rudd",
                FirstName = "David",
                AnnualSalary = 60050.00M,
                PaymentStartDate = new System.DateTime(2013, 3, 1),
                SuperRate = "9%"
            };
        }

        internal static Employee GetEmployeeB()
        {
            return new Employee
            {
                Id = 2,
                LastName = "Chen",
                FirstName = "Ryan",
                AnnualSalary = 120000.00M,
                PaymentStartDate = new System.DateTime(2013, 3, 1),
                SuperRate = "10%"
            };
        }

        internal static Employee GetEmployeeC()
        {
            return new Employee
            {
                Id = 3,
                LastName = "Issac",
                FirstName = "Thomas",
                AnnualSalary = 157500.00M,
                PaymentStartDate = new System.DateTime(2012, 3, 1),
                SuperRate = "11%"
            };
        }
        internal static EmployeeTax GetTaxForEmployeeA()
        {
            return new EmployeeTax
            {
                Id = 1,
                EmployeeName = "David Rudd",
                GrossIncome = 5004,
                IncomeTax = 922,
                NetIncome = 4082,
                SuperAmount = 450,
                PayPeriod = "01 March - 31 March"
            };
        }

        internal static EmployeeTax GetTaxForEmployeeB()
        {
            return new EmployeeTax
            {
                Id = 2,
                EmployeeName = "Ryan Chen",
                GrossIncome = 10000,
                IncomeTax = 2696,
                NetIncome = 7304,
                SuperAmount = 1000,
                PayPeriod = "01 March - 31 March"
            };
        }
    }
}
