namespace MortgageCalculator;

public class Payment
{
    public Payment(decimal interestAmount, decimal paymentAmount, DateTime paymentDate, decimal totalPayment)
    {
        InterestAmount = interestAmount;
        PaymentAmount = paymentAmount;
        PaymentDate = paymentDate;
        TotalPayment = totalPayment;
    }

    public decimal InterestAmount { get; }
    public decimal PaymentAmount { get; }
    public DateTime PaymentDate { get; }
    public Decimal TotalPayment { get; }
}