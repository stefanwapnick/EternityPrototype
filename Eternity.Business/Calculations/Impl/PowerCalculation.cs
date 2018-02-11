using System;

namespace Eternity.Business.Calculations.Impl
{
    public class PowerCalculation : ICalculation
    {
        public double Compute(double firstOperand, double secondOperand)
        {
            // Integer power, can use simple divide and conquer algorithm
            return secondOperand % 1 < Double.Epsilon
                ? ComputeForIntegerPower(firstOperand, (long) secondOperand)
                : ComputePowerSeries(firstOperand, secondOperand);
        }

        private double ComputePowerSeries(double baseNumber, double power)
        {
            return Math.Pow(baseNumber, power);
        }

        private double ComputeForIntegerPower(double baseNumber, long power)
        {
            // Trivial case in recursion
            if (power == 0)
                return 1;

            if (Math.Abs(power) < 1)
                return baseNumber;

            if (power % 2 == 0)
            {
                double halfPowerResult = ComputeForIntegerPower(baseNumber, power / 2);
                return halfPowerResult * halfPowerResult;
            }

            return baseNumber * ComputeForIntegerPower(baseNumber, power-1);
        }

        public string Token => "^";
    }
}