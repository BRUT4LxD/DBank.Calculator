using DBank.Calculator.Strategies.LoanCalculation;
using FluentAssertions;
using NUnit.Framework;

namespace DBank.Calculator.Tests
{
    [TestFixture]
    public class NoLoanCalculationTests
    {
        [TestCase(500000, 10, 0.05, 500000)]
        [TestCase(500000, 10, 0.10, 500000)]
        public void NoLoanCalculationTest_MonthlyCapitalization(decimal loanAmount, int years, double interestRate, decimal expectedResult)
        {
            var noLoanCalculation = new NoLoanCalculation(Capitalization.Monthly, interestRate);

            var result = noLoanCalculation.Calculate(loanAmount, years);

            result.Should().Be(expectedResult);
        }

        [TestCase(500000, 10, 0.05, 500000)]
        [TestCase(500000, 10, 0.10, 500000)]
        public void NoLoanCalculationTest_QuarterlyCapitalization(decimal loanAmount, int years, double interestRate, decimal expectedResult)
        {
            var noLoanCalculation = new NoLoanCalculation(Capitalization.Quarterly, interestRate);

            var result = noLoanCalculation.Calculate(loanAmount, years);

            result.Should().Be(expectedResult);
        }

        [TestCase(500000, 10, 0.05, 500000)]
        [TestCase(500000, 10, 0.10, 500000)]
        public void NoLoanCalculationTest_YearlyCapitalization(decimal loanAmount, int years, double interestRate, decimal expectedResult)
        {
            var noLoanCalculation = new NoLoanCalculation(Capitalization.Yearly, interestRate);

            var result = noLoanCalculation.Calculate(loanAmount, years);

            result.Should().Be(expectedResult);
        }
    }
}