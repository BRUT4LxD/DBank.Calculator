using DBank.Calculator.Strategies.AdministrationFee;
using FluentAssertions;
using NUnit.Framework;

namespace DBank.Calculator.Tests
{
    [TestFixture]
    internal class NoAdministrationFeeTests
    {
        [TestCase(500000)]
        [TestCase(-100)]
        [TestCase(0)]
        public void NoAdministrationFeeTests_ShouldReturn0(decimal amount)
        {
            var noAdministrationFee = new NoAdministrationFee();

            var result = noAdministrationFee.CalculateFee(amount);

            result.Should().Be(0);
        }
    }
}