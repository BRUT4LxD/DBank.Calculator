using System.Collections.Generic;

namespace DBank.Calculator
{
    internal class SpecificationResult
    {
        public bool IsSatisfied { get; set; }

        public List<string> Errors { get; private set; }

        public SpecificationResult()
        {
            this.Errors = new List<string>();
        }

        public static SpecificationResult Satisfied()
        {
            return new SpecificationResult
            {
                IsSatisfied = true
            };
        }

        public static SpecificationResult NotSatisfied(List<string> errors)
        {
            return new SpecificationResult
            {
                IsSatisfied = false,
                Errors = errors
            };
        }
    }
}