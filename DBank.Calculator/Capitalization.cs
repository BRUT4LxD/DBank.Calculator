namespace DBank.Calculator
{
    internal class Capitalization
    {
        public readonly int CalculationsInYear;

        private Capitalization(int calculationsInYear)
        {
            CalculationsInYear = calculationsInYear;
        }

        public static Capitalization Monthly => new Capitalization(12);

        public static Capitalization Quarterly => new Capitalization(4);

        public static Capitalization Yearly => new Capitalization(1);
    }
}