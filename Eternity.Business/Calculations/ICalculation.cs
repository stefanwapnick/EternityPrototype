namespace Eternity.Business.Calculations
{
    /// <summary>
    /// Defines a calculation operation
    /// </summary>
    /// <remarks>
    /// Such as addition, subtraction, etc
    /// </remarks>
    public interface ICalculation
    {
        /// <summary>
        /// Computes the result of the calculation
        /// </summary>
        /// <param name="firstOperand">first operand for calculation</param>
        /// <param name="secondOperand">second operand for calculation</param>
        /// <returns>Result of calculation</returns>
        double Compute(double firstOperand, double secondOperand); 

        /// <summary>
        /// Operation token
        /// </summary>
        string Token { get; }
    }
}