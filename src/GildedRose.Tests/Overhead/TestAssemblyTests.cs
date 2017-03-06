using GildedRose.Console.Entities;
using GildedRose.Console.Strategies;
using NUnit.Framework;

namespace GildedRose.Tests.Overhead
{
    public partial class TestAssemblyTests_Overhead
    {
        //[TestCase(new object[] { 10/*SellIn*/, 20/*Quality*/, "+5 Dexterity Vest"/*Name*/})]
        [TestCase(new object[] { 10/*SellIn*/, 20/*Quality*/, "+5 Dexterity Vest"/*Name*/})]
        public void CommonDecreaseLogicTest(params object[] @params)
        {
            int sellIn = (int)@params[0];
            int quality = (int)@params[1];
            string name = (string)@params[2];

            var item = new Item() { Quality = quality, SellIn = sellIn, Name = name };

            this.DecreaseCheckSteps(item, 
                //(sellIn) => sellIn <= 0 ? 2 : 1
                new CommonStrategy()
                );
        }

        //[TestCase(new object[] { 2/*SellIn*/, 0/*Quality*/, "Aged Brie"/*Name*/})]
        [TestCase(new object[] { 2/*SellIn*/, 0/*Quality*/, "Aged Brie"/*Name*/})]
        public void AgedBrieTest(params object[] @params)
        {
            int sellIn = (int)@params[0];
            int quality = (int)@params[1];
            string name = (string)@params[2];

            var item = new Item() { Quality = quality, SellIn = sellIn, Name = name };

            this.IncreaseTest(item, new CommonStrategy(true));
        }

        [TestCase(new object[] { 0/*SellIn*/, 80/*Quality*/, "Sulfuras, Hand of Ragnaros"/*Name*/})]
        public void SulfurasTest(params object[] @params)
        {
            int sellIn = (int)@params[0];
            int quality = (int)@params[1];
            string name = (string)@params[2];

            var item = new Item() { Quality = quality, SellIn = sellIn, Name = name };

            int etalonSellIn = item.SellIn;
            int etalonQuality = item.Quality;

            for (int i = 0; i < 2; i++)
            {
                this.BaseItemProcessor.UpdateQuality();

                Assert.IsTrue(item.Quality == etalonQuality, "The Quality was changed");
                Assert.IsTrue(item.SellIn == etalonSellIn, "The SellIn was changed");
            }
        }

        //[TestCase(new object[] { 15/*SellIn*/, 20/*Quality*/, "Backstage passes to a TAFKAL80ETC concert"/*Name*/})]
        [TestCase(new object[] { 15/*SellIn*/, 1/*Quality*/, "Backstage passes to a TAFKAL80ETC concert"/*Name*/})]
        public void BackstagePassesTest(params object[] @params)
        {
            int sellIn = (int)@params[0];
            int quality = (int)@params[1];
            string name = (string)@params[2];

            var item = new Item() { Quality = quality, SellIn = sellIn, Name = name };

            this.IncreaseTest(item, new BackstagePassesStrategy());
        }

        [TestCase(new object[] {3/*SellIn*/,6/*Quality*/, "Conjured Mana Cake"/*Name*/})]
        public void ConjuredTest(params object[] @params)
        {
            int sellIn = (int)@params[0];
            int quality = (int)@params[1];
            string name = (string)@params[2];

            var item = new Item() {Quality = quality, SellIn = sellIn, Name = name};

            this.DecreaseCheckSteps(item, new ConjuredStrategy());
        }
    }
}