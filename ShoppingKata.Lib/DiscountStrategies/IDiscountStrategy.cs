namespace ShoppingKata.Lib.DiscountStrategies;

/// <summary>
/// Discount strategy.
/// </summary>
public interface IDiscountStrategy
{
    public string AppliesToSKU { get; }
    
    /// <summary>
    /// Calculate the discount to apply.
    /// </summary>
    /// <returns></returns>
    int CalculateDiscountToApply(IEnumerable<Item> items);
}