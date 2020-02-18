using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MYOB.PayslipGenerator.BusinessLogic;
using MYOB.PayslipGenerator.DomainModel;
using MYOB.PayslipGenerator.UserInterface.ViewModel;
using MYOB.PayslipGenerator.Utilities;
using System.Collections.Generic;

namespace MYOB.PayslipGenerator.UserInterface.Tests
{
    [TestClass]
    public class EmployeeViewModelTest
    {
        private const string InvalidInput = "Input data has invalid entries";
        public Mock<IEmployeeService> _employeeService;
        public Mock<ITaxCalculatorService> _taxCalculatorService;
        public Mock<IEmployeeViewModel> _employeeViewModel;

        [TestInitialize]
        public void TestInitialize()
        {
            this._employeeService = new Mock<IEmployeeService>();
            this._taxCalculatorService = new Mock<ITaxCalculatorService>();
            this._employeeService = new Mock<IEmployeeService>();
        }

        [TestMethod]
        public void Test_Check_All_Input_Data_Is_For_The_Right_Tax_Year()
        {
            /// Arrange
            var expectedEmployees = new List<Employee>
                                        {
                                            DataHelper.GetEmployeeA(), 
                                            DataHelper.GetEmployeeB()
                                        };

            this._employeeService.Setup(p => p.GetEmployeesFromFile(It.IsAny<string>())).Returns(expectedEmployees);

            /// Act
            var viewModel = new EmployeeViewModel(this._employeeService.Object, this._taxCalculatorService.Object);
            var actual = viewModel.ReadEmployeesFromFile(It.IsAny<string>());

            /// Assert
            Assert.AreEqual(viewModel.ErrorMessage, string.Empty);
            Assert.IsTrue(viewModel.IsAllDataValid);

            Assert.AreEqual(expectedEmployees[0].AnnualSalary, actual[0].AnnualSalary);
            Assert.AreEqual(expectedEmployees[0].PaymentStartDate, actual[0].PaymentStartDate);
            Assert.AreEqual(expectedEmployees[0].FirstName, actual[0].FirstName);
            Assert.AreEqual(expectedEmployees[0].LastName, actual[0].LastName);
            Assert.AreEqual(expectedEmployees[0].SuperRate, actual[0].SuperRate);

            this._employeeService.Verify(p => p.GetEmployeesFromFile(It.IsAny<string>()), Times.Once);
            this._employeeService.VerifyAll();
            this._taxCalculatorService.VerifyAll();

        }

        [TestMethod]
        public void Test_Check_If_Error_Message_IsReturned_If_Data_Is_Not_Valid()
        {
            /// Arrange
            var expectedEmployees = new List<Employee>
                                        {
                                            DataHelper.GetEmployeeA(), 
                                            DataHelper.GetEmployeeB(),
                                            DataHelper.GetEmployeeC()
                                        };

            this._employeeService.Setup(p => p.GetEmployeesFromFile(It.IsAny<string>())).Returns(expectedEmployees);

            /// Act
            var viewModel = new EmployeeViewModel(this._employeeService.Object, this._taxCalculatorService.Object);
            viewModel.ReadEmployeesFromFile(It.IsAny<string>());

            /// Assert
            Assert.AreNotEqual(viewModel.ErrorMessage, string.Empty);
            Assert.IsFalse(viewModel.IsAllDataValid);
            Assert.AreEqual(viewModel.ErrorMessage, InvalidInput);

            this._employeeService.Verify(p => p.GetEmployeesFromFile(It.IsAny<string>()), Times.Once);
            this._employeeService.VerifyAll();
            this._taxCalculatorService.VerifyAll();

        }

        [TestMethod]
        public void Test_Check_If_Error_Message_IsReturned_If_Year_For_Any_Employee_Record_Is_Not_2012_Or_2013()
        {
            /// Arrange
            var expectedEmployees = new List<Employee>
                                        {
                                            DataHelper.GetEmployeeC()
                                        };

            this._employeeService.Setup(p => p.GetEmployeesFromFile(It.IsAny<string>())).Returns(expectedEmployees);

            /// Act
            var viewModel = new EmployeeViewModel(this._employeeService.Object, this._taxCalculatorService.Object);
            viewModel.ReadEmployeesFromFile(It.IsAny<string>());

            /// Assert
            Assert.AreNotEqual(viewModel.ErrorMessage, string.Empty);
            Assert.IsFalse(viewModel.IsAllDataValid);
            Assert.AreEqual(viewModel.ErrorMessage, InvalidInput);

            this._employeeService.Verify(p => p.GetEmployeesFromFile(It.IsAny<string>()), Times.Once);
            this._employeeService.VerifyAll();
            this._taxCalculatorService.VerifyAll();

        }

