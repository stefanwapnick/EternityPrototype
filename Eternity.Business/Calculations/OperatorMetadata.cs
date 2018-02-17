namespace Eternity.Business.Calculations
{
    public class OperatorMetadata
    {
        public OperatorMetadata(string symbol, int priority)
        {
            Symbol = symbol;
            Priority = priority;
        }

        public string Symbol { get; }
        public int Priority { get; }
    }
}