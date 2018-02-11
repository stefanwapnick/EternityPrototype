using System.Collections.Generic;
using System.Linq;

namespace Eternity.Business.Calculations
{
    public static class OperatorManifest
    {
        public static readonly OperatorMetadata Addition = new OperatorMetadata("+", 2);

        public static readonly OperatorMetadata Substraction = new OperatorMetadata("-", 2);

        public static readonly OperatorMetadata Multiplication = new OperatorMetadata("*", 3);

        public static readonly OperatorMetadata Division = new OperatorMetadata("/", 3);

        public static readonly OperatorMetadata Power = new OperatorMetadata("^", 4);

        public static readonly List<OperatorMetadata> Operators = new List<OperatorMetadata>
        {
            Addition,
            Substraction,
            Multiplication,
            Division,
            Power
        };

        public static bool IsOperator(char operatorSymbol) => IsOperator(operatorSymbol.ToString());

        public static bool IsOperator(string operatorSymbol) => Operators.Any(o => o.Symbol.Equals(operatorSymbol));

        public static OperatorMetadata Parse(char operatorSymbol) => Parse(operatorSymbol.ToString());

        public static OperatorMetadata Parse(string operatorSymbol) => Operators.FirstOrDefault(o => o.Symbol.Equals(operatorSymbol));

    }
}