        [TestMethod]
        public void Test_Check_If_Error_Message_IsReturned_If_Month_For_Any_Employee_Record_Is_Not_Between_July2012_And_March2013()
        {
            /// Arrange
            var expectedEmployees = new List<Employee>
                                        {
                                            DataHelper.GetEmployeeD()
                                        };

            this._employeeService.Setup(p => p.GetEmployeesFromFile(It.IsAny<string>())).Returns(expectedEmployees);

            /// Act
            var viewModel = new EmployeeViewModel(this._employeeService.Object, this._taxCalculatorService.Object);
            viewModel.ReadEmployeesFromFile(It.IsAny<string>());

            /// Assert
            Assert.AreNotEqual(viewModel.ErrorMessage, string.Empty);
            Assert.IsFalse(viewModel.IsAllDataValid);
            Assert.AreEqual(viewModel.ErrorMessage, InvalidInput);

            this._employeeService.Verify(p => p.GetEmployeesFromFile(It.IsAny<string>()), Times.Once);
            this._employeeService.VerifyAll();
            this._taxCalculatorService.VerifyAll();

        }

        [TestMethod]
        public void Test_Check_If_SuperRate_With_Prefix_Percentage_Or_Percent_Is_Valid()
        {
            /// Arrange
            var expectedEmployees = new List<Employee>
                                        {
                                            DataHelper.GetEmployeeF(), 
                                            DataHelper.GetEmployeeG()
                                        };

            this._employeeService.Setup(p => p.GetEmployeesFromFile(It.IsAny<string>())).Returns(expectedEmployees);

            /// Act
            var viewModel = new EmployeeViewModel(this._employeeService.Object, this._taxCalculatorService.Object);
            viewModel.ReadEmployeesFromFile(It.IsAny<string>());

            /// Assert
            Assert.AreEqual(viewModel.ErrorMessage, string.Empty);
            Assert.IsTrue(viewModel.IsAllDataValid);

            this._employeeService.Verify(p => p.GetEmployeesFromFile(It.IsAny<string>()), Times.Once);
            this._employeeService.VerifyAll();
            this._taxCalculatorService.VerifyAll();
        }

        [TestMethod]
        public void Test_Check_If_SuperRate_With_InvalidPrefix_With_Return_Exception()
        {
            /// Arrange
            var expectedEmployees = new List<Employee>
                                        {
                                            DataHelper.GetEmployeeE()
                                        };

            this._employeeService.Setup(p => p.GetEmployeesFromFile(It.IsAny<string>())).Returns(expectedEmployees);

            /// Act
            var viewModel = new EmployeeViewModel(this._employeeService.Object, this._taxCalculatorService.Object);
            viewModel.ReadEmployeesFromFile(It.IsAny<string>());

            /// Assert
            Assert.AreNotEqual(viewModel.ErrorMessage, string.Empty);
            Assert.IsFalse(viewModel.IsAllDataValid);
            Assert.AreEqual(viewModel.ErrorMessage, InvalidInput);

            this._employeeService.Verify(p => p.GetEmployeesFromFile(It.IsAny<string>()), Times.Once);
            this._employeeService.VerifyAll();
            this._taxCalculatorService.VerifyAll();
        }

