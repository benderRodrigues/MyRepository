using GildedRose.Console;
using GildedRose.Console.Base;
using GildedRose.Console.Contracts;
using GildedRose.Console.Entities;
using NUnit.Framework;

namespace GildedRose.Tests.Overhead
{
    public partial class TestAssemblyTests_Overhead
    {
        const int MAX_QUALITY = 50;
        private readonly BaseItemsProcessor<Item> BaseItemProcessor = new ModifiedItemsProcessor();
        //private readonly BaseItemsProcessor<Item> BaseItemProcessor = new ItemsProcessor();

        private void CheckQuality(int qualityValue)
        {
            Assert.True(qualityValue < MAX_QUALITY, "The Quality should be less than 50");
            Assert.IsFalse(qualityValue < 0, "The quality should be more or equeal than 0");
        }

        private void IncreaseTest(Item item, IChangeCoefStrategy changeCoefStrategy)
        {
            this.BaseItemProcessor.Add(item);

            this.CheckQuality(item.Quality);

            int etalonSellIn = item.SellIn;
            int etalonQuality = item.Quality;

            int startSellIn = etalonSellIn;
            int startQuality = etalonQuality;

            int increaseCoef = changeCoefStrategy.CalculateCoef(startSellIn);
            for (int i = startQuality; i <= (MAX_QUALITY - startQuality) + 1; i++)
            {
                this.BaseItemProcessor.UpdateQuality();

                //quality
                {
                    etalonQuality = increaseCoef == -1 ? 0 : (etalonQuality + increaseCoef);
                    if (etalonQuality > MAX_QUALITY)
                    {
                        etalonQuality = MAX_QUALITY;
                    }
                    Assert.IsTrue(item.Quality == etalonQuality, "The Quality didn't increase correctly");
                }

                Assert.IsTrue(item.SellIn == (etalonSellIn - 1), "The Sell In didn't decrease correctly");

                increaseCoef = changeCoefStrategy.CalculateCoef(item.SellIn);
                if (increaseCoef > 1)
                {
                    i += increaseCoef - 1;
                }
                if (increaseCoef == -1 && i < MAX_QUALITY)
                {
                    i += (MAX_QUALITY - startQuality) - i;
                }

                etalonQuality = item.Quality;
                etalonSellIn = item.SellIn;
            }
        }

        private void DecreaseCheckSteps(Item item, IChangeCoefStrategy changeCoefStrategy)
        {
            this.BaseItemProcessor.Add(item);

            this.CheckQuality(item.Quality);

            int etalonSellIn = item.SellIn;
            int etalonQuality = item.Quality;

            int startSellIn = etalonSellIn;

            int decreaseCoef = changeCoefStrategy.CalculateCoef(startSellIn);

            for (int i = startSellIn; i >= -1 /*one more try after sellin = 0*/; i--)
            {
                this.BaseItemProcessor.UpdateQuality();
                this.CheckQuality(item.Quality);

                Assert.IsTrue(item.SellIn == (etalonSellIn - 1), "The Sell In didn't decrease correctly");

                if (item.Quality > 0)
                {
                    int toCompare = decreaseCoef != -1 ? (etalonQuality - decreaseCoef) : 0;
                    Assert.IsTrue(item.Quality == toCompare, "The Quality didn't decrease correctly");
                }

                decreaseCoef = changeCoefStrategy.CalculateCoef(item.SellIn);
                //correct index because of a lot possible not needed trying
                if (decreaseCoef > 1)
                {
                    i -= decreaseCoef;
                    i += 1;
                }

                etalonQuality = item.Quality;
                etalonSellIn = item.SellIn;
            }
        }
    }
}
