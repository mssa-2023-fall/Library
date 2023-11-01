using GlizzyServices;

namespace GlizzyServices
{
	public interface ICurrencyConverter
	{
		public Money Convert(string from, string to, decimal amountToConvertFrom);
	}

    public record class Money
    {
      public string Currency { get; set; }
      public decimal Amount { get; set; }
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