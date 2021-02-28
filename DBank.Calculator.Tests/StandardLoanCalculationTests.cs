using DBank.Calculator.Strategies.LoanCalculation;
using FluentAssertions;
using NUnit.Framework;

namespace DBank.Calculator.Tests
{
    [TestFixture]
    public class StandardLoanCalculationTests
    {
        [TestCase(500000, 10, 0.05, 636393.09)]
        [TestCase(500000, 10, 0.10, 792904.42)]
        [TestCase(500000, 10, 0.00, 500000)]
        public void StandardLoanCalculationTest_MonthlyCapitalization(decimal loanAmount, int years, double interestRate, decimal expectedResult)
        {
            var standardLoanCalculation = new StandardLoanCalculation(Capitalization.Monthly, interestRate);

            var result = standardLoanCalculation.Calculate(loanAmount, years);

            decimal.Round(result, 2).Should().Be(expectedResult);
        }

        [TestCase(500000, 10, 0.05, 638428.28)]
        [TestCase(500000, 10, 0.10, 796724.66)]
        [TestCase(500000, 10, 0.00, 500000)]
        public void StandardLoanCalculationTest_QuarterlyCapitalization(decimal loanAmount, int years, double interestRate, decimal expectedResult)
        {
            var standardLoanCalculation = new StandardLoanCalculation(Capitalization.Quarterly, interestRate);

            var result = standardLoanCalculation.Calculate(loanAmount, years);

            decimal.Round(result, 2).Should().Be(expectedResult);
        }

        [TestCase(500000, 10, 0.05, 647522.87)]
        [TestCase(500000, 10, 0.10, 813726.97)]
        [TestCase(500000, 10, 0.00, 500000)]
        public void StandardLoanCalculationTest_YearlyCapitalization(decimal loanAmount, int years, double interestRate, decimal expectedResult)
        {
            var standardLoanCalculation = new StandardLoanCalculation(Capitalization.Yearly, interestRate);

            var result = standardLoanCalculation.Calculate(loanAmount, years);

            decimal.Round(result, 2).Should().Be(expectedResult);
        }
    }
}