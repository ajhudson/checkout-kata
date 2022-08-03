namespace ShoppingKata.Lib.DiscountStrategies;

public abstract class DiscountStrategyBase : IDiscountStrategy
{
    /// <summary>
    /// Get the SKU the discount applies to.
    /// </summary>
    public abstract string AppliesToSKU { get; }

    /// <summary>
    /// The quantity of items required for the promotion to apply.
    /// </summary>
    public abstract int QuantityMultiplier { get; }

    /// <summary>
    /// How much to discount by.
    /// </summary>
    public int DiscountFactor { get; set; }

    /// <summary>
    /// Calculate the discount to take off the total.
    /// </summary>
    /// <param name="items"></param>
    /// <returns></returns>
    public abstract int CalculateDiscountToApply(IEnumerable<Item> items);
}