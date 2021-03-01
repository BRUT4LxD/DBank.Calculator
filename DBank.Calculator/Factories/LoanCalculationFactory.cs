using DBank.Calculator.Strategies.LoanCalculation;
using System;
using System.Collections.Generic;

namespace DBank.Calculator.Factories
{
    internal class LoanCalculationFactory
    {
        private static readonly Dictionary<int, Func<Capitalization, double, ILoanCalculationStrategy>> Strategies = new Dictionary<int, Func<Capitalization, double, ILoanCalculationStrategy>>
        {
            { 0, (cap, iRate) => new NoLoanCalculation(cap, iRate)},
            { 1, (cap, iRate) => new StandardLoanCalculation(cap, iRate)}
        };

        public static ILoanCalculationStrategy GetCalculationStrategy(int strategy, Capitalization capitalization, double interestRate)
        {
            if (!Strategies.ContainsKey(strategy)) return new NoLoanCalculation(capitalization, interestRate);

            return Strategies[strategy](capitalization, interestRate);
        }
    }
}