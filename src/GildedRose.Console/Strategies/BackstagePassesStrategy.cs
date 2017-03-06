using GildedRose.Console.Contracts;

namespace GildedRose.Console.Strategies
{
    public class BackstagePassesStrategy : IChangeCoefStrategy
    {
        public BackstagePassesStrategy()
        {
            this.IsIncrease = true;
        }

        public bool? IsIncrease { get; private set; }

        public int CalculateCoef(int sellIn)
        {
            int qualityChangeCoeff = 1;
            if (sellIn <= 10)
            {
                qualityChangeCoeff = 2;
            }

            if (sellIn <= 5)
            {
                qualityChangeCoeff = 3;
            }

            if (sellIn <= 0)
            {
                qualityChangeCoeff = -1;
            }

            return qualityChangeCoeff;
        }
    }
}
