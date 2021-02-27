﻿using DBank.Calculator.Validators;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DBank.Calculator
{
    public static class Program
    {
        private static readonly Arguments Arguments = new Arguments();

        public static void Main(string[] args)
        {
            PreprocessArguments(args);
            if (!ValidArguments(Arguments))
            {
                return;
            }

            var calculator = new LoanCalculator(
                new StandardLoanLoanCalculation(Capitalization.Monthly, 0.05),
                new StandardAdministrationFee(),
                new StandardLoanLoanReport(),
                decimal.Parse(Arguments.Loan),
                int.Parse(Arguments.Duration)
                );

            calculator.PrintLoanReport();
        }

        private static void PreprocessArguments(IReadOnlyList<string> args)
        {
            if (args.Any())
            {
                ParseArgs(args);
            }
            else
            {
                Console.WriteLine("Provide loan value:");
                Arguments.Loan = Console.ReadLine();
                Console.WriteLine("Provide loan duration:");
                Arguments.Duration = Console.ReadLine();
            }
        }

        private static bool ValidArguments(Arguments arguments)
        {
            var argumentsValidationResults = new LoanArgumentsValidator().Validate(arguments);
            if (argumentsValidationResults.Errors.Any())
            {
                foreach (ValidationFailure validationFailure in argumentsValidationResults.Errors)
                {
                    Console.WriteLine(validationFailure.ErrorMessage);
                }

                return false;
            }

            return true;
        }

        private static void ParseArgs(IReadOnlyList<string> args)
        {
            for (var i = 0; i < args.Count; i++)
            {
                switch (args[i])
                {
                    case "-loan":
                        Arguments.Loan = args[i++ + 1];
                        break;

                    case "-duration":
                        Arguments.Duration = args[i++ + 1];
                        break;

                    default:
                        Console.WriteLine($"Invalid parameter: {args[i]}");
                        break;
                }
            }
        }
    }

    /* TODO:
    - Terms
    - Add AutoMapper
     */
}