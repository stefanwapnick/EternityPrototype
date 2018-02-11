namespace Eternity.Business.Calculations
{
    public class OperatorMetadata
    {
        public string Symbol { get; }
        public int Priority { get; }

        public OperatorMetadata(string symbol, int priority)
        {
            Symbol = symbol;
            Priority = priority;
        }
    }
}