using System;

namespace Eternity.Business.Calculations.Impl
{
    /// <summary>
    /// Calculats ln(x) using taylor series expansion
    /// </summary>
    public class NaturalLogCalculation : ICalculation
    {

        public double Compute(double operand)
        {
            double summation = 0;

            double incrementThreshold = Double.Epsilon * 1_000_000;
            double increment = 0;
            int index = 1;
            int sign = 1;
            double exponentPart = 1;

            // e^x = \sum [(-1)^(i-1) * (x-1)^i] / i

            do
            {
                exponentPart *= (operand - 1);
                increment = sign * exponentPart / index;
                summation += increment;
                sign *= -1;
                index++;
            } while (Math.Abs(increment) > incrementThreshold);

            return summation;
        }

        public double Compute(double firstOperand, double secondOperand)
        {
            return Compute(firstOperand);
        }

        /// <summary>
        /// TODO: Currently unused
        /// </summary>
        public string Token => "_";
    }
}