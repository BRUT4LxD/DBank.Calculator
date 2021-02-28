using System;

namespace DBank.Calculator
{
    public static class CapitalizationExtension
    {
        internal static Capitalization GetCapitalizationByName(string name)
        {
            name = name.ToLower();
            return name switch
            {
                "monthly" => Capitalization.Monthly,
                "quarterly" => Capitalization.Quarterly,
                "yearly" => Capitalization.Yearly,
                _ => throw new ArgumentException("Invalid Capitalization")
            };
        }
    }
}