using System;
using Eternity.Business.Events;
using Eternity.Business.Factories;

namespace Eternity.Business.Services
{
    /// <summary>
    /// Not thread safe1
    /// </summary>
    /// <remarks>
    /// Uses https://en.wikipedia.org/wiki/Shunting-yard_algorithm
    /// </remarks>
    public class ShuntingYardCalculatorEngine : ICalculatorEngine
    {
        private readonly CalculationFactory _calculationFactory;
        private readonly ShuntingYardParser _parser;

        public ShuntingYardCalculatorEngine(CalculationFactory calculationFactory, ShuntingYardParser parser)
        {
            _parser = parser;
            _calculationFactory = calculationFactory;
        }

        public double Compute(string mathematicalExpression)
        {
            // Convert from infix to postfix format
            var postfixString = _parser.Parse(mathematicalExpression);
            return 2; 
        }

    }
}