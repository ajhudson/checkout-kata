namespace ShoppingKata.Lib;

public static class ItemsFactory
{
    /// <summary>
    /// Create an <see cref="Item"/>
    /// </summary>
    /// <param name="sku"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static Item CreateItem(SKU sku)
    {
        return sku switch
        {
            SKU.A => new Item { SKU = nameof(SKU.A), UnitPrice = Constants.UnitPrices.PriceA },
            SKU.B => new Item { SKU = nameof(SKU.B), UnitPrice = Constants.UnitPrices.PriceB },
            SKU.C => new Item { SKU = nameof(SKU.C), UnitPrice = Constants.UnitPrices.PriceC },
            SKU.D => new Item { SKU = nameof(SKU.D), UnitPrice = Constants.UnitPrices.PriceD },
            _ => throw new ArgumentException("Incorrect SKU")
        };
    }

    /// <summary>
    /// Create multiple items.
    /// </summary>
    /// <param name="sku"></param>
    /// <param name="quantity"></param>
    /// <returns></returns>
    public static IEnumerable<Item> CreateItems(SKU sku, int quantity)
    {
        var items = new List<Item>();

        for (int i = 0; i < quantity; i++)
        {
            items.Add(CreateItem(sku));
        }

        return items;
    }
}