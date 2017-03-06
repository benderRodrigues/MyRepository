using GildedRose.Console.Contracts;

namespace GildedRose.Console.Strategies
{
    public class CommonStrategy : IChangeCoefStrategy
    {
        public CommonStrategy()
        {
            this.IsIncrease = false;
        }

        public CommonStrategy(bool isIncrease)
        {
            this.IsIncrease = isIncrease;
        }

        public bool? IsIncrease { get; private set; }

        public int CalculateCoef(int sellIn)
        {
            return (sellIn <= 0 ? 2 : 1);
        }
    }
}