        [TestMethod]
        public void Test_Get_Employees_Method_Will_Return_Only_Valid_Employee_List()
        {
            /// Arrange
            var expectedEmployees = new List<Employee>
                                        {
                                            DataHelper.GetEmployeeA(),
                                            DataHelper.GetEmployeeB(),
                                            DataHelper.GetEmployeeC(),
                                            DataHelper.GetEmployeeE()
                                        };

            this._employeeService.Setup(p => p.GetEmployeesFromFile(It.IsAny<string>())).Returns(expectedEmployees);

            /// Act
            var viewModel = new EmployeeViewModel(this._employeeService.Object, this._taxCalculatorService.Object);
            var actual = viewModel.ReadEmployeesFromFile(It.IsAny<string>());

            /// Assert
            Assert.AreNotEqual(viewModel.ErrorMessage, string.Empty);
            Assert.IsFalse(viewModel.IsAllDataValid);
            Assert.AreEqual(viewModel.ErrorMessage, InvalidInput);
            Assert.AreEqual(actual.Count, 2);

            this._employeeService.Verify(p => p.GetEmployeesFromFile(It.IsAny<string>()), Times.Once);
            this._employeeService.VerifyAll();
            this._taxCalculatorService.VerifyAll();
        }

        [TestMethod]
        public void Test_Calculate_Tax_Procedure_Checks_And_Returns_Error_Message_If_Data_Is_Not_Valid()
        {
            /// Arrange
            var expectedEmployees = new List<Employee>
                                        {
                                            DataHelper.GetEmployeeA(), 
                                            DataHelper.GetEmployeeB(),
                                            DataHelper.GetEmployeeC()
                                        };
            var expectedTaxForEmployees = new List<EmployeeTax>
                                        {
                                            DataHelper.GetTaxForEmployeeA(), 
                                            DataHelper.GetTaxForEmployeeA()
                                        };


            this._taxCalculatorService.Setup(p => p.Calculate(DataHelper.GetEmployeeA(), Constants.TaxYear)).Returns(DataHelper.GetTaxForEmployeeA());

            /// Act
            var viewModel = new EmployeeViewModel(this._employeeService.Object, this._taxCalculatorService.Object);
            viewModel.CalculateTaxForEmployees(expectedEmployees, Constants.TaxYear);

            /// Assert
            Assert.AreNotEqual(viewModel.ErrorMessage, string.Empty);
            Assert.IsFalse(viewModel.IsAllDataValid);
            Assert.AreEqual(viewModel.ErrorMessage, InvalidInput);

            this._taxCalculatorService.Verify(p => p.Calculate(It.IsAny<Employee>(), It.IsAny<int>()), Times.AtLeastOnce);
            this._employeeService.VerifyAll();
        }

        [TestMethod]
        public void Test_Calculate_Tax_Calculates_All_Tax_details_Successfully()
        {
            /// Arrange
            var expectedEmployees = new List<Employee>
                                        {
                                            DataHelper.GetEmployeeA()
                                        };
            var expectedTaxForEmployees = new List<EmployeeTax>
                                        {
                                            DataHelper.GetTaxForEmployeeA() 
                                        };


            this._taxCalculatorService.Setup(p => p.Calculate(It.IsAny<Employee>(), It.IsAny<int>())).Returns(DataHelper.GetTaxForEmployeeA());

            /// Act
            var viewModel = new EmployeeViewModel(this._employeeService.Object, this._taxCalculatorService.Object);
            var actual = viewModel.CalculateTaxForEmployees(expectedEmployees, Constants.TaxYear);

            /// Assert
            Assert.AreEqual(viewModel.ErrorMessage, string.Empty);
            Assert.IsTrue(viewModel.IsAllDataValid);
            Assert.AreEqual(expectedTaxForEmployees.Count, actual.Count);

            Assert.AreEqual(expectedTaxForEmployees[0].GrossIncome, actual[0].GrossIncome);
            Assert.AreEqual(expectedTaxForEmployees[0].NetIncome, actual[0].NetIncome);
            Assert.AreEqual(expectedTaxForEmployees[0].IncomeTax, actual[0].IncomeTax);
            Assert.AreEqual(expectedTaxForEmployees[0].SuperAmount, actual[0].SuperAmount);
            Assert.AreEqual(expectedTaxForEmployees[0].PayPeriod, actual[0].PayPeriod);
            Assert.AreEqual(expectedTaxForEmployees[0].EmployeeName, actual[0].EmployeeName);


            this._taxCalculatorService.Verify(p => p.Calculate(It.IsAny<Employee>(), It.IsAny<int>()), Times.Once);
            this._employeeService.VerifyAll();
            this._taxCalculatorService.VerifyAll();
        }
    }
}
