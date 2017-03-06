using System.Collections.Generic;
using GildedRose.Console.Base;
using GildedRose.Console.Entities;

namespace GildedRose.Console
{
    public class ItemsProcessor : BaseItemsProcessor<Item>
    {
        private readonly Program program = new Program();

        public override void UpdateQuality()
        {
            program.UpdateQuality();
        }

        protected override void InsertItem(int index, Item item)
        {
            if (program.Items == null)
            {
                program.Items = new List<Item>();
            }

            program.Items.Add(item);

            base.InsertItem(index, item);
        }
    }
}
