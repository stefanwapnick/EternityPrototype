using System;
using System.Collections.Generic;
using Eternity.Business.Calculations;
using Eternity.Business.Factories;
using Eternity.Common.Enums;
using Eternity.Common.Exceptions;

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

        public string Compute(string mathematicalExpression)
        {
            Console.WriteLine($"Executing computation for {mathematicalExpression}");

            // Convert from infix to postfix format
            Queue<string> postfixQueue = _parser.Parse(mathematicalExpression);

            Console.WriteLine($"Postfix string: {string.Join(":", postfixQueue)}");

            Stack<double> operands = new Stack<double>();

            try
            {
                foreach (string token in postfixQueue)
                {
                    if (OperatorManifest.IsOperator(token))
                    {
                        ICalculation calculation = _calculationFactory.CreateCalculation(token);
                        double secondOperand = operands.Pop();
                        double firstOperand = operands.Pop();
                        double result = calculation.Compute(firstOperand, secondOperand);
                        operands.Push(result);
                    }
                    else
                    {
                        operands.Push(string.IsNullOrEmpty(token) ? 0 : double.Parse(token));
                    }
                }

                double finalResult = operands.Count > 0 ? operands.Pop() : 0;
                return finalResult.ToString();
            }
            catch (OverflowException)
            {
                throw new CalculatorException(ErrorCode.Overflow);
            }
            
        }

    }
}