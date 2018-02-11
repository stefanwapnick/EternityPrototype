using System;

namespace Eternity.Business.Events
{
    public class ResultComputedEventArgs : EventArgs
    {
        public string InputString { get;  }

        public double CompuetedValue { get; }

        public ResultComputedEventArgs(string inputString, double compuetedValue)
        {
            InputString = inputString;
            CompuetedValue = compuetedValue;
        }
    }
}