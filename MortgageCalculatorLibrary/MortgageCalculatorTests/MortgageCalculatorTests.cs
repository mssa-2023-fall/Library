using GlizzyServices;
using MortgageCalculatorLibrary;
using System.Runtime.InteropServices;
using static MortgageCalculatorLibrary.Mortgage;

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

        [TestMethod]
        public void GivenAMoneyMortgage_WhenCurrencyIsConverted_AccurateResultsAreReturned() {
            // Arrange
            var currencyConverter = new CurrencyConverter();

            // Act
            var yenValue = currencyConverter.Convert("USD", "JPY", 100_000).Amount;

            var response = CurrencyConverter.ConvertCurrencyAsync("USD", "JPY", 100_000);
            decimal yenValueAsync = response.Result.Amount;


            // Assert
            Assert.IsTrue(yenValue > 15_100_000 && yenValue < 15_200_000);
            Assert.IsTrue(yenValueAsync > 15_100_000 && yenValueAsync < 15_200_000);
        }
    }
    
}