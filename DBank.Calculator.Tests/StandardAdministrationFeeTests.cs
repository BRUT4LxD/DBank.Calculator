using DBank.Calculator.Strategies.AdministrationFee;
using FluentAssertions;
using NUnit.Framework;

namespace DBank.Calculator.Tests
{
    [TestFixture]
    public class StandardAdministrationFeeTests
    {
        private readonly StandardAdministrationFee _standardAdministrationFee = new StandardAdministrationFee();

        [TestCase(5000)]
        [TestCase(15000)]
        [TestCase(500000)]
        public void StandardAdministrationFee_ShouldReturnCalculatedFee_WhenLoanAmountLessThen1000000(decimal loanAmount)
        {
            var result = _standardAdministrationFee.CalculateFee(loanAmount);

            result.Should().Be(loanAmount * (decimal)0.01);
        }

        [TestCase(1000000)]
        [TestCase(1500000)]
        [TestCase(100000000)]
        public void StandardAdministrationFee_ShouldReturn10000_WhenLoanAmountIsAtLeast1000000(decimal loanAmount)
        {
            var result = _standardAdministrationFee.CalculateFee(loanAmount);

            result.Should().Be(10000);
        }
    }
}