namespace Eternity.Business.Calculations.Impl
{
    public class AdditionCalculation : ICalculation
    {
        public double Compute(double firstOperand, double secondOperand)
        {
            return firstOperand + secondOperand;
        }

        public string Token => "+";
    }
}