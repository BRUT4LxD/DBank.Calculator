﻿using System;

namespace DBank.Calculator
{
    internal class StandardAdministrationFee : IAdministrationFeeStrategy
    {
        public decimal CalculateFee(decimal amount)
        {
            return Math.Min((decimal)0.01 * amount, 10000);
        }
    }
}