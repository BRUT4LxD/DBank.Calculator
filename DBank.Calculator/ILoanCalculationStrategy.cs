namespace DBank.Calculator
{
    internal interface ILoanCalculationStrategy
    {
        decimal Calculate(decimal amount, int years);
    }
}