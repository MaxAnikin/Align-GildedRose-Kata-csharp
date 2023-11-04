using System;

namespace csharp;

public static class ItemExtensions
{
    /// <summary>
    /// Description is required
    /// </summary>
    /// <param name="item"></param>
    /// <param name="qualityChange"></param>
    public static void ChangeQuality(this Item item, int qualityChange)
    {
        if (item == null) throw new ArgumentNullException(nameof(item));

        item.Quality = Math.Clamp(item.Quality + qualityChange, Constants.MinQuantity, Constants.MaxQuantity);
    }
}