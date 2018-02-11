using System;
using Eternity.Common.Enums;
using Eternity.Common.Exceptions;

namespace Eternity.Business.Calculations.Impl
{
    public class DivisionCalculation : ICalculation
    {
        public string Token => "/";

        public double Compute(double firstOperand, double secondOperand)
        {
            if(Math.Abs(secondOperand) < Double.Epsilon)
                throw new CalculatorException(ErrorCode.DivisionByZero);

            return firstOperand / secondOperand;
        }
    }
}