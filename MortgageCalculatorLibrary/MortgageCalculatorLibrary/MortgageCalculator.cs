using System;
using GlizzyServices;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.JavaScript;
using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices;

namespace MortgageCalculatorLibrary
{
    public class Mortgage {
        public decimal InterestRate { get; set; }
        public decimal PrincipalAmount { get; set; }
        public int LoanTerm { get; set; }
        public DateTime OriginationDate { get; set; }
        public decimal MonthlyEscrow { get; set; }

        public Mortgage(decimal interestRate, decimal principalAmount, DateTime originationDate,
                        int loanTerm, decimal monthlyEscrow)
        {
            InterestRate = interestRate;
            MonthlyEscrow = monthlyEscrow;
            PrincipalAmount = principalAmount;
            OriginationDate = originationDate;
            LoanTerm = loanTerm;
        }

        public decimal CalculateMonthlyPayment()
        {
            var monthlyInterestRate = InterestRate / 100 / 12;
            var lengthInMonths = LoanTerm * 12;
            var monthlyPrinPlusInt = (PrincipalAmount * monthlyInterestRate)
                                     / (decimal)(1 - Math.Pow((double)(1 + monthlyInterestRate), -lengthInMonths));

            var monthlyPayment = monthlyPrinPlusInt + MonthlyEscrow;
            return monthlyPayment;
        }

        public override string ToString() {
            return $"Monthly Payment: {CalculateMonthlyPayment()} " +
                $"Interest Rate: %{InterestRate} " +
                $"Monthly Escrow: {MonthlyEscrow} " +
                $"Principal Amount: {PrincipalAmount} " +
                $"Origin Date: {OriginationDate} " +
                $"Loan Term: {LoanTerm}";
        }

        public class CurrencyConverter : ICurrencyConverter {
            public Money Convert(string from, string to, decimal amountToConvertFrom) {
                return ConvertCurrencyAsync(from, to, amountToConvertFrom).Result;
            }

            public static async Task<Money> ConvertCurrencyAsync(string from, string to, decimal amountToConvertFrom) {
                var convertedMoney = new Money() { Currency = from, Amount = amountToConvertFrom };
                var client = new HttpClient();

                var request = new HttpRequestMessage {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://currency-converter-by-api-ninjas.p.rapidapi.com/v1/convertcurrency?have={from}&want={to}&amount={amountToConvertFrom}"),
                    Headers =
                    {
                    { "X-RapidAPI-Key", "83242bb83emsh9a6bf7e86603930p12b53fjsnb1980475ad0c" },
                    { "X-RapidAPI-Host", "currency-converter-by-api-ninjas.p.rapidapi.com" },
                },
                };

                try {
                    using (var response = await client.SendAsync(request)) {
                        response.EnsureSuccessStatusCode();
                        var body = await response.Content.ReadAsStringAsync();
                        dynamic responseObject = JObject.Parse(body);
                        convertedMoney = new Money() { Currency = responseObject.new_currency, Amount = responseObject.new_amount };
                        //Console.WriteLine($"Old Cur: {responseObject.old_currency} Old Amount: {responseObject.old_amount}\nNew Cur: {responseObject.new_currency} New Amount: {responseObject.new_amount}");
                    }
                } catch { Console.WriteLine("Error :("); };

                return convertedMoney;
            }
        }
    }

    public class Payment
    {
        public decimal InterestAmount { get; }
        public decimal PaymentAmount { get; }
        public DateTime PaymentDate { get; }
        public decimal TotalPayment { get; }

        public Payment(decimal interestAmount, decimal paymentAmount, DateTime paymentDate, decimal totalPayment)
        {
            InterestAmount = interestAmount;
            PaymentAmount = paymentAmount;
            PaymentDate = paymentDate;
            TotalPayment = totalPayment;
        }
    }
}
