using AutoMapper;
using DBank.Calculator.DTO;
using DBank.Calculator.Model;
using DBank.Calculator.Strategies.AdministrationFee;
using DBank.Calculator.Strategies.LoanCalculation;
using DBank.Calculator.Strategies.Report;
using DBank.Calculator.Validators;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;

namespace DBank.Calculator
{
    public static class Program
    {
        private static readonly Arguments Arguments = new Arguments();
        private static Capitalization _capitalization = Capitalization.Monthly;
        private static double _interestRate = 0.10;

        public static void Main(string[] args)
        {
            LoadConfig();
            PreprocessArguments(args);
            if (!ValidArguments(Arguments)) return;

            IMapper mapper = RegisterMappers();

            var calculator = new LoanCalculator(
                new StandardLoanCalculation(_capitalization, _interestRate),
                new StandardAdministrationFee(),
                new StandardLoanReport(new CultureInfo("da-DK")),
                mapper.Map<Loan>(Arguments));

            calculator.PrintLoanReport();
        }

        private static void LoadConfig()
        {
            _capitalization = CapitalizationExtension.GetCapitalizationByName(ConfigurationManager.AppSettings.Get("Capitalization"));
            _interestRate = double.Parse(ConfigurationManager.AppSettings.Get("InterestRate"), CultureInfo.InvariantCulture);
        }

        private static IMapper RegisterMappers()
        {
            var config = new MapperConfiguration(cfg => cfg.AddMaps(typeof(LoanCalculator)));
            return config.CreateMapper();
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

                Console.WriteLine("Provide loan duration (years):");
                Arguments.Years = Console.ReadLine();
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
                    case "-amount":
                        Arguments.Loan = args[i++ + 1];
                        break;

                    case "-duration":
                        Arguments.Years = args[i++ + 1];
                        break;

                    default:
                        Console.WriteLine($"Invalid parameter: {args[i]}");
                        break;
                }
            }
        }
    }
}