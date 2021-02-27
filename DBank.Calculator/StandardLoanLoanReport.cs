using System;

namespace DBank.Calculator
{
    internal class StandardLoanLoanReport : ILoanReportStrategy
    {
        public void PrintReport(decimal loan, int years, decimal administrationFee)
        {
            Console.WriteLine("Loan: " + loan / (years * Constants.NumberOfMonthsInYear));
            Console.WriteLine("Administration fee: " + administrationFee);
        }
    }
}