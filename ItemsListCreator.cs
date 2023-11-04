using System.Collections.Generic;

namespace csharp;

public class ItemsListCreator
{
    public List<Item> CreateItemsList()
    {
        return new List<Item>{
            new() {Name = Constants.DexterityVest, SellIn = 10, Quality = 20},
            new() {Name = Constants.AgedBrie, SellIn = 2, Quality = 0},
            new() {Name = Constants.ElixirOfTheMongoose, SellIn = 5, Quality = 7},
            new() {Name = Constants.SulfurasHandOfRagnaros, SellIn = 0, Quality = Constants.SulfurasQuality},
            new() {Name = Constants.SulfurasHandOfRagnaros, SellIn = -1, Quality = Constants.SulfurasQuality},
            new()
            {
                Name = Constants.BackstagePassesToATafkal80EtcConcert,
                SellIn = 15,
                Quality = 20
            },
            new()
            {
                Name = Constants.BackstagePassesToATafkal80EtcConcert,
                SellIn = 10,
                Quality = 49
            },
            new()
            {
                Name = Constants.BackstagePassesToATafkal80EtcConcert,
                SellIn = 5,
                Quality = 49
            },
            // this conjured item does not work properly yet
            new() {Name = Constants.ConjuredManaCake, SellIn = 3, Quality = 6}
        };
    }
}