using System.Collections.Generic;
using System.Linq;
using Eternity.Business.Calculations;
using Eternity.Business.Calculations.Impl;
using Eternity.Common.Enums;
using Eternity.Common.Exceptions;

namespace Eternity.Business.Factories
{
    public class CalculationFactory
    {
        private readonly IEnumerable<ICalculation> _registeredCalculations;
        
        public CalculationFactory()
        {
            _registeredCalculations = new List<ICalculation>
            {
                new AdditionCalculation(),
                new SubtractionCalculation(),
                new DivisionCalculation(),
                new MultiplicationCalculation(),
                new PowerCalculation()
            };

        }

        public ICalculation CreateCalculation(string operation)
        {
            ICalculation calculation = _registeredCalculations.FirstOrDefault(c => c.Token.Equals(operation));
            
            if(calculation == null)
                throw new CalculatorException(ErrorCode.UnsupportedCalculation, operation);

            return calculation;
        }
    }
}