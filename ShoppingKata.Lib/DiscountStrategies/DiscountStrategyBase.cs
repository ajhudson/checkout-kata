namespace ShoppingKata.Lib.DiscountStrategies;

public abstract class DiscountStrategyBase : IDiscountStrategy
{
    /// <summary>
    /// Get the SKU the discount applies to.
    /// </summary>
    public abstract string AppliesToSKU { get; }
    
    /// <summary>
    /// Calculate the discount to take off the total.
    /// </summary>
    /// <param name="items"></param>
    /// <returns></returns>
    public abstract int CalculateDiscountToApply(IEnumerable<Item> items);
}