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
        private readonly decimal _value;
        private readonly int _duration;

        public LoanCalculator(
            ILoanCalculationStrategy loanCalculationStrategy,
            IAdministrationFeeStrategy administrationFeeStrategy,
            ILoanReportStrategy loanReportStrategy,
            decimal value,
            int duration)
        {
            _loanCalculationStrategy = loanCalculationStrategy;
            _administrationFeeStrategy = administrationFeeStrategy;
            _loanReportStrategy = loanReportStrategy;
            _value = value;
            _duration = duration;
        }

        public void PrintLoanReport()
        {
            var amountToReturn = _loanCalculationStrategy.Calculate(_value, _duration);
            var administrationFee = _administrationFeeStrategy.CalculateFee(_value);
            _loanReportStrategy.PrintReport(amountToReturn, _duration, administrationFee);
        }
    }
}