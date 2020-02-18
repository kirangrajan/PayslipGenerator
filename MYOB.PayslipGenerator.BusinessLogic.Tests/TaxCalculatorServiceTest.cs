using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MYOB.PayslipGenerator.Repository;
using MYOB.PayslipGenerator.Utilities;

namespace MYOB.PayslipGenerator.BusinessLogic.Tests
{
    [TestClass]
    public class TaxCalculatorServiceTest
    {
        public Mock<IIncomeTaxCalculationRepository> _incomeTaxCalculationRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            this._incomeTaxCalculationRepository = new Mock<IIncomeTaxCalculationRepository>();
        }

        [TestMethod]
        public void Test_Check_If_Gross_Pay_Is_Calculated_Properly_From_Annual_Pay()
        {
            /// Arrange
            var expectedEmployeeTax = DataHelper.GetTaxForEmployeeA();
            var expectedEmployee = DataHelper.GetEmployeeA();
            this._incomeTaxCalculationRepository.Setup(p => p.CalculateIncomeTax(expectedEmployee.AnnualSalary, Constants.TaxYear)).Returns(expectedEmployeeTax.IncomeTax);

            /// Act
            var taxCalculatorService = new TaxCalculatorService(this._incomeTaxCalculationRepository.Object);
            var actual = taxCalculatorService.Calculate(expectedEmployee, Constants.TaxYear);

            /// Assert
            Assert.AreEqual(expectedEmployeeTax.GrossIncome, actual.GrossIncome);

        }

        [TestMethod]
        public void Test_Check_If_Income_Tax_Is_Calculated_Properly_From_Annual_Pay()
        {
            /// Arrange
            var expectedEmployeeTax = DataHelper.GetTaxForEmployeeA();
            var expectedEmployee = DataHelper.GetEmployeeA();
            this._incomeTaxCalculationRepository.Setup(p => p.CalculateIncomeTax(expectedEmployee.AnnualSalary, Constants.TaxYear)).Returns(expectedEmployeeTax.IncomeTax);

            /// Act
            var taxCalculatorService = new TaxCalculatorService(this._incomeTaxCalculationRepository.Object);
            var actual = taxCalculatorService.Calculate(expectedEmployee, Constants.TaxYear);

            /// Assert
            Assert.AreEqual(expectedEmployeeTax.IncomeTax, actual.IncomeTax);

        }

        [TestMethod]
        public void Test_Check_If_Net_Pay_Is_Calculated_Properly_From_Gross_Pay()
        {
            /// Arrange
            var expectedEmployeeTax = DataHelper.GetTaxForEmployeeB();
            var expectedEmployee = DataHelper.GetEmployeeB();
            this._incomeTaxCalculationRepository.Setup(p => p.CalculateIncomeTax(expectedEmployee.AnnualSalary, Constants.TaxYear)).Returns(expectedEmployeeTax.IncomeTax);

            /// Act
            var taxCalculatorService = new TaxCalculatorService(this._incomeTaxCalculationRepository.Object);
            var actual = taxCalculatorService.Calculate(expectedEmployee, Constants.TaxYear);

            /// Assert
            Assert.AreEqual(expectedEmployeeTax.NetIncome, actual.NetIncome);

        }

        [TestMethod]
        public void Test_Check_If_Super_Pay_Is_Calculated_Properly_From_Gross_Pay()
        {
            /// Arrange
            var expectedEmployeeTax = DataHelper.GetTaxForEmployeeB();
            var expectedEmployee = DataHelper.GetEmployeeB();
            this._incomeTaxCalculationRepository.Setup(p => p.CalculateIncomeTax(expectedEmployee.AnnualSalary, Constants.TaxYear)).Returns(expectedEmployeeTax.IncomeTax);

            /// Act
            var taxCalculatorService = new TaxCalculatorService(this._incomeTaxCalculationRepository.Object);
            var actual = taxCalculatorService.Calculate(expectedEmployee, Constants.TaxYear);

            /// Assert
            Assert.AreEqual(expectedEmployeeTax.SuperAmount, actual.SuperAmount);

        }

        [TestMethod]
        public void Test_Check_If_Employee_Name_Is_Formed_Properly()
        {
            /// Arrange
            var expectedEmployeeTax = DataHelper.GetTaxForEmployeeB();
            var expectedEmployee = DataHelper.GetEmployeeB();
            expectedEmployee.FirstName = "Valid";
            expectedEmployee.LastName = "User";
            this._incomeTaxCalculationRepository.Setup(p => p.CalculateIncomeTax(expectedEmployee.AnnualSalary, Constants.TaxYear)).Returns(expectedEmployeeTax.IncomeTax);

            /// Act
            var taxCalculatorService = new TaxCalculatorService(this._incomeTaxCalculationRepository.Object);
            var actual = taxCalculatorService.Calculate(expectedEmployee, Constants.TaxYear);

            /// Assert
            Assert.AreEqual(string.Format("{0} {1}", "Valid", "User"), actual.EmployeeName);
        }

        [TestMethod]
        public void Test_Check_If_Pay_Period_String_Is_Formed_Properly()
        {
            /// Arrange
            var expectedEmployeeTax = DataHelper.GetTaxForEmployeeB();
            var expectedEmployee = DataHelper.GetEmployeeB();
            expectedEmployee.PaymentStartDate = new System.DateTime(2012, 12, 15);
            this._incomeTaxCalculationRepository.Setup(p => p.CalculateIncomeTax(expectedEmployee.AnnualSalary, Constants.TaxYear)).Returns(expectedEmployeeTax.IncomeTax);

            /// Act
            var taxCalculatorService = new TaxCalculatorService(this._incomeTaxCalculationRepository.Object);
            var actual = taxCalculatorService.Calculate(expectedEmployee, Constants.TaxYear);

            /// Assert
            Assert.AreEqual("15 December - 31 December", actual.PayPeriod);
        }
    }
}
