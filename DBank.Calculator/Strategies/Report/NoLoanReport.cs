using System;

namespace DBank.Calculator.Strategies.Report
{
    internal class NoLoanReport : ILoanReportStrategy
    {
        public void PrintReport(decimal loanAmountTaken, decimal loanAmountToReturn, int loanYears,
            decimal administrationFee)
        {
            Console.WriteLine("***NO LOAN REPORT***");
        }
    }
}