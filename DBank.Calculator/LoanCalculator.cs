using DBank.Calculator.Model;
using DBank.Calculator.Strategies.AdministrationFee;
using DBank.Calculator.Strategies.LoanCalculation;
using DBank.Calculator.Strategies.Report;

namespace DBank.Calculator
{
    internal class LoanCalculator
    {
        private readonly ILoanCalculationStrategy _loanCalculationStrategy;
        private readonly IAdministrationFeeStrategy _administrationFeeStrategy;
        private readonly ILoanReportStrategy _loanReportStrategy;
        private readonly decimal _loanAmount;
        private readonly int _loanDuration;

        public LoanCalculator(
            ILoanCalculationStrategy loanCalculationStrategy,
            IAdministrationFeeStrategy administrationFeeStrategy,
            ILoanReportStrategy loanReportStrategy,
            Loan loan)
        {
            _loanCalculationStrategy = loanCalculationStrategy;
            _administrationFeeStrategy = administrationFeeStrategy;
            _loanReportStrategy = loanReportStrategy;
            _loanAmount = loan.Amount;
            _loanDuration = loan.Duration;
        }

        public void PrintLoanReport()
        {
            var amountToReturn = _loanCalculationStrategy.Calculate(_loanAmount, _loanDuration);
            var administrationFee = _administrationFeeStrategy.CalculateFee(_loanAmount);
            _loanReportStrategy.PrintReport(_loanAmount, amountToReturn, _loanDuration, administrationFee);
        }
    }
}