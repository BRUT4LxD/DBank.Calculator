﻿using AutoMapper;
using DBank.Calculator.DTO;
using DBank.Calculator.Extensions;
using DBank.Calculator.Factories;
using DBank.Calculator.Model;
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
        private static int _calculationStrategy = 0;
        private static int _administrationFeeStrategy = 0;
        private static int _reportStrategy = 0;
        private static CultureInfo _culture = new CultureInfo("da-DK");

        public static void Main(string[] args)
        {
            LoadConfig();
            PreprocessArguments(args);
            if (!ValidateArguments(Arguments)) return;

            IMapper mapper = RegisterMappers();

            var calculator = new LoanCalculator(
                LoanCalculationFactory.GetCalculationStrategy(_calculationStrategy, _capitalization, _interestRate),
                AdministrationFeeFactory.GetFeeStrategy(_administrationFeeStrategy),
                LoanReportFactory.GetReportStrategy(_reportStrategy, _culture),
                mapper.Map<Loan>(Arguments));

            calculator.PrintLoanReport();
        }

        private static void LoadConfig()
        {
            try
            {
                _capitalization = CapitalizationExtension.GetCapitalizationByName(ConfigurationManager.AppSettings.Get("Capitalization"));
                _interestRate = double.Parse(ConfigurationManager.AppSettings.Get("InterestRate"), CultureInfo.InvariantCulture);
                _calculationStrategy = int.Parse(ConfigurationManager.AppSettings.Get("LoanCalculationStrategy"));
                _administrationFeeStrategy = int.Parse(ConfigurationManager.AppSettings.Get("LoanAdministrationFeeStrategy"));
                _reportStrategy = int.Parse(ConfigurationManager.AppSettings.Get("LoanReportStrategy"));
                _culture = new CultureInfo(ConfigurationManager.AppSettings.Get("Culture"));
            }
            catch
            {
                Console.WriteLine("Invalid configuration provided");
                throw;
            }
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

        private static bool ValidateArguments(Arguments arguments)
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