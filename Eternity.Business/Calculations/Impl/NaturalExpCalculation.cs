using System;

namespace Eternity.Business.Calculations.Impl
{
    /// <summary>
    /// Calculats e^x using taylor series expansion
    /// </summary>
    public class NaturalExpCalculation : ICalculation
    {

        public double Compute(double operand)
        {
            double summation = 0;

            double incrementThreshold = Double.Epsilon * 1_000_000;
            double increment = 0;
            long index = 0;
            double runningFactorial = 1;
            double exponentPart = 1;

            // e^x = \sum x^n/n!
            do
            {
                if (index == 0)
                {
                    increment = 1;
                }
                else
                {
                    exponentPart *= operand;
                    runningFactorial *= index;
                    increment = exponentPart / runningFactorial;
                }

                summation += increment;
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