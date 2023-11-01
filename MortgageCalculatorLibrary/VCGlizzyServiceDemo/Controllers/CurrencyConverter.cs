using GlizzyServices;
using GlizzyServices.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VCGlizzyServiceDemo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CurrencyConverter : ControllerBase
    {
        private readonly ICurrencyConverter currencyConverter;

        public CurrencyConverter(ICurrencyConverter currencyConverter)
        {
            this.currencyConverter = currencyConverter;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fromCurrency">The currency to convert from, in 3 letters "USD", "GBP","JPY","NTD","CHF" </param>
        /// <param name="toCurrency">The currency to convert to</param>
        /// <param name="amountToConvert"></param>
        /// <returns></returns>
        [HttpGet(Name = "GetCurrencyConversion")]
        public ActionResult<Money> Get(string fromCurrency, string toCurrency, decimal amountToConvert)
        {
            var result = this.currencyConverter.Convert(fromCurrency, toCurrency, amountToConvert);
           return Ok(result);
        }
    }

   
 
}
