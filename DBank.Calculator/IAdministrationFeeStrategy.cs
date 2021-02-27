namespace DBank.Calculator
{
    internal interface IAdministrationFeeStrategy
    {
        decimal CalculateFee(decimal amount);
    }
}