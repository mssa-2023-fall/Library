﻿namespace GlizzyServices
{
	public interface ICurrencyConverter
	{
		Money Convert(string from, string to, decimal amountToConvertFrom);
	}

    public record class Money
    {
        public string Currency;
        public decimal Amount;
    }

    interface INotifier
    {
        void Notify(string addressTo,string message);
    }

    interface IGlizzyFacts
    {
        GlizzyFact GetGlizzyFact();
        bool AddGlizzyFacts(GlizzyFact fact );
    }

    public record class GlizzyFact
    {
        int FactId;
        string Source;
        string Fact;
    }

    interface IMortgageCalcualtor
    {
        decimal CalculateMonthlyPayment();
    }


}