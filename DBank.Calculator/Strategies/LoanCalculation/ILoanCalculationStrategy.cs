namespace DBank.Calculator.Strategies.LoanCalculation
{
    internal interface ILoanCalculationStrategy
    {
        decimal Calculate(decimal amount, int years);
    }
}