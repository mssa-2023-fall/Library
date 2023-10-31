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
            var monthlyInterestRate = InterestRate / 12;
            var lengthInMonths = LoanTerm * 12;
            var monthlyPrinPlusInt = (PrincipalAmount * monthlyInterestRate)
                                     / (decimal)(1 - Math.Pow((double)(1 + monthlyInterestRate), -lengthInMonths));

            var monthlyPayment = monthlyPrinPlusInt + MonthlyEscrow;
            return (Math.Round(monthlyPayment,2));
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
    public class Escrow
    {
        public decimal MortgageInsurance { get; set; }
        public decimal HomeOwnerInsurance { get; set; }
        public decimal PropTax { get; set; }
        public decimal PrincipalAmount { get; set; }
        public Escrow( decimal mortgageInsurance, decimal homeOwnerInsurance, decimal propTax,decimal principalAmount)
        {
            MortgageInsurance = mortgageInsurance;
            HomeOwnerInsurance = homeOwnerInsurance;
            PropTax = propTax;
            PrincipalAmount = principalAmount;
        }
        public decimal CalculateMonthlyEscrow(out decimal monthlyEscrow)
        {
            decimal annualMortInsur = MortgageInsurance * 12;
            decimal annualHomeOwnInsur = HomeOwnerInsurance * 12;
            decimal annualPropTax = (PropTax * PrincipalAmount);
            monthlyEscrow = (annualMortInsur + annualHomeOwnInsur + annualPropTax) / 12;
            return monthlyEscrow;
        }
        //(APT+AHI+APMI)/12 = Monthly Escrow
    }
}
