namespace DBank.Calculator.Strategies.AdministrationFee
{
    internal interface IAdministrationFeeStrategy
    {
        decimal CalculateFee(decimal amount);
    }
}