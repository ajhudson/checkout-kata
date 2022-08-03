namespace ShoppingKata.Lib.DiscountStrategies;

public class BulkDiscountStrategy : DiscountStrategyBase
{
    /// <summary>
    /// The discount applies to SKU "C"
    /// </summary>
    public override string AppliesToSKU => nameof(SKU.B);

    /// <summary>
    /// The quantity of items required for the promotion to apply.
    /// </summary>
    public override int QuantityMultiplier => 5;

    /// <summary>
    /// Calculate the discount to take off the cost.
    /// </summary>
    /// <param name="items"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public override int CalculateDiscountToApply(IEnumerable<Item> items)
    {
        var discountedItems = items.Where(i => i.SKU == this.AppliesToSKU).Select(i => i).ToList();
        var multiples = discountedItems.Count / 3;
        var discountToApply = multiples * this.QuantityMultiplier;

        return discountToApply;
    }
}