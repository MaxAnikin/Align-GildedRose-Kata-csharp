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
                UpdateSellIn(item);
                UpdateItemQuality(item);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <exception cref="ArgumentNullException"></exception>
        private void UpdateItemQuality(Item item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            
            switch (item.Name)
            {
                case Constants.SulfurasHandOfRagnaros:
                    // SulfurasHandOfRagnaros is legendary and does not lose it's quality
                    break;
                case Constants.AgedBrie:
                    ClampQuality(item, item.SellIn < 0 ? 2 : 1);
                    break;

                case Constants.BackstagePassesToATafkal80EtcConcert:
                    switch (item.SellIn)
                    {
                        // drop quality after sell in
                        case < 0:
                            ClampQuality(item, -1 * item.Quality);
                            break;
                        // 5 days before 
                        case < 5:
                            ClampQuality(item, 3);
                            break;
                        // 10 days before
                        case < 10:
                            ClampQuality(item, 2);
                            break;
                        // usual increase
                        default:
                            ClampQuality(item, 1);
                            break;
                    }
                    break;
                default:
                    ClampQuality(item, item.SellIn < 0 ? -2 : -1);
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        private static void UpdateSellIn(Item item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            
            if (item.Name != Constants.SulfurasHandOfRagnaros) 
                item.SellIn -= 1;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="qualityChange"></param>
        private void ClampQuality(Item item, int qualityChange)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            item.Quality = Math.Clamp(item.Quality + qualityChange, Constants.MinQuantity, Constants.MaxQuantity);
        }
    }
}