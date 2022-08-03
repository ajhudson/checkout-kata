namespace ShoppingKata.Lib.DiscountStrategies;

/// <summary>
/// Discount strategy.
/// </summary>
public interface IDiscountStrategy
{
    /// <summary>
    /// Name of SKU the discount applies to.
    /// </summary>
    public string AppliesToSKU { get; }

    /// <summary>
    /// The quantity of items required for the promotion to apply.
    /// </summary>
    public int QuantityMultiplier { get; }

    /// <summary>
    /// How much to discount by.
    /// </summary>
    public int DiscountFactor { get; }
    
    /// <summary>
    /// Calculate the discount to apply.
    /// </summary>
    /// <returns></returns>
    decimal CalculateDiscountToApply(IEnumerable<Item> items);
}