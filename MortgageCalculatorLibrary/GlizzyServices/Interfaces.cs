using GlizzyServices;

namespace GlizzyServices
{
	interface ICurrencyConverter
	{
		Money Convert(string from, string to, decimal amountToConvertFrom);
	}

    public record class Money
    {
        string Currency;
        decimal Amount;
    }

    interface INotifier
    {
        void Notify(string addressTo,string message);
    }

   public interface IGlizzyFacts
    {
       public GlizzyFact GetGlizzyFact();
       public bool AddGlizzyFacts(GlizzyFact fact );
    }

    public record class GlizzyFact
   {
        public int FactId;
        public string Source;
        public string Fact;
        public GlizzyFact(int factId, string source, string fact)
        {
            FactId = factId;
            Source = source;
            Fact = fact;
        }
    }

    interface IMortgageCalcualtor
    {
        decimal CalculateMonthlyPayment();
    }
}