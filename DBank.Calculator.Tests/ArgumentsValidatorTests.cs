using DBank.Calculator.DTO;
using DBank.Calculator.Validators;
using FluentAssertions;
using NUnit.Framework;

namespace DBank.Calculator.Tests
{
    [TestFixture]
    public class ArgumentsValidatorTests
    {
        [TestCase("", "")]
        [TestCase("100", "")]
        [TestCase("", "10")]
        [TestCase("100", null)]
        [TestCase(null, null)]
        [TestCase("100", null)]
        [TestCase(null, "10")]
        [TestCase("-100", "10")]
        [TestCase("100", "-10")]
        public void ArgumentsValidatorTests_ShouldFail_WhenInvalidArgumentsProvided(string loan, string duration)
        {
            var args = new Arguments
            {
                Loan = loan,
                Duration = duration
            };

            var validator = new LoanArgumentsValidator();

            validator.Validate(args).Errors.Should().NotBeEmpty();
        }

        [TestCase("100", "10")]
        [TestCase("0", "0")]
        [TestCase("100000000", "100")]
        public void ArgumentsValidatorTests_ShouldPass_WhenInvalidArgumentsProvided(string loan, string duration)
        {
            var args = new Arguments
            {
                Loan = loan,
                Duration = duration
            };

            var validator = new LoanArgumentsValidator();

            validator.Validate(args).Errors.Should().BeEmpty();
        }
    }
}