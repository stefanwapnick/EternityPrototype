namespace Eternity.Business.Calculations
{
    public static class CalculationSymbols
    {
        public const string Addition = "+";

        public const string Substraction = "-";

        public const string Multiplication = "*";

        public const string Division = "/";

        public const string Power = "^";

        public static readonly string[] TerminatingOperators = new[]
        {
            Addition,
            Substraction,
            Multiplication,
            Division,
            Power
        };


    }
}