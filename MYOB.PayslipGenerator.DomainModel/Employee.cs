using System;
namespace MYOB.PayslipGenerator.DomainModel
{
    /// <summary>
    /// Employee Domain model
    /// </summary>
    public class Employee : BaseEntity
    {
        /// <summary>
        /// First name of the the employee
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of the the employee
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Super rate 
        /// </summary>
        public string SuperRate { get; set; }

        /// <summary>
        /// Total annual salary
        /// </summary>
        public decimal AnnualSalary { get; set; }

        /// <summary>
        /// Start date of payment
        /// </summary>
        public DateTime PaymentStartDate { get; set; }
    }
}
