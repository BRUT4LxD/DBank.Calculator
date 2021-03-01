namespace DBank.Calculator.Strategies.LoanCalculation
{
    internal class NoLoanCalculation : ILoanCalculationStrategy
    {
        private readonly Capitalization _capitalization;
        private readonly double _interestRate;

        public NoLoanCalculation(Capitalization capitalization, double interestRate)
        {
            _capitalization = capitalization;
            _interestRate = interestRate;
        }

        public decimal Calculate(decimal amount, int years) => amount;
    }
}