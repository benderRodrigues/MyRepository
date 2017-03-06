using System;
using GildedRose.Console.Base;
using GildedRose.Console.Entities;
using GildedRose.Console.Strategies;

namespace GildedRose.Console
{
    public class ModifiedItemsProcessor : BaseItemsProcessor<Item>
    {
        //#region Legendary
        //private int DEFAULT_LEGENDARY_VALUE = 80;
        //private int? legendaryQualityValue;
        //public int LegendaryQualityValue
        //{
        //    get { return legendaryQualityValue ?? DEFAULT_LEGENDARY_VALUE; }
        //    set { legendaryQualityValue = value; }
        //}
        //#endregion

        #region Max Common Quality
        private int DEFAULT_MAX_COMMON_QUALITY_VALUE = 50;
        private int? maxCommonQualityValue;
        public int MaxCommonQualityValue
        {
            get { return maxCommonQualityValue ?? DEFAULT_MAX_COMMON_QUALITY_VALUE; }
            set { maxCommonQualityValue = value; }
        }
        #endregion

        public override void UpdateQuality()
        {
            foreach (var item in this)
            {
                this.UpdateItemQuality(item);
            }
        }

        public void UpdateItemQuality(Item item)
        {
            var strategy = StrategyFactory.GetStrategy(item);
            var baseQualityChangeCoeff = strategy.CalculateCoef(item.SellIn);

            if (baseQualityChangeCoeff > 0)
            {
                item.Quality = strategy.IsIncrease.GetValueOrDefault()
                    ? this.CheckQualityByDefaultRules(item.Quality + baseQualityChangeCoeff)
                    : this.CheckQualityByDefaultRules(item.Quality - baseQualityChangeCoeff);
                item.SellIn--;
            }
            else if (baseQualityChangeCoeff == -1)
            {
                item.Quality = 0;
                item.SellIn--;
            }
            else if (baseQualityChangeCoeff == 0)
            {
                //item.Quality = this.LegendaryQualityValue;
            }
            else
            {
                throw new ArgumentException("The strategy result is not expected");
            }
        }

        private int CheckQualityByDefaultRules(int quality)
        {
            if (quality < 0)
            {
                quality = 0;
            }
            else if (quality > this.MaxCommonQualityValue)
            {
                quality = this.MaxCommonQualityValue;
            }
            return quality;
        }
    }
}
