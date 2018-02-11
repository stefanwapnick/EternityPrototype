using System.Collections.Generic;
using System.Linq;
using Eternity.Business.Calculations;

namespace Eternity.Business.Services
{
    /// <summary>
    /// Based on algorithm: https://en.wikipedia.org/wiki/Shunting-yard_algorithm
    /// </summary>
    public class ShuntingYardParser
    {
        public Queue<string> Parse(string mathematicalExpression)
        {
            var operatorStack = new Stack<OperatorMetadata>();
            var outputQueue = new Queue<string>();

            string accumulatingNumber = string.Empty;

            foreach (char character in mathematicalExpression)
            {
                if (OperatorManifest.IsOperator(character))
                {
                    outputQueue.Enqueue(accumulatingNumber);
                    accumulatingNumber = string.Empty;
                    OperatorMetadata operatorMetadata = OperatorManifest.Parse(character);

                    while (operatorStack.Count > 0 && operatorStack.Peek().Priority >= operatorMetadata.Priority)
                    {
                        OperatorMetadata poppedOperator = operatorStack.Pop();
                        outputQueue.Enqueue(poppedOperator.Symbol);
                    }

                    operatorStack.Push(operatorMetadata);

                }
                else
                {
                    accumulatingNumber += character;
                }
                
            }
            
            if(!string.IsNullOrEmpty(accumulatingNumber))
                outputQueue.Enqueue(accumulatingNumber);

            while (operatorStack.Count > 0)
                outputQueue.Enqueue(operatorStack.Pop().Symbol);

            return outputQueue;
        }
    }
}