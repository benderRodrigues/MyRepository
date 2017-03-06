using NUnit.Framework;

namespace GildedRose.Tests
{
    public partial class TestAssemblyTests
    {
        [TestCase(new object[] { "Elixir of the Mongoose"/*Name*/,
            10/*SellIn input*/, 20/*Quality input*/,
            9/*SellIn expected*/, 19/*Quality expected*/, })]
        [TestCase(new object[] { "+5 Dexterity Vest"/*Name*/,
            10/*SellIn input*/, 20/*Quality input*/,
            9/*SellIn expected*/, 19/*Quality expected*/, })]
        [TestCase(new object[] { "+5 Dexterity Vest"/*Name*/,
            0/*SellIn input*/, 20/*Quality input*/,
            -1/*SellIn expected*/, 18/*Quality expected*/, })]
        public void CommonDecreaseLogicTest(params object[] @params)
        {
            var items = this.ParseTestParam(@params);
            this.MakeOperation(items[0]);
            Assert.IsTrue(this.CheckResult(items[1]), "The common decrease logic is not correct");
        }

        [TestCase(new object[] { "Elixir of the Mongoose"/*Name*/,
            0/*SellIn input*/, 0/*Quality input*/,
            -1/*SellIn expected*/, 0/*Quality expected*/, })]
        [TestCase(new object[] { "+5 Dexterity Vest"/*Name*/,
            0/*SellIn input*/, 0/*Quality input*/,
            -1/*SellIn expected*/, 0/*Quality expected*/, })]
        public void QualityShouldNotBeNegativeTest(params object[] @params)
        {
            var items = this.ParseTestParam(@params);
            this.MakeOperation(items[0]);
            Assert.IsTrue(this.CheckResult(items[1]), "The quality should not be negative");
        }

        [TestCase(new object[] { "Aged Brie"/*Name*/,
            20/*SellIn input*/, 20/*Quality input*/,
            19/*SellIn expected*/, 21/*Quality expected*/, })]
        [TestCase(new object[] { "Aged Brie"/*Name*/,
            0/*SellIn input*/, 20/*Quality input*/,
            -1/*SellIn expected*/, 22/*Quality expected*/, })]
        public void CommonIncreaseLogicTest(params object[] @params)
        {
            var items = this.ParseTestParam(@params);
            this.MakeOperation(items[0]);
            Assert.IsTrue(this.CheckResult(items[1]), "The common increase logic is not correct");
        }

        [TestCase(new object[] { "Aged Brie"/*Name*/,
            2/*SellIn input*/, 50/*Quality input*/,
            1/*SellIn expected*/, 50/*Quality expected*/, })]
        public void QualityShouldNotBeMoreThen50(params object[] @params)
        {
            var items = this.ParseTestParam(@params);
            this.MakeOperation(items[0]);
            Assert.IsTrue(this.CheckResult(items[1]), "The common increase logic is not correct");
        }

        [TestCase(new object[] { "Sulfuras, Hand of Ragnaros"/*Name*/,
            2/*SellIn input*/, 50/*Quality input*/,
            2/*SellIn expected*/, 50/*Quality expected*/, })]
        public void CommonLegendaryLogicTest(params object[] @params)
        {
            var items = this.ParseTestParam(@params);
            this.MakeOperation(items[0]);
            Assert.IsTrue(this.CheckResult(items[1]), "The common legendary logic is not correct");
        }

        [TestCase(new object[] { "Backstage passes to a TAFKAL80ETC concert"/*Name*/,
            10/*SellIn input*/, 25/*Quality input*/,
            9/*SellIn expected*/, 27/*Quality expected*/, })]
        [TestCase(new object[] { "Backstage passes to a TAFKAL80ETC concert"/*Name*/,
            5/*SellIn input*/, 25/*Quality input*/,
            4/*SellIn expected*/, 28/*Quality expected*/, })]
        [TestCase(new object[] { "Backstage passes to a TAFKAL80ETC concert"/*Name*/,
            0/*SellIn input*/, 25/*Quality input*/,
            -1/*SellIn expected*/, 0/*Quality expected*/, })]
        public void QualityBackstagePassesLogicTest(params object[] @params)
        {
            var items = this.ParseTestParam(@params);
            this.MakeOperation(items[0]);
            Assert.IsTrue(this.CheckResult(items[1]), "The BackstagePasses logic is not correct");
        }

        [TestCase(new object[] { "Conjured Mana Cake"/*Name*/,
            10/*SellIn input*/, 25/*Quality input*/,
            9/*SellIn expected*/, 23/*Quality expected*/, })]
        [TestCase(new object[] { "Conjured Mana Cake"/*Name*/,
            0/*SellIn input*/, 25/*Quality input*/,
            -1/*SellIn expected*/, 21/*Quality expected*/, })]
        public void QualityConjuredLogicTest(params object[] @params)
        {
            var items = this.ParseTestParam(@params);
            this.MakeOperation(items[0]);
            Assert.IsTrue(this.CheckResult(items[1]), "The Conjured logic is not correct");
        }
    }
}