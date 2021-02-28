namespace DBank.Calculator.Strategies.Report
{
    internal interface ILoanReportStrategy
    {
        void PrintReport(decimal loanAmount, int loanYears, decimal administrationFee);
    }
}