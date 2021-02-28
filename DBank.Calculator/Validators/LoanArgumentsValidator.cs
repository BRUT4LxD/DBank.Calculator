using DBank.Calculator.DTO;
using FluentValidation;

namespace DBank.Calculator.Validators
{
    internal class LoanArgumentsValidator : AbstractValidator<Arguments>
    {
        public LoanArgumentsValidator()
        {
            RuleFor(arg => arg.Loan)
                .Must(loan => decimal.TryParse(loan, out var loanValue) && loanValue >= 0)
                .WithMessage("Invalid Loan value. Loan must be a positive decimal");

            RuleFor(arg => arg.Years)
                .Must(duration => int.TryParse(duration, out var durationValue) && durationValue >= 0)
                .WithMessage("Invalid duration value. Loan must be a positive integer value");
        }
    }
}