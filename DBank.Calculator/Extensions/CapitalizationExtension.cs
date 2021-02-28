using System;

namespace DBank.Calculator.Extensions
{
    public static class CapitalizationExtension
    {
        internal static Capitalization GetCapitalizationByName(string name)
        {
            return name switch
            {
                nameof(Capitalization.Monthly) => Capitalization.Monthly,
                nameof(Capitalization.Quarterly) => Capitalization.Quarterly,
                nameof(Capitalization.Yearly) => Capitalization.Yearly,
                _ => throw new ArgumentException("Invalid Capitalization")
            };
        }
    }
}