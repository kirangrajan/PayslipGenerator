using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MYOB.PayslipGenerator.Utilities;

namespace MYOB.PayslipGenerator.Repository.Tests
{
    [TestClass]
    public class IncomeTaxCalculationRepositoryTest
    {
        public Mock<ITaxSlabRepository> _taxSlabRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            this._taxSlabRepository = new Mock<ITaxSlabRepository>();
        }

        [TestMethod]
        public void Test_Check_If_Tax_Is_Caluclated_Properly_For_A_Given_Annual_Salary_And_Tax_Year()
        {
            /// Arrange
            var annualSalary = 120000.00M; 
            var expectedTaxSlab = DataHelper.GetTaxSlabsFor2013();
            this._taxSlabRepository.Setup(p => p.GetTaxSlab(annualSalary, 2013)).Returns(expectedTaxSlab[3]);
            var expectedIncomeTax = 2696;
            
            /// Act
            var incomeTaxCalcRepository = new IncomeTaxCalculationRepository(this._taxSlabRepository.Object);
            var actual = incomeTaxCalcRepository.CalculateIncomeTax(annualSalary, 2013);

            /// Assert
            Assert.AreEqual(expectedIncomeTax, actual.Round());
        }
    }
}
