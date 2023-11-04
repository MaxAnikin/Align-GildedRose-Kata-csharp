using System;
using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                UpdateItemQuality(item);
            }
        }

        private void UpdateItemQuality(Item item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            if (item.Name == Constants.AgedBrie || item.Name == Constants.BackstagePassesToATafkal80EtcConcert)
            {
                item.ChangeQuality(1);

                if (item.Name == Constants.BackstagePassesToATafkal80EtcConcert)
                {
                    if (item.SellIn < 11)
                        item.ChangeQuality(1);

                    if (item.SellIn < 6)
                        item.ChangeQuality(1);
                }
            }
            else
            {
                if (item.Name != Constants.SulfurasHandOfRagnaros)
                    item.ChangeQuality(-1);
            }

            if (item.Name != Constants.SulfurasHandOfRagnaros)
                item.SellIn -= 1;

            if (item.SellIn < 0)
                if (item.Name != Constants.AgedBrie)
                {
                    if (item.Name != Constants.BackstagePassesToATafkal80EtcConcert)
                    {
                        if (item.Name != Constants.SulfurasHandOfRagnaros)
                            item.ChangeQuality(-1);
                    }
                    else
                        item.ChangeQuality(-1 * item.Quality);
                }
                else
                    item.ChangeQuality(1);
        }
    }
}