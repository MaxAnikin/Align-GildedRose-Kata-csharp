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
            
            if (item.Name != Constants.SulfurasHandOfRagnaros)
                item.SellIn -= 1;
            
            switch (item.Name)
            {
                case Constants.SulfurasHandOfRagnaros:
                    // SulfurasHandOfRagnaros is legendary and does not lose it's quality
                    break;
                case Constants.AgedBrie:
                    item.ChangeQuality(item.SellIn < 0 ? 2 : 1);
                    break;

                case Constants.BackstagePassesToATafkal80EtcConcert:
                    switch (item.SellIn)
                    {
                        // drop quality after sell in
                        case < 0:
                            item.ChangeQuality(-1 * item.Quality);
                            break;
                        // 5 days before 
                        case < 5:
                            item.ChangeQuality(3);
                            break;
                        // 10 days before
                        case < 10:
                            item.ChangeQuality(2);
                            break;
                        // usual increase
                        default:
                            item.ChangeQuality(1);
                            break;
                    }
                    break;
                default:
                    item.ChangeQuality(item.SellIn < 0 ? -2 : -1);
                    break;
            }
        }
    }
}