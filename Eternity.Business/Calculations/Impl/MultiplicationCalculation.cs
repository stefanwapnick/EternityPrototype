namespace Eternity.Business.Calculations.Impl
{
    public class MultiplicationCalculation : ICalculation
    {
        public double Compute(double firstOperand, double secondOperand)
        {
            return firstOperand * secondOperand;
        }

        public string Token => "*";
    }
}