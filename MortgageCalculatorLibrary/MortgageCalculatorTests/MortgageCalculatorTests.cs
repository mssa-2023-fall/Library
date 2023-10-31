using MortgageCalculatorLibrary;
using System.Runtime.InteropServices;

namespace MortgageCalculatorTests {
    [TestClass]
    public class MortgageCalculatorTest {

        [TestMethod]
        public void GivenAnInterestRateOf1_WhenYearlyPaymentIsCalculated_TheResultIsGreaterThanPrincipalButLessThanPrincipalPlusInterest() {
            // Arrange
            var mortgage = new Mortgage(1, 100_000, DateTime.Now, 1, 0);

            // Act
            var totalPayment = mortgage.CalculateMonthlyPayment() * 12;

            // Assert
            Assert.IsTrue(totalPayment > 100_000 && totalPayment < 101_000);
        }
    }
}