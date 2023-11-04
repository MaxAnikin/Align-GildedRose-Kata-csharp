using System;
using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        private const int MaxQuantity = 50;
        
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
            
            if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert")
            {
                if (item.Quality > 0 && item.Name != "Sulfuras, Hand of Ragnaros")
                    item.Quality -= 1;
            }
            else
            {
                if (item.Quality < MaxQuantity)
                {
                    item.Quality += 1;

                    if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (item.SellIn < 11 && item.Quality < MaxQuantity)
                            item.Quality += 1;

                        if (item.SellIn < 6 && item.Quality < MaxQuantity)
                            item.Quality += 1;
                    }
                }
            }

            if (item.Name != "Sulfuras, Hand of Ragnaros")
                item.SellIn -= 1;

            if (item.SellIn < 0)
                if (item.Name != "Aged Brie")
                {
                    if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (item.Quality > 0 && item.Name != "Sulfuras, Hand of Ragnaros")
                            item.Quality -= 1;
                    }
                    else
                        item.Quality = 0;
                }
                else
                {
                    if (item.Quality < MaxQuantity)
                        item.Quality += 1;
                }
        }
    }
}
