namespace DBank.Calculator.Strategies.AdministrationFee
{
    internal class NoAdministrationFee : IAdministrationFeeStrategy
    {
        public decimal CalculateFee(decimal amount) => 0;
    }
}