using DBank.Calculator.Strategies.AdministrationFee;
using System;
using System.Collections.Generic;

namespace DBank.Calculator.Factories
{
    internal static class AdministrationFeeFactory
    {
        private static readonly Dictionary<int, Func<IAdministrationFeeStrategy>> Strategies = new Dictionary<int, Func<IAdministrationFeeStrategy>>
        {
            { 0, () => new NoAdministrationFee()},
            { 1, () => new StandardAdministrationFee()}
        };

        public static IAdministrationFeeStrategy GetFeeStrategy(int strategy)
        {
            if (!Strategies.ContainsKey(strategy)) return new NoAdministrationFee();

            return Strategies[strategy]();
        }
    };
}