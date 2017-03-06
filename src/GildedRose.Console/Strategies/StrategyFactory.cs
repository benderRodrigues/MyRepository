using GildedRose.Console.Contracts;
using GildedRose.Console.Entities;

namespace GildedRose.Console.Strategies
{
    public static class StrategyFactory
    {
        public static IChangeCoefStrategy GetStrategy<T>(T item) where T : Item
        {
            switch (item.Name)
            {
                case "Conjured Mana Cake": return new ConjuredStrategy();
                case "Sulfuras, Hand of Ragnaros": return new LegendaryStrategy();
                case "Backstage passes to a TAFKAL80ETC concert": return new BackstagePassesStrategy();
                case "Aged Brie": return new CommonStrategy(true);
                default: return new CommonStrategy();
            }
        }
    }
}
