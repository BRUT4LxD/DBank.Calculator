using System;

namespace DBank.Calculator.Strategies.AdministrationFee
{
    internal class StandardAdministrationFee : IAdministrationFeeStrategy
    {
        private const int AlternativeCost = 10000;

        public decimal CalculateFee(decimal amount)
        {
            return Math.Min((decimal)0.01 * amount, AlternativeCost);
        }
    }
}