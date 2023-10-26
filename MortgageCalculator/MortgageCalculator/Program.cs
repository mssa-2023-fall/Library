namespace MortgageCalculator;
internal static class Program
{
    public static void Main()
    {
        //shortcut test to validate formula
         // Console.WriteLine(
         //     Mortgage.CalculateMonthlyPayment(new DateTime(28 / 9 / 2023),
         //         (decimal)653565.76, (decimal).06389, 30, 767.79));

        Console.WriteLine("Please enter the principle amount borrowed on the loan:");
        decimal userPrincipal = Convert.ToDecimal(Console.ReadLine()!);

        Console.WriteLine("Enter the interest rate:");
        decimal userInterestIn = Convert.ToDecimal(Console.ReadLine()!);
        decimal userInterest = userInterestIn * (decimal).01;

        Console.WriteLine("Enter the date the mortgage originated:");
        DateTime userOriginationDate = DateTime.Parse(Console.ReadLine()!);
        Console.WriteLine($"The date you entered is: {userOriginationDate}");

        Console.WriteLine("Enter the original loan length in years: ");
        int userloanTerm = Convert.ToInt32(Console.ReadLine());
        
        Console.WriteLine("Enter the Monthly Escrow amount:");
        double userMonthlyEscrow = Convert.ToDouble(Console.ReadLine());

        Decimal d = Mortgage.CalculateMonthlyPayment(userOriginationDate, userPrincipal, userInterest, userloanTerm, userMonthlyEscrow);
        Console.WriteLine($"The monthly payment is approximately {d:C2}");
    }
}