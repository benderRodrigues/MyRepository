using System;
using System.Collections.Generic;
using System.Linq;
using GildedRose.Console;
using GildedRose.Console.Base;
using GildedRose.Console.Entities;
using NUnit.Framework;

namespace GildedRose.Tests
{
    public partial class TestAssemblyTests
    {
        private BaseItemsProcessor<Item> BaseItemProcessor = null;

        [SetUp]
        public void InitializeTest()
        {
            this.BaseItemProcessor = new ModifiedItemsProcessor();
        }

        private List<Item> ParseTestParam(params object[] @params)
        {
            string name = (string)@params[0];

            int sellInInput = (int)@params[1];
            int qualityInput = (int)@params[2];

            int sellInExpected = (int)@params[3];
            int qualityExpected = (int)@params[4];

            return new List<Item>()
            {
                new Item() { Quality = qualityInput, SellIn = sellInInput, Name = name },
                new Item() { Quality = qualityExpected, SellIn = sellInExpected, Name = name }
            };
        }

        public void MakeOperation(Item item)
        {
            this.BaseItemProcessor.Add(item);
            this.BaseItemProcessor.UpdateQuality();
        }

        public bool CheckResult(Item expectedItem)
        {
            if (this.BaseItemProcessor.Count != 1)
            {
                throw new ArgumentException("There are no records in collection");
            }

            return 
                expectedItem.Quality == this.BaseItemProcessor.First().Quality &&
                expectedItem.SellIn == this.BaseItemProcessor.First().SellIn &&
                expectedItem.Name == this.BaseItemProcessor.First().Name;
        }
    }
}
