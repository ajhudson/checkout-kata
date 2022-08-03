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
    public abstract int DiscountFactor { get; }

    /// <summary>
    /// Calculate the discount to take off the total.
    /// </summary>
    /// <param name="items"></param>
    /// <returns></returns>
    public abstract decimal CalculateDiscountToApply(IEnumerable<Item> items);
    
    /// <summary>
    /// Filter out the discounted items.
    /// </summary>
    /// <param name="items"></param>
    /// <returns></returns>
    protected IReadOnlyList<Item> GetDiscountedItems(IEnumerable<Item> items) => items.Where(i => i.SKU == this.AppliesToSKU).Select(i => i).ToList();
}