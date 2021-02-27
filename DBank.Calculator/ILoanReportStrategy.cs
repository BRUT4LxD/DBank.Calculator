namespace DBank.Calculator
{
    internal interface ILoanReportStrategy
    {
        void PrintReport(decimal loan, int years, decimal administrationFee);
    }
}