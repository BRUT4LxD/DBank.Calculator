using DBank.Calculator.Strategies.Report;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace DBank.Calculator.Factories
{
    internal static class LoanReportFactory
    {
        private static readonly Dictionary<int, Func<CultureInfo, ILoanReportStrategy>> Strategies = new Dictionary<int, Func<CultureInfo, ILoanReportStrategy>>
        {
            { 0, c => new NoLoanReport(c)},
            { 1, c => new StandardLoanReport(c)}
        };

        public static ILoanReportStrategy GetReportStrategy(int strategy, CultureInfo cultureInfo)
        {
            if (!Strategies.ContainsKey(strategy)) return new NoLoanReport(cultureInfo);

            return Strategies[strategy](cultureInfo);
        }
    }
}