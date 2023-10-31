using System;

namespace MortgageCalculatorLibrary
{
    public class Mortgage
    {
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
