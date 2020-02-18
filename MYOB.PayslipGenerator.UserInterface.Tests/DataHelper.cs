using MYOB.PayslipGenerator.DomainModel;
using System.Collections.Generic;
namespace MYOB.PayslipGenerator.UserInterface.Tests
{
    /// <summary>
    /// Data Helper 
    /// </summary>
    internal static class DataHelper
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
                Id = 1,
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
                Id = 1,
                LastName = "Issac",
                FirstName = "Thomas",
                AnnualSalary = 157500.00M,
                PaymentStartDate = new System.DateTime(2012, 3, 1),
                SuperRate = "11%"
            };
        }

        internal static Employee GetEmployeeD()
        {
            return new Employee
            {
                Id = 1,
                LastName = "Issac",
                FirstName = "Thomas",
                AnnualSalary = 157500.00M,
                PaymentStartDate = new System.DateTime(2013, 5, 1),
                SuperRate = "11%"
            };
        }


        internal static Employee GetEmployeeE()
        {
            return new Employee
            {
                Id = 9,
                LastName = "Superrate",
                FirstName = "Invalid",
                AnnualSalary = 157500.00M,
                PaymentStartDate = new System.DateTime(2013, 5, 1),
                SuperRate = "11P"
            };
        }

        internal static Employee GetEmployeeF()
        {
            return new Employee
            {
                Id = 10,
                LastName = "SuperrateA",
                FirstName = "Valid",
                AnnualSalary = 182500.00M,
                PaymentStartDate = new System.DateTime(2013, 2, 1),
                SuperRate = "11Percentage"
            };
        }

        internal static Employee GetEmployeeG()
        {
            return new Employee
            {
                Id = 11,
                LastName = "SuperrateB",
                FirstName = "Valid",
                AnnualSalary = 45678.00M,
                PaymentStartDate = new System.DateTime(2012, 8, 1),
                SuperRate = "11Percent"
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
