using System;
using System.Globalization;

namespace DBank.Calculator.Strategies.Report
{
    internal class StandardLoanReport : ILoanReportStrategy
    {
        private readonly CultureInfo _cultureInfo;

        public StandardLoanReport(CultureInfo cultureInfo)
        {
            _cultureInfo = cultureInfo;
        }

        public void PrintReport(decimal loanAmountTaken, decimal loanAmountToReturn, int loanYears, decimal administrationFee)
        {
            var monthlyInstallment = loanAmountToReturn / (loanYears * Constants.NumberOfMonthsInYear);
            var interestRateAmount = loanAmountToReturn - loanAmountTaken;
            var aop = loanAmountToReturn / (loanYears * loanAmountTaken);

            Console.WriteLine("\n\n****LOAN REPORT****\n\n");
            Console.WriteLine("ÅOP: " + aop.ToString("P1"));
            Console.WriteLine("Monthly cost: " + monthlyInstallment.ToString("C", _cultureInfo));
            Console.WriteLine("Total amount paid in interest rate: " + interestRateAmount.ToString("C", _cultureInfo));
            Console.WriteLine("Administration fee: " + administrationFee.ToString("C", _cultureInfo));
        }
    }
}