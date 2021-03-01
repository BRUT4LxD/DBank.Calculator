using System;
using System.Globalization;

namespace DBank.Calculator.Strategies.Report
{
    internal class NoLoanReport : ILoanReportStrategy
    {
        public NoLoanReport(CultureInfo cultureInfo)
        {
        }

        public void PrintReport(decimal loanAmountTaken, decimal loanAmountToReturn, int loanYears,
            decimal administrationFee)
        {
            Console.WriteLine("***NO LOAN REPORT***");
        }
    }
}