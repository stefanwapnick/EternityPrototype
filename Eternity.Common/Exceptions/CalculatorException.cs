using System;
using Eternity.Common.Enums;

namespace Eternity.Common.Exceptions
{
    public class CalculatorException : Exception
    {
        public ErrorCode ErrorCode { get; }


        public CalculatorException(ErrorCode errorCode) : this(errorCode, string.Empty)
        {
        }

        public CalculatorException(ErrorCode errorCode, string data) : base(data)
        {
            ErrorCode = errorCode;
        }
    }
}