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
                : ComputeWithTaylorSeries(firstOperand, secondOperand);
        }

        private double ComputeWithTaylorSeries(double baseNumber, double power)
        {
            // x^y = e^(y*ln(x))

            double integerPower = Math.Floor(power);
            double integerPowerPart = ComputeForIntegerPower(baseNumber, (long) integerPower);

            power -= integerPower; 

            if (baseNumber - 1 < Double.Epsilon)
                return baseNumber;

            int factor = 0; 
            while(Math.Abs(baseNumber) > 1)
            {
                baseNumber /= Math.E;
                factor++; 
            }

            double lnComponent = factor + new NaturalLogCalculation().Compute(baseNumber);
            return integerPowerPart * new NaturalExpCalculation().Compute(power*lnComponent);
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