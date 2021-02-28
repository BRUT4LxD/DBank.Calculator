using System;

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
            if (_interestRate <= 0) return amount;

            var growthPerMonth = 1 + _interestRate / _capitalization.CalculationsInYear;

            //         a       b         c
            // R = A*(q^n * (q - 1))/(q^n - 1)
            var overallInstallments = years * _capitalization.CalculationsInYear;
            var a = (decimal)Math.Pow(growthPerMonth, overallInstallments);
            var b = (decimal)growthPerMonth - 1;
            var c = a - 1;

            var r = amount * a * b / c;

            Console.WriteLine("To return: " + r * overallInstallments);

            return r * overallInstallments;
        }
    }
}