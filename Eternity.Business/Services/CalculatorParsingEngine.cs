using System;
using System.Linq;
using Eternity.Business.Calculations;
using Eternity.Business.Events;

namespace Eternity.Business.Services
{
    /// <summary>
    /// Not thread safe
    /// </summary>
    public class CalculatorParsingEngine
    {
        private double _accumulatingResult;

        public void AddCharacter(string operation)
        {
            // Compute
            if (CalculationSymbols.TerminatingOperators.Contains(operation))
            {
                
            }

            _accumulatingResult = double.Parse(operation);
        }

        public event EventHandler<ResultComputedEventArgs> ResultComputed;

    }
}