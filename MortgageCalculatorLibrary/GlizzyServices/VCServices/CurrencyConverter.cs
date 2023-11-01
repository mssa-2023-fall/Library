using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GlizzyServices.Services
{



    public class ConversionResult
    {
        public float new_amount { get; set; }
        public string new_currency { get; set; }
        public string old_currency { get; set; }
        public float old_amount { get; set; }
    }

    public class CurrencyConverter : ICurrencyConverter
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CurrencyConverter(IHttpClientFactory httpClientFactory) =>
            _httpClientFactory = httpClientFactory;
        public Money Convert(string from, string to, decimal amountToConvertFrom)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://currency-converter-by-api-ninjas.p.rapidapi.com/v1/convertcurrency?have={from}&want={to}&amount={amountToConvertFrom}"),
                Headers =
                {
                    { "X-RapidAPI-Key", "c2738f8bc0mshcc0331a25b7d018p1e7966jsne3e1b9d39117" },
                    { "X-RapidAPI-Host", "currency-converter-by-api-ninjas.p.rapidapi.com" },
                },
            };
            var client = _httpClientFactory.CreateClient();

            using (var response = client.SendAsync(request).Result)
            {
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadFromJsonAsync<ConversionResult>().Result;
                    return new Money() { Amount = (decimal)result!.new_amount, Currency = to };
                }
                else
                {
                    throw new Exception("Service is not available.");
                }
            }
        }
    }
}
