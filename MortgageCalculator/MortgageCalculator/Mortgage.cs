namespace MortgageCalculator
{
    public class Mortgage
    {
        public decimal InterestRate;
        public decimal PrincipalAmount;
        public int LoanTerm;
        public DateTime OriginationDate;

        public decimal MonthlyEscrow;

        public Mortgage(decimal interestRate, decimal principalAmount, DateTime originationDate, int loanTerm,
            decimal monthlyEscrow)
        {
            InterestRate = interestRate;
            MonthlyEscrow = monthlyEscrow;
            PrincipalAmount = principalAmount;
            OriginationDate = originationDate;
            LoanTerm = loanTerm;
        }
        public static decimal CalculateMonthlyPayment(DateTime originationDate, decimal principalAmount, 
            decimal interestRate, int loanTerm, double monthlyEscrow)
        {
            
            var monthlyInterestRate = interestRate / 12;
        var lengthInMonths = loanTerm * 12;
        var monthlyPrinPlusInt = (principalAmount * monthlyInterestRate) 
                                 /(decimal)(1-Math.Pow((double)(1+monthlyInterestRate), -lengthInMonths));
        
            var monthlyPayment = monthlyPrinPlusInt + (decimal)monthlyEscrow;
            return monthlyPayment;

        }
    }
}