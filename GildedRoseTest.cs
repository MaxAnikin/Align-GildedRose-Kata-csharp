using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void foo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = Constants.ConjuredManaCake, SellIn = 5, Quality = 10 } };
            
            GildedRose app = new GildedRose(Items);
            
            // first day 
            app.UpdateQuality();
            Assert.AreEqual(Items.Count, 1, "Items list must have single item");
            Assert.AreEqual(Items[0].Quality, 8, $"{Constants.ConjuredManaCake} must have it's quality degraded to 8 but it remained: {Items[0].Quality}");
            
            // second day 
            app.UpdateQuality();
            Assert.AreEqual(Items.Count, 1, "Items list must have single item");
            Assert.AreEqual(Items[0].Quality, 6, $"{Constants.ConjuredManaCake} must have it's quality degraded to 6 but it remained: {Items[0].Quality}");
            
            // third day 
            app.UpdateQuality();
            Assert.AreEqual(Items.Count, 1, "Items list must have single item");
            Assert.AreEqual(Items[0].Quality, 4, $"{Constants.ConjuredManaCake} must have it's quality degraded to 4 but it remained: {Items[0].Quality}");
            
            // fourth day 
            app.UpdateQuality();
            Assert.AreEqual(Items.Count, 1, "Items list must have single item");
            Assert.AreEqual(Items[0].Quality, 2, $"{Constants.ConjuredManaCake} must have it's quality degraded to 2 but it remained: {Items[0].Quality}");
            
            // fifth day 
            app.UpdateQuality();
            Assert.AreEqual(Items.Count, 1, "Items list must have single item");
            Assert.AreEqual(Items[0].Quality, 0, $"{Constants.ConjuredManaCake} must have it's quality degraded to 0 but it remained: {Items[0].Quality}");
            
            // sixth day 
            app.UpdateQuality();
            Assert.AreEqual(Items.Count, 1, "Items list must have single item");
            Assert.AreEqual(Items[0].Quality, 0, $"{Constants.ConjuredManaCake} must have it's quality degraded to 0");
        }
    }
}
