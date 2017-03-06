using System.Collections.Generic;
using System.Collections.ObjectModel;
using GildedRose.Console.Entities;

namespace GildedRose.Console.Base
{
    public abstract class BaseItemsProcessor<T> : Collection<T> where T : Item
    {
        public abstract void UpdateQuality();

        public void AddRange(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                base.Add(item);
            }
        }
    }
}
