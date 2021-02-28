namespace DBank.Calculator.Strategies.Report
{
    internal interface ILoanReportStrategy
    {
        void PrintReport(decimal loan, int years, decimal administrationFee);
    }
}