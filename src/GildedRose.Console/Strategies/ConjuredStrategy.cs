using GildedRose.Console.Contracts;

namespace GildedRose.Console.Strategies
{
    public class ConjuredStrategy : IChangeCoefStrategy
    {
        public ConjuredStrategy()
        {
            this.IsIncrease = false;
        }

        public bool? IsIncrease { get; private set; }

        public int CalculateCoef(int sellIn)
        {
            return (sellIn <= 0 ? 4 : 2);
        }
    }
}
