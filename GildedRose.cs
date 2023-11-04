using System;
using System.Collections.Generic;
using System.Linq;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;

        private readonly List<Rule> _qualityUpdateRules;
        private readonly List<Rule> _sellInRules;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
            
            _sellInRules = new List<Rule>()
            {
                // SulfurasHandOfRagnaros specific
                new(item => item.Name == Constants.SulfurasHandOfRagnaros, item => { }),
                
                // base for all items
                new(item => true, item => item.SellIn--, Constants.BaseRulePriority)
            };
            
            _qualityUpdateRules = new List<Rule>()
            {
                // no changes for SulfurasHandOfRagnaros
                new(item => item.Name == Constants.SulfurasHandOfRagnaros, item => { }),

                // rule ConjuredManaCake
                new(item => item.Name == Constants.ConjuredManaCake && item.SellIn >= 0,
                    item => { ClampQuality(item, -2); }),

                // rule ConjuredManaCake
                new(item => item.Name == Constants.ConjuredManaCake && item.SellIn < 0,
                    item => { ClampQuality(item, -4); }),

                // rule AgedBrie
                new(item => item.Name == Constants.AgedBrie && item.SellIn >= 0,
                    item => { ClampQuality(item, 1); }),

                // rule AgedBrie
                new(item => item.Name == Constants.AgedBrie && item.SellIn < 0,
                    item => { ClampQuality(item, 2); }),

                // rule BackstagePassesToATafkal80EtcConcert
                new(item => item.Name == Constants.BackstagePassesToATafkal80EtcConcert && item.SellIn < 0,
                    item => { ClampQuality(item, -1 * item.Quality); }),

                // rule BackstagePassesToATafkal80EtcConcert
                new(item => item.Name == Constants.BackstagePassesToATafkal80EtcConcert && item.SellIn < 5,
                    item => { ClampQuality(item, 3); }),

                // rule BackstagePassesToATafkal80EtcConcert
                new(item => item.Name == Constants.BackstagePassesToATafkal80EtcConcert && item.SellIn < 10,
                    item => { ClampQuality(item, 2); }),

                // rule BackstagePassesToATafkal80EtcConcert
                new(item => item.Name == Constants.BackstagePassesToATafkal80EtcConcert && item.SellIn >= 10,
                    item => { ClampQuality(item, 1); }),

                // base
                new(item => item.SellIn >= 0, item => { ClampQuality(item, -1); }, Constants.BaseRulePriority),

                // base
                new(item => item.SellIn < 0, item => { ClampQuality(item, -2); }, Constants.BaseRulePriority)
            };
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
            
            var qualityUpdateRule = _qualityUpdateRules.OrderByDescending(r => r.Priority).FirstOrDefault(r => r.Predicate(item));
            qualityUpdateRule?.Action(item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        private void UpdateSellIn(Item item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            var sellInRule = _sellInRules.OrderByDescending(r => r.Priority).FirstOrDefault(r => r.Predicate(item));
            sellInRule?.Action(item);
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