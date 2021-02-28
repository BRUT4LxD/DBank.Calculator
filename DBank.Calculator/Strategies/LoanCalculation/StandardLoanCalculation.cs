﻿using System;

namespace DBank.Calculator.Strategies.LoanCalculation
{
    internal class StandardLoanCalculation : ILoanCalculationStrategy
    {
        private readonly Capitalization _capitalization;
        private readonly double _interestRate;

        public StandardLoanCalculation(Capitalization capitalization, double interestRate)
        {
            _capitalization = capitalization;
            _interestRate = interestRate;
        }

        public decimal Calculate(decimal amount, int years)
        {
            var growthPerMonth = 1 + _interestRate / _capitalization.CalculationsInYear;

            var overallInstallments = years * Constants.NumberOfMonthsInYear;
            var a = (decimal)Math.Pow(growthPerMonth, overallInstallments);
            var b = (decimal)growthPerMonth - 1;
            var c = a - 1;

            var r = amount * a * b / c;

            return r * overallInstallments;
        }
    }
}