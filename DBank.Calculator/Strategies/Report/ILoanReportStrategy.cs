namespace DBank.Calculator.Strategies.Report
{
    internal interface ILoanReportStrategy
    {
        void PrintReport(decimal loanAmountTaken, decimal loanAmountToReturn, int loanYears, decimal administrationFee);
    }
}