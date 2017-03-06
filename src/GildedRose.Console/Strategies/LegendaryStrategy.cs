using GildedRose.Console.Contracts;

namespace GildedRose.Console.Strategies
{
    public class LegendaryStrategy : IChangeCoefStrategy
    {
        public LegendaryStrategy()
        {
            this.IsIncrease = null;
        }

        public bool? IsIncrease { get; set; }
        public int CalculateCoef(int sellIn)
        {
            return 0;
        }
    }
}
