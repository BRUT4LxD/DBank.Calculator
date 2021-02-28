﻿using System;
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

        public void PrintReport(decimal loan, int years, decimal administrationFee)
        {
            var monthlyInstallment = loan / (years * Constants.NumberOfMonthsInYear);
            Console.WriteLine("Loan: " + monthlyInstallment.ToString("C", _cultureInfo));
            Console.WriteLine("Administration fee: " + administrationFee);
        }
    }
}