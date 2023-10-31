using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MortgageCalculatorLibrary;

namespace DelayerMiddlewareTesting.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MortgageCalculator : ControllerBase
    {
        private ILogger<WeatherForecastController> _logger;

        public MortgageCalculator(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetMonthlyPayment")]
        public decimal Get(decimal principalAmount, decimal interestRateInPercent, int loanTermInYear)
        {
            var mortgage = new Mortgage(interestRateInPercent, principalAmount, DateTime.Now, loanTermInYear, 0);
            return mortgage.CalculateMonthlyPayment();
        }
    }
}